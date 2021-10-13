using System;
using static System.Console;
using System.Text.RegularExpressions;
using static System.Utils;

namespace Artefact.Misc
{
    class StringFormatter
    {

        const string REGEX_PATTERN = @"(\[[^\/\W][^\]]*\])";

        public void test()
        {
            string[] pieces = Regex.Split("[green]the fox was epic[e] gay man freedom sex with the animals fox furries die [red]asdfasdfasd[e]", @"(\[[^\/\W][^\]]*\])");
            foreach (string piece in pieces)
            {
                WriteLineAdvanced(piece);
            }
        }
    }

}
