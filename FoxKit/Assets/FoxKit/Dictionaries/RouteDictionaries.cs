using Fox;
using Fox.GameService;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FoxKit
{
    [InitializeOnLoad]
    public static class RouteDictionaries
    {
        private static readonly string DictionaryDirectory = System.IO.Path.Combine(Application.dataPath, "FoxKit", "Dictionaries");

        static RouteDictionaries()
        {
            Load();
        }

        public static void Load()
        {
            if (!Directory.Exists(DictionaryDirectory))
                return;

            foreach (string path in Directory.GetFiles(DictionaryDirectory, "*.txt"))
            {
                foreach (string line in File.ReadLines(path))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        GameServiceModule.RegisterString(line);
                }
            }
        }

        public static void RegisterUserRoute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            if (GameServiceModule.IsStringKnown(new StrCode32(name)))
                return;

            string userPath = System.IO.Path.Combine(DictionaryDirectory, "route_ids_user.txt");
            File.AppendAllText(userPath, name + "\n");
            GameServiceModule.RegisterString(name);
        }
    }
}
