using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fox
{
    // Base databases contain [strings] then [hashes]; user databases contain only [strings].
    public sealed class StringIdDatabase
    {
        public readonly Dictionary<string, string> Strings = new Dictionary<string, string>();
        public readonly HashSet<string> Hashes = new HashSet<string>();

        public static StringIdDatabase Read(string path, StringDatabaseType databaseType)
        {
            using StreamReader reader = new StreamReader(path, Encoding.ASCII);
            if (reader.ReadLine() != "[strings]")
                throw new InvalidDataException($"{path}: expected [strings] on the first line.");

            StringIdDatabase database = new StringIdDatabase();
            
            bool isProcessingHashes = false;
            int lineNumber = 1;
            while (reader.ReadLine() is { } line)
            {
                lineNumber++;
                
                if (line.Length == 0)
                    continue;
                
                if (line == "[hashes]" && databaseType == StringDatabaseType.Base && !isProcessingHashes)
                {
                    isProcessingHashes = true;
                    continue;
                }

                string[] fields = line.Split('\t');
                string hash = fields[0].ToLowerInvariant();
                bool validHash = StrCode.IsHash(hash);

                if (!validHash || fields.Length != (isProcessingHashes ? 1 : 2))
                    throw new InvalidDataException($"{path}:{lineNumber}: malformed database entry.");

                hash = new StrCode(hash).ToString();
                if (database.Strings.ContainsKey(hash) || database.Hashes.Contains(hash))
                    throw new InvalidDataException($"{path}:{lineNumber}: duplicate hash {hash}.");
                
                if (isProcessingHashes)
                    database.Hashes.Add(hash);
                else
                    database.Strings.Add(hash, fields[1]);
            }

            if (databaseType == StringDatabaseType.Base && !isProcessingHashes)
                throw new InvalidDataException($"{path}: missing [hashes] section.");
            
            return database;
        }

        public void Write(string path, StringDatabaseType databaseType)
        {
            using StreamWriter writer = new StreamWriter(path, false, Encoding.ASCII);
            writer.WriteLine("[strings]");
            foreach (KeyValuePair<string, string> entry in Strings)
                writer.WriteLine($"{entry.Key}\t{entry.Value}");
            
            if (databaseType == StringDatabaseType.Base)
            {
                writer.WriteLine();
                writer.WriteLine("[hashes]");
                foreach (string hash in Hashes)
                    writer.WriteLine(hash);
            }
        }

    }
}
