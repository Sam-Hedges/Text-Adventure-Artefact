using System;
using static System.Console;
using System.IO;
using System.Text.RegularExpressions;
using Artefact.Utilities;

namespace Artefact
{
    public static class StringFormatter
    {

        const string REGEX_PATTERN = @"((\[[^\W*]*\])([^\[]*[\]]*)(\[[^\W*]*\])?)";

        public static void test(string filePath)
        {
            string[] pieces = Regex.Split(File.ReadAllText(filePath), REGEX_PATTERN);
            foreach (string piece in pieces)
            {
                Utils.WriteLineAdvanced(piece);
            }
        }
    }

}
