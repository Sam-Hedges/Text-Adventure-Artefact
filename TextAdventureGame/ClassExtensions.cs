using System;
using System.IO;
using static System.Console;

namespace TextAdventureGame
{
    interface WriteLineCentered
    {
    }

    static class ClassExtensions
    {
        public static void WriteLineCentered(this WriteLineCentered obj, string text)
        {
            using (StringReader reader = new StringReader(text))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        SetCursorPosition((WindowWidth - line.Length) / 2, CursorTop);
                        WriteLine(line);
                    }
                } while (line != null);
            }
        }
    }
}
