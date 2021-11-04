using System;
using System.IO;
using System.Text.RegularExpressions;
using Artefact.Utilities;

namespace Artefact.ScriptSettings
{
    public static class StringFormatter
    {

        const string REGEX_PATTERN = @"(\[[^\W*]*\])([^\[]*[\]]*)(\[[^\W*]*\])?";
        static readonly char[] SQR_BR = new char[] { '[', ']' };

        public static void Test(Scripts script)
        {
            string[] captureGroups = Regex.Split(File.ReadAllText(Directories.ReturnDir(script)), REGEX_PATTERN);
            foreach (string group in captureGroups)
            {
                string tempGroup = group;
                bool container = group.StartsWith("[") && group.EndsWith("]");

                if (container)
                {
                    tempGroup = group.Trim(SQR_BR);
                    if (!string.IsNullOrEmpty(tempGroup.Trim())) { Console.ForegroundColor = ConsoleColor.Green; }
                    else { Console.ResetColor(); }
                    continue;
                }

                Utils.WriteLineAdvanced(tempGroup);
                Console.ResetColor();
            }
        }
    }

}
