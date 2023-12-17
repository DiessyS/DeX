using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeX.services
{
    public class FileService
    {
        private const string AllowedExtension = ".mp3";

        private static bool IsFileAllowed(string path)
        {
            return path.EndsWith(AllowedExtension);
        }
        
        public static List<string> GetFiles(string path)
        {
            var dir = new DirectoryInfo(path);
            var fileInfos = dir.GetFiles(AllowedExtension, SearchOption.AllDirectories);
            return (from fileInfo in fileInfos select fileInfo.FullName).ToList();
        }
    }
}