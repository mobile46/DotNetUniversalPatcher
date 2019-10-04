using DotNetUniversalPatcher.UI;

namespace DotNetUniversalPatcher.Utilities
{
    public class Logger : ILogger
    {
        internal static readonly ILogger Instance = new Logger();

        public void Log(string text, LoggerLevel loggerEvent)
        {
            if (text == string.Empty)
            {
                AddEmptyLine();
            }
            else
            {
                switch (loggerEvent)
                {
                    case LoggerLevel.Info:
                        text = $"[?] {text}";
                        break;

                    case LoggerLevel.Error:
                        text = $"[!] {text}";
                        break;
                }

                FrmMain.Instance.lstLog.Items.Add(text);
            }

            FrmMain.Instance.lstLog.SelectedIndex = FrmMain.Instance.lstLog.Items.Count - 1;
        }

        internal static void Log()
        {
            Instance.Log(string.Empty, LoggerLevel.None);
        }

        internal static void Log(string text)
        {
            Instance.Log(text, LoggerLevel.None);
        }

        internal static void Error(string text)
        {
            Instance.Log(text, LoggerLevel.Error);
        }

        internal static void Info(string text)
        {
            Instance.Log(text, LoggerLevel.Info);
        }

        internal static void ClearLogs()
        {
            FrmMain.Instance.lstLog.Items.Clear();
        }

        private static void AddEmptyLine()
        {
            if ((string)FrmMain.Instance.lstLog.Items[FrmMain.Instance.lstLog.Items.Count - 1] != string.Empty)
            {
                FrmMain.Instance.lstLog.Items.Add(string.Empty);
            }
        }
    }
}