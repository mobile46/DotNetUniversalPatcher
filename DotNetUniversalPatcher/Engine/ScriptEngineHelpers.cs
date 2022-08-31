using dnlib.DotNet;
using dnlib.DotNet.Emit;
using DotNetUniversalPatcher.Exceptions;
using DotNetUniversalPatcher.Extensions;
using DotNetUniversalPatcher.Models;
using DotNetUniversalPatcher.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DotNetUniversalPatcher.Properties;

namespace DotNetUniversalPatcher.Engine
{
    internal static class ScriptEngineHelpers
    {
        internal static readonly ModuleDefMD MscorelibModule = ModuleDefMD.Load(typeof(void).Module);

        internal static readonly Dictionary<string, string> ReservedPlaceholders = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public static bool ValidateScript(PatcherScript script)
        {
            if (string.IsNullOrWhiteSpace(script.PatcherOptions?.PatcherInfo?.Software))
            {
                throw new Exception(Resources.ScriptEngineHelpers_ValidateScript_Software_Name_is_empty_Msg);
            }

            for (var i = 0; i < script.PatchList.Count; i++)
            {
                var patch = script.PatchList[i];

                if (patch.TargetInfo != null)
                {
                    if (patch.TargetInfo.TargetFiles == null || patch.TargetInfo?.TargetFiles?.Count == 0)
                    {
                        throw new ValidatePatchException("TargetFiles is empty!", i);
                    }
                }
                else
                {
                    throw new ValidatePatchException("TargetInfo is empty!", i);
                }

                if (patch.TargetList != null)
                {
                    for (var j = 0; j < patch.TargetList.Count; j++)
                    {
                        var target = patch.TargetList[j];

                        if (string.IsNullOrWhiteSpace(target?.FullName) || string.IsNullOrWhiteSpace(target.Action?.ToString()))
                        {
                            throw new ValidatePatchAndTargetException("FullName or Action Method are empty!", i, j);
                        }

                        if (target.Action != ActionMethod.EmptyBody && target.ILCodes == null && target.Indices == null && target.Optional == null)
                        {
                            throw new ValidatePatchAndTargetException("Instructions, Indices or Optional are empty!", i, j);
                        }
                    }
                }
                else
                {
                    throw new ValidatePatchException("TargetList is empty", i);
                }
            }

            return true;
        }

