using System;
using System.IO;

namespace Artefact
{
    class Dir
    {
        public string[] Start(string[] searchFields)
        {
            string path = Directory.GetCurrentDirectory();

            string[] directories = new string[searchFields.Length];

            for (int i = 0; i < searchFields.Length; i++)
            {
                directories[i] = ProcessDirectory(path, searchFields[i]);
            }

            return directories;
        }

        private string ProcessDirectory(string directory, string target)
        {
            string path = directory;
            string[] fileEntries;
            string finalPath = "";

            do
            {
                fileEntries = Directory.GetFiles(path);

                if (Directory.GetParent(path) != null) { path = Directory.GetParent(path).FullName; }
                else { return "Out of Directory Bounds"; }

                foreach (string fileName in fileEntries)
                {
                    if (fileName.Contains(target) == true)
                    {
                        finalPath = fileName;
                        break; //Breaks the foreach loop when the condition is true
                    }
                }

            } while (finalPath.Contains(target) != true);

            return finalPath;
        }
    }
}
