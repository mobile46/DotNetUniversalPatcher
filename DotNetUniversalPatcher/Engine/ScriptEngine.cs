using dnlib.DotNet;
using DotNetUniversalPatcher.Models;
using DotNetUniversalPatcher.UI;
using DotNetUniversalPatcher.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DotNetUniversalPatcher.Properties;

namespace DotNetUniversalPatcher.Engine
{
    internal class ScriptEngine : ScriptEngineBase
    {
        internal static Dictionary<string, string> Placeholders { get; set; } = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public override string[] GetSoftwareNames()
        {
            string[] softwareNames = new string[LoadedScripts.Count];

            for (int i = 0; i < LoadedScripts.Count; i++)
            {
                softwareNames[i] = LoadedScripts[i].PatcherOptions.PatcherInfo.Software;
            }

            return softwareNames;
        }

        public override void LoadAndParseScripts()
        {
            try
            {
                Logger.ClearLogs();

                string[] scriptFiles = Directory.GetFiles(Constants.PatchersDir, Constants.ScriptFilePattern, SearchOption.TopDirectoryOnly).Select(Path.GetFullPath).ToArray();

                foreach (string file in scriptFiles)
                {
                    try
                    {
                        var script = JsonConvert.DeserializeObject<PatcherScript>(File.ReadAllText(file), new JsonSerializerSettings
                        {
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            NullValueHandling = NullValueHandling.Ignore,
                            DateFormatString = "dd.MM.yyyy"
                        });

                        if (ScriptEngineHelpers.ValidateScript(script))
                        {
                            ScriptEngineHelpers.AddPlaceholders(script);
                            ScriptEngineHelpers.ParsePlaceholders(script);
                            ScriptEngineHelpers.AddTargetFilesText(script);

                            LoadedScripts.Add(script);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(string.Format(Resources.ScriptEngine_LoadAndParseScripts_Exception_Msg,
                            Path.GetFileName(file), Program.IsDebugModeEnabled ? "\r\n" : string.Empty, ex.Message,
                            Program.IsDebugModeEnabled ? string.Format("\r\n{0}", ex.StackTrace) : string.Empty));
                        IsLoadingError = true;
                        FrmMain.Instance.grpReleaseInfo.Enabled = true;
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Logger.Error(string.Format(Resources.ScriptEngine_LoadAndParseScripts__DirectoryNotFoundException_Msg,
                    Program.IsDebugModeEnabled ? "\r\n" : string.Empty, ex.Message,
                    Program.IsDebugModeEnabled ? string.Format("\r\n{0}", ex.StackTrace) : string.Empty));
                IsLoadingError = true;
                FrmMain.Instance.grpReleaseInfo.Enabled = true;
            }
            catch
            {
                // ignored
            }

            if (LoadedScripts.Count > 0)
            {
                FrmMain.Instance.grpPatcherInfo.Enabled = true;
                FrmMain.Instance.grpReleaseInfo.Enabled = true;
                FrmMain.Instance.txtReleaseInfo.Enabled = true;
                FrmMain.Instance.chkMakeBackup.Enabled = true;
                FrmMain.Instance.btnPatch.Enabled = true;
            }
            else
            {
                FrmMain.Instance.grpPatcherInfo.Enabled = false;
                FrmMain.Instance.txtReleaseInfo.Enabled = false;
                FrmMain.Instance.chkMakeBackup.Enabled = false;
                FrmMain.Instance.btnPatch.Enabled = false;

                FrmMain.Instance.txtTargetFiles.Clear();
                FrmMain.Instance.txtAuthor.Clear();
                FrmMain.Instance.txtWebsite.Clear();
                FrmMain.Instance.txtReleaseDate.Clear();
                FrmMain.Instance.txtReleaseInfo.Clear();

                FrmMain.Instance.chkMakeBackup.Checked = false;

                RefreshTargetFilesText();
            }
        }

        public override void ChangeScript()
        {
            CurrentScript = LoadedScripts[FrmMain.Instance.cmbSoftware.SelectedIndex];

            RefreshTargetFilesText();
        }

        public override void Process()
        {
            int patchedFileCount = 0;

            try
            {
                foreach (var patch in CurrentScript.PatchList)
                {
                    foreach (string path in patch.TargetInfo.TargetFiles)
                    {
                        string filePath = path;

                        if (!File.Exists(filePath))
                        {
                            Logger.Error(string.Format(Resources.ScriptEngine_Process_File_not_found_Msg, filePath));

                            using (var ofd = new OpenFileDialog())
                            {
                                ofd.FileName = Path.GetFileName(filePath);
                                ofd.Filter = Resources.ScriptEngine_Process_Filter_ExtName;
                                ofd.CheckFileExists = true;

                                string directoryName = Path.GetDirectoryName(filePath);

                                if (Directory.Exists(directoryName))
                                {
                                    ofd.InitialDirectory = directoryName;
                                }
                                else
                                {
                                    ofd.RestoreDirectory = true;
                                }

                                if (ofd.ShowDialog() == DialogResult.OK)
                                {
                                    filePath = ofd.FileName;
                                }
                                else
                                {
                                    Logger.Log(Resources.ScriptEngine_Process__Skipping_file_Msg);
                                    Logger.Log();
                                    continue;
                                }
                            }
                        }

                        bool keepOldMaxStack = patch.TargetInfo.KeepOldMaxStack;

                        using (var p = new Patcher(filePath, keepOldMaxStack))
                        {
                            Logger.Log(string.Format(Resources.ScriptEngine_Process__File_Path_Msg, filePath,
                                keepOldMaxStack ? "-> KeepOldMaxStack: True" : string.Empty));

                            foreach (var target in patch.TargetList)
                            {
                                ProcessInternal(p, target);
                            }

                            p.Save(Convert.ToBoolean(CurrentScript.PatcherOptions.PatcherInfo.MakeBackup));
                        }

                        patchedFileCount++;

                        Logger.Log(string.Format(Resources.ScriptEngine_Process__File_Patched_Msg, filePath));
                        Logger.Log();
                    }

                    Logger.Log();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("{0}{1}", ex.Message,
                    Program.IsDebugModeEnabled ? string.Format("\r\n{0}", ex.StackTrace) : string.Empty));
                Logger.Log();
            }

            Logger.Info(patchedFileCount > 0 ? string.Format(Resources.ScriptEngine_Process_Patching_process_finished_Msg,
                    patchedFileCount)
                : Resources.ScriptEngine_Process_Nothing_patched_Msg);
        }

        internal void ProcessInternal(Patcher p, Target target)
        {
            p.Method = p.FindMethod(target.FullName).ResolveMethodDef();
            p.Instructions = p.Method.Body.Instructions;

            if (target.ILCodes != null && target.ILCodes.Count > 0)
            {
                ScriptEngineHelpers.ParseILCodes(p, target);
            }

            ScriptEngineHelpers.PatchTarget(p, target);

            ScriptEngineHelpers.WriteActionToLog(target);
        }

        private void RefreshTargetFilesText()
        {
            FrmMain.Instance.lblTargetFiles.Text = string.Format(Resources.FrmMain_Target_Files_Text, CurrentScript.TargetFilesCount);
        }
    }
}