using System;
using System.IO;
using System.Threading;
using static System.Console;

namespace TextAdventureGame
{
    interface WriteLineCentered
    {
    }

    static class ClassExtensions
    {
        public static void WriteLineCentered(this WriteLineCentered obj, string text, bool printAnim = false)
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
                        if (printAnim)
                        {
                            for (int i = 0; i < line.Length; i++)
                            {
                                Write(line[i]);
                                Thread.Sleep(1);
                            }
                            WriteLine();
                        } else
                        {
                            WriteLine(line);
                        }
                    }
                } while (line != null);
            }
        }
    }
}
