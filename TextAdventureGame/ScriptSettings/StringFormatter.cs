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
            using (StringReader reader = new StringReader(File.ReadAllText(Directories.ReturnDir(script))))
            {
                string line = string.Empty;

                while (true)
                {
                    line = reader.ReadLine();
                    if (line == null) { break; }

                    string[] captureGroups = Regex.Split((line), REGEX_PATTERN);
                    int pureLineLength = PureLineLength(captureGroups);

                    Utils.CenterCursor(pureLineLength);

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

                        Utils.WriteAdvanced(tempGroup);
                        Console.ResetColor();
                    }

                    Console.WriteLine();
                }            
            }
        }

        private static int PureLineLength(string[] input)
        {
            int lineCount = 0;

            foreach (string group in input)
            {
                bool container = group.StartsWith("[") && group.EndsWith("]");

                if (container) { continue; }

                lineCount += group.Length;
            }

            return lineCount;
        }
    }
}
