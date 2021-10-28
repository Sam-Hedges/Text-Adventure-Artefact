using System;

namespace Artefact
{
    enum Scripts
    {
        Story,
        Options,
        Fights
    }
    static class Directories
    {

        private const string STORY = "/Script/Story.txt";
        private const string OPTIONS = "/Script/Options.txt";
        private const string FIGHTS = "/Script/Fights.txt";

        public static string ReturnDir(Scripts script)
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();

            switch (script)
            {
                case Scripts.Story:
                    return ProcessDirectory(System.IO.Directory.GetCurrentDirectory(), STORY);
                case Scripts.Options:
                    return ProcessDirectory(currentDirectory, OPTIONS);
                case Scripts.Fights:
                    return ProcessDirectory(currentDirectory, FIGHTS);
                default:
                    throw new Exception("Not Valid Directory");
            }
        }

        public static string[] Start(string[] searchFields)
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();

            string[] directories = new string[searchFields.Length];

            for (int i = 0; i < searchFields.Length; i++)
            {
                //directories[i] = ProcessDirectory(path, searchFields[i]);
            }

            return directories;
        }

        private static string ProcessDirectory(string directory, string target)
        {
            string path = directory;
            string[] fileEntries;
            string finalPath = "";

            do
            {

                fileEntries = System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory() + STORY);

                if (System.IO.Directory.GetParent(path) != null) { path = System.IO.Directory.GetParent(path).FullName; }
                else { return "Out of Directory Bounds"; }

                foreach (string fileName in fileEntries)
                {
                    if (fileName.Contains(target))
                    {
                        finalPath = fileName;
                        break; //Breaks the foreach loop when the condition is true
                    }
                }

            } while (!finalPath.Contains(target));

            return finalPath;
        }
    }
}
