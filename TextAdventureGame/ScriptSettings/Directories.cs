using System;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Artefact.ScriptSettings
{
    public enum Scripts
    {
        Story,
        Options,
        Fights
    }

    struct Directory
    {
        public Directory(Scripts ID, string filePath)
        {
            this.ID = ID;
            this.filePath = filePath;
        }

        public Scripts ID;
        public string filePath;
    }

    static class Directories
    {
        private static bool start = false;
        private static readonly List<Directory> scripts = new List<Directory>();

        private static readonly string[] relativePaths = new string[] { @"Scripts\Story.txt", @"Scripts\Options.txt", @"Scripts\Fights.txt" };

        public static string ReturnDir(Scripts script)
        {
            if (Enum.GetNames(typeof(Scripts)).Length != relativePaths.Length) { throw new Exception("Not all relative paths or enum members have been added"); }

            if (!start) { InstantiateList(); }

            switch (script)
            {
                case Scripts.Story:
                    string storyPath = scripts.First(x => (x.ID == Scripts.Story)).filePath;
                    return storyPath;
                case Scripts.Options:
                    string optionsPath = scripts.First(x => (x.ID == Scripts.Options)).filePath;
                    return optionsPath;
                case Scripts.Fights:
                    string fightsPath = scripts.First(x => (x.ID == Scripts.Fights)).filePath;
                    return fightsPath;
                default:
                    throw new Exception("Not Valid Directory");
            }
        }

        private static void InstantiateList()
        {
            for(int i = 0; i < Enum.GetNames(typeof(Scripts)).Length; i++)
            {
                Directory temp = new Directory((Scripts)i, relativePaths[i]);
                scripts.Add(temp);
            }

            start = true;
        }

        private static string ProcessDirectory(string target)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), target);
            return path;
        }
    }
}
