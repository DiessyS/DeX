using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeX.services
{
    public static class FileService
    {
        private const string AllowedExtension = "*.mp3";

        private static bool IsFileAllowed(string path)
        {
            return path.EndsWith(AllowedExtension);
        }
        
        public static List<string> GetFiles(string path)
        {
            var files = Directory.EnumerateFiles(path, AllowedExtension, SearchOption.AllDirectories);
            return files.ToList();
        }
    }
}