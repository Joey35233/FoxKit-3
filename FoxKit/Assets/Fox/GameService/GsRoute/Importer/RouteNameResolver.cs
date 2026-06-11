using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Fox;
public static class RouteNameResolver
{
    private static Dictionary<StrCode32, string> _names;
    private static Dictionary<StrCode32, string> Names => _names ??= Build();

    private static Dictionary<StrCode32, string> Build()
    {
        var map = new Dictionary<StrCode32, string>();
        foreach (var file in new[] { 
            "route_ids.txt",
            "route_ids_user.txt", 
            })
        {
            string path = System.IO.Path.Combine(Application.dataPath, "FoxKit/Tests", file);
            if (!File.Exists(path)) continue;
            foreach (string line in File.ReadLines(path))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var key = new StrCode32(line);
                map[key] = line;
            }
        }
        return map;
    }

    public static string Resolve(StrCode32 hash)
    {
        if (Names.TryGetValue(hash, out string name))
            return name;
        else
            return hash.ToString();  //0x....
    }

    public static void RegisterUserRoute(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return;

        // already known (vanilla route_ids.txt or a previously-added user route)
        if (Names.ContainsKey(new StrCode32(name)))
            return;

        // AppendAllText creates route_ids_user.txt if it doesn't exist
        string userPath = System.IO.Path.Combine(Application.dataPath, "FoxKit/Tests", "route_ids_user.txt");
        System.IO.File.AppendAllText(userPath, name + "\n");

        Names[new StrCode32(name)] = name;
    }
}