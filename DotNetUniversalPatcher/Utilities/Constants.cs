using System;
using System.IO;
using System.Reflection;

namespace DotNetUniversalPatcher.Utilities
{
    internal static class Constants
    {
        internal static readonly string MainDir = AppDomain.CurrentDomain.BaseDirectory;

        internal static readonly string PatchersDirName = "Patchers";
        internal static readonly string PatchersDir = Path.Combine(MainDir, PatchersDirName);

        internal static readonly string Title = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
        internal static readonly string Version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>().Version;

        internal static readonly string TitleAndVersion = $"{Title} v{Version.Substring(0, Version.IndexOf('.', 2))}";

        internal static readonly string ScriptFileExtension = "dnup";

        internal static readonly char DefaultSeparator = '|';
        internal static readonly string RangeExpressionSeparator = "...";
        internal static readonly string RangeExpressionRegexPattern = @"\.\.\.";

        internal static readonly string PlaceholderPattern = "(?<!#)(#[^#]+#)(?!#)";
        internal static readonly string ScriptFilePattern = $"*.{ScriptFileExtension}";
    }
}