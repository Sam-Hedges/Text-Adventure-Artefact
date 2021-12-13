using System;
using System.IO;
using System.Text.RegularExpressions;
using Artefact.Utilities;

namespace Artefact.ScriptSettings
{
    public static class StringFormatter
    {

        const string REGEX_PATTERN = @"(\[[^\W*]*\])([^\[]*[\]]*)(\[[^\W*]*\])?";
        static readonly char[] SQR_BR = { '[', ']' };

        public static void ColourText(string text)
        {
            using (StringReader reader = new StringReader(text))
            {
                string line = string.Empty;

                while (true)
                {
                    line = reader.ReadLine();
                    if (line == null) { break; }

                    string[] captureGroups = Regex.Split((line), REGEX_PATTERN);
                    int lineLengthWithoutSqrB = LineLengthWithoutSquareBrackets(captureGroups);

                    Utils.CenterCursor(lineLengthWithoutSqrB);

                    foreach (string group in captureGroups)
                    {
                        string tempGroup = group;
                        bool container = group.StartsWith("[") && group.EndsWith("]");

                        if (container)
                        {
                            tempGroup = group.Trim(SQR_BR);
                            if (!string.IsNullOrEmpty(tempGroup.Trim())) { Console.ForegroundColor = SetConsoleTextColour(tempGroup); }
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

        private static int LineLengthWithoutSquareBrackets(string[] input)
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

        private static ConsoleColor SetConsoleTextColour(string containerColour)
        {
            bool viableColour = Enum.TryParse(containerColour, true, out ConsoleColor parsedEnumVal);

            if (viableColour) { return parsedEnumVal; }

            return ConsoleColor.White; // Defaults to white in colour can't be parsed
        }
    }
}
