using DotNetUniversalPatcher.Engine;
using DotNetUniversalPatcher.Exceptions;
using DotNetUniversalPatcher.Utilities;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DotNetUniversalPatcher.Extensions
{
    internal static class StringExtensions
    {
        private const string HexPrefix = "0x";

        internal static string MultipleReplace(this string text)
        {
            return MultipleReplace(text, Constants.PlaceholderPattern, ScriptEngine.Placeholders);
        }

        internal static string MultipleReplace(this string text, string pattern, Dictionary<string, string> replacements)
        {
            var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

            if (matches.Count > 0)
            {
                var matchedKeys = new Dictionary<string, string>();

                foreach (Match match in matches)
                {
                    string value;

                    if (match.Success)
                    {
                        value = match.Value;
                        text = Regex.Replace(text, value, value.ToUpperInvariant());
                    }
                    else
                    {
                        break;
                    }

                    if (!matchedKeys.ContainsKey(value))
                    {
                        if (replacements.ContainsKey(value))
                        {
                            matchedKeys.Add(value.ToUpperInvariant(), replacements[value]);
                        }
                        else
                        {
                            throw new PatcherException("Placeholder not found", value);
                        }
                    }
                }

                foreach (string key in matchedKeys.Keys)
                {
                    text = Regex.Replace(text, $"(?<!#)({key})(?!#)", matchedKeys[key], RegexOptions.IgnoreCase);
                }
            }

            text = text.Replace("##", "#");

            return text;
        }

        internal static sbyte ToSByte(this string text)
        {
            sbyte result;

            if (text.ToLowerInvariant().StartsWith(HexPrefix))
            {
                sbyte.TryParse(text.Substring(2), NumberStyles.HexNumber, null, out result);
            }
            else
            {
                sbyte.TryParse(text, out result);
            }

            return result;
        }

        internal static byte ToByte(this string text)
        {
            byte result;

            if (text.ToLowerInvariant().StartsWith(HexPrefix))
            {
                byte.TryParse(text.Substring(2), NumberStyles.HexNumber, null, out result);
            }
            else
            {
                byte.TryParse(text, out result);
            }

            return result;
        }

        internal static int ToInt(this string text)
        {
            int result;

            if (text.ToLowerInvariant().StartsWith(HexPrefix))
            {
                int.TryParse(text.Substring(2), NumberStyles.HexNumber, null, out result);
            }
            else
            {
                int.TryParse(text, out result);
            }

            return result;
        }

        internal static long ToLong(this string text)
        {
            long result;

            if (text.ToLowerInvariant().StartsWith(HexPrefix))
            {
                long.TryParse(text.Substring(2), NumberStyles.HexNumber, null, out result);
            }
            else
            {
                long.TryParse(text, out result);
            }

            return result;
        }

        internal static double ToDouble(this string text)
        {
            double result;

            if (text.ToLowerInvariant().StartsWith(HexPrefix))
            {
                double.TryParse(text.Substring(2), NumberStyles.HexNumber, null, out result);
            }
            else
            {
                double.TryParse(text, out result);
            }

            return result;
        }

        internal static float ToFloat(this string text)
        {
            float result;

            if (text.ToLowerInvariant().StartsWith(HexPrefix))
            {
                float.TryParse(text.Substring(2), NumberStyles.HexNumber, null, out result);
            }
            else
            {
                float.TryParse(text, out result);
            }

            return result;
        }
    }
}