        internal static void ParseILCodes(Patcher p, Target target)
        {
            target.Instructions = new Instruction[target.ILCodes.Count];

            for (int i = 0; i < target.Instructions.Length; i++)
            {
                string opcode = target.ILCodes[i].OpCode;

                if (opcode == null) throw new PatcherException("OpCode is empty", target.FullName);

                target.Instructions[i] = new Instruction(Helpers.GetOpCodeFromString(opcode.Replace('_', '.')));
            }

            for (int i = 0; i < target.Instructions.Length; i++)
            {
                string operand = target.ILCodes[i].Operand;

                if (operand != null)
                {
                    switch (target.Instructions[i].OpCode.OperandType)
                    {
                        case OperandType.InlineBrTarget:
                        case OperandType.ShortInlineBrTarget:
                            if (target.Action == ActionMethod.Patch)
                            {
                                target.Instructions[i].Operand = p.GetInstruction(target, operand.ToInt());
                            }
                            else
                            {
                                target.Instructions[i].Operand = p.GetInstruction(operand.ToInt());
                            }
                            break;

                        case OperandType.InlineField:
                            target.Instructions[i].Operand = p.FindField(operand);
                            break;

                        case OperandType.InlineI:
                            target.Instructions[i].Operand = operand.ToInt();
                            break;

                        case OperandType.InlineI8:
                            target.Instructions[i].Operand = operand.ToLong();
                            break;

                        case OperandType.InlineMethod:
                            target.Instructions[i].Operand = p.FindMethod(operand);
                            break;

                        case OperandType.InlineNone:
                        case OperandType.InlinePhi:
                        case OperandType.NOT_USED_8:
                            target.Instructions[i].Operand = null;
                            break;

                        case OperandType.InlineR:
                            target.Instructions[i].Operand = operand.ToDouble();
                            break;

                        case OperandType.InlineSig:
                            target.Instructions[i].Operand = p.FindMethod(operand).MethodSig;
                            break;

                        case OperandType.InlineString:
                            target.Instructions[i].Operand = operand;
                            break;

                        case OperandType.InlineSwitch:
                            string[] array = operand.Split(Constants.DefaultSeparator);

                            Instruction[] instructions = new Instruction[array.Length];

                            for (var j = 0; j < array.Length; j++)
                            {
                                if (target.Action == ActionMethod.Patch)
                                {
                                    instructions[j] = p.GetInstruction(target, array[j].ToInt());
                                }
                                else
                                {
                                    instructions[j] = p.GetInstruction(array[j].ToInt());
                                }
                            }

                            target.Instructions[i].Operand = instructions;
                            break;

                        case OperandType.InlineTok:
                            target.Instructions[i].Operand = p.FindMethodFieldOrType(operand);
                            break;

                        case OperandType.InlineType:
                            target.Instructions[i].Operand = p.FindType(operand);
                            break;

                        case OperandType.InlineVar:
                            target.Instructions[i].Operand = p.Method.Parameters[operand.ToInt()];
                            break;

                        case OperandType.ShortInlineI:
                            target.Instructions[i].Operand = target.Instructions[i].OpCode.Code == Code.Ldc_I4_S ? (object)operand.ToSByte() : operand.ToByte();
                            break;

                        case OperandType.ShortInlineR:
                            target.Instructions[i].Operand = operand.ToFloat();
                            break;

                        case OperandType.ShortInlineVar:
                            target.Instructions[i].Operand = p.Method.Parameters[operand.ToInt()];
                            break;
                    }
                }
            }

            target.ILCodes = null; //We don't need that anymore.
        }

        internal static void PatchTarget(Patcher p, Target target)
        {
            p.BackupExceptionHandlersIndices();

            switch (target.Action)
            {
                case ActionMethod.Patch:
                    p.Patch(target);
                    break;

                case ActionMethod.Insert:
                    p.Insert(target);
                    break;

                case ActionMethod.Replace:
                    p.Replace(target);
                    break;

                case ActionMethod.Remove:
                    p.Remove(target);
                    break;

                case ActionMethod.EmptyBody:
                    p.EmptyBody(target);
                    break;

                case ActionMethod.ReturnBody:
                    p.ReturnBody(target, Convert.ToBoolean(target.Optional));
                    break;

                default:
                    throw new PatcherException("Invalid action method", target.FullName);
            }

            p.FixOffsets();
            p.FixExceptionHandlers();
            p.FixBranches();
        }

        internal static void WriteActionToLog(Target target)
        {
            string logText = $"[{target.Action}] -> {target.FullName}";

            switch (target.Action)
            {
                case ActionMethod.Patch:
                case ActionMethod.Replace:
                case ActionMethod.Remove:
                    Logger.Log(logText);
                    break;

                case ActionMethod.EmptyBody:
                case ActionMethod.ReturnBody:
                    Logger.Log(target.Optional != null ? $"{logText} -> {target.Optional}" : logText);
                    break;
            }
        }

        internal static void AddPlaceholders(PatcherScript script)
        {
            foreach (var placeholder in script.PatcherOptions.Placeholders)
            {
                string placeholderKey = $"#{placeholder.Key.Replace("#", string.Empty).ToUpperInvariant()}#";

                if (!ReservedPlaceholders.ContainsKey(placeholderKey))
                {
                    if (!ScriptEngine.Placeholders.ContainsKey(placeholderKey))
                    {
                        ScriptEngine.Placeholders.Add(placeholderKey, placeholder.Value);
                    }
                    else
                    {
                        ScriptEngine.Placeholders[placeholderKey] = placeholder.Value;
                    }
                }
                else
                {
                    throw new PatcherException("Reserved placeholder cannot be changed!", placeholderKey);
                }
            }
        }

