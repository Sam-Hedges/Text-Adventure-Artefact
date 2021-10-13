﻿using System;
using System.IO;
using System.Threading;
using static System.Console;

namespace Artefact
{
    static class Utilities
    {
        public static void WriteLineAdvanced(string text, bool centered = true, bool printAnim = true)
        {

            using (StringReader reader = new StringReader(text))
            {

                string line = string.Empty;

                do
                {

                    line = reader.ReadLine();

                    if (line != null)
                    {

                        if (centered)
                        {
                            SetCursorPosition((WindowWidth - line.Length) / 2, CursorTop);
                        }

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

        public static float RandNumbBetwRange(float lowBound, float topBound, Type t)
        {
            Random r = new Random();
            if (t == typeof(int))
            {
                int rInt = r.Next(Convert.ToInt32(lowBound), Convert.ToInt32(topBound));
                return rInt;
            }
            else if (t == typeof(float))
            {
                float rFloat = Convert.ToSingle(r.NextDouble() * Math.Abs(topBound - lowBound)) + (0f - Math.Abs(lowBound));
                return rFloat;
            }
            else
            {
                throw new ArgumentException("Invalid Type");
            }          
        }
    }
}