        internal static void AddSpecialFoldersToPlaceholders()
        {
            foreach (string name in Enum.GetNames(typeof(Environment.SpecialFolder)))
            {
                if (name == Environment.SpecialFolder.MyComputer.ToString() || name == Environment.SpecialFolder.LocalizedResources.ToString() || name == Environment.SpecialFolder.CommonOemLinks.ToString())
                {
                    continue;
                }

                string placeholder = $"#{name.Replace("#", string.Empty).ToUpperInvariant()}#";

                if (!ReservedPlaceholders.Keys.Contains(placeholder))
                {
                    if (name == Environment.SpecialFolder.ProgramFiles.ToString())
                    {
                        ReservedPlaceholders.Add(placeholder, Helpers.GetProgramFilesPath());
                        continue;
                    }

                    if (name == Environment.SpecialFolder.ProgramFilesX86.ToString())
                    {
                        ReservedPlaceholders.Add(placeholder, Helpers.GetProgramFilesPath(true));
                        continue;
                    }

                    if (name == Environment.SpecialFolder.CommonProgramFiles.ToString())
                    {
                        ReservedPlaceholders.Add(placeholder, Helpers.GetCommonProgramFilesPath());
                        continue;
                    }

                    if (name == Environment.SpecialFolder.CommonProgramFilesX86.ToString())
                    {
                        ReservedPlaceholders.Add(placeholder, Helpers.GetCommonProgramFilesPath(true));
                        continue;
                    }

                    ReservedPlaceholders.Add(placeholder, Environment.GetFolderPath((Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), name)));
                }
            }

            foreach (var folder in ReservedPlaceholders)
            {
                ScriptEngine.Placeholders.Add(folder.Key, folder.Value);
            }
        }

        internal static void ParsePlaceholders(PatcherScript script)
        {
            foreach (var patch in script.PatchList)
            {
                if (patch.TargetInfo.TargetFiles.Count > 0 && patch.TargetList.Count > 0)
                {
                    for (int i = 0; i < patch.TargetInfo.TargetFiles.Count; i++)
                    {
                        patch.TargetInfo.TargetFiles[i] = patch.TargetInfo.TargetFiles[i].MultipleReplace();
                    }
                }

                foreach (var target in patch.TargetList)
                {
                    target.FullName = target.FullName.MultipleReplace();

                    if (target.Indices != null)
                    {
                        for (int i = 0; i < target.Indices.Count; i++)
                        {
                            var index = target.Indices[i].MultipleReplace();

                            if (index.Contains(Constants.RangeExpressionSeparator))
                            {
                                target.Indices[i] = index;
                            }
                            else
                            {
                                target.Indices[i] = index.ToInt().ToString();
                            }
                        }
                    }

                    if (target.ILCodes != null)
                    {
                        foreach (var instruction in target.ILCodes)
                        {
                            if (instruction.OpCode != null)
                            {
                                instruction.OpCode = instruction.OpCode.MultipleReplace();
                            }

                            if (instruction.Operand != null)
                            {
                                instruction.Operand = instruction.Operand.MultipleReplace();
                            }
                        }
                    }

                    if (target.Optional != null)
                    {
                        target.Optional = target.Optional.MultipleReplace();
                    }
                }
            }
        }

        internal static void AddTargetFilesText(PatcherScript script)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patch in script.PatchList)
            {
                foreach (string filePath in patch.TargetInfo.TargetFiles)
                {
                    sb.AppendLine(filePath);

                    script.TargetFilesText.Add(Path.GetFileName(filePath));
                }
            }

            script.TargetFilesCount = script.TargetFilesText.Count;
            script.TargetFilesText = script.TargetFilesText.Distinct().ToList();
            script.TargetFilesTip = sb.ToString();
        }
    }
}