using System.Collections.Generic;
using DeX.services;

namespace DeX
{
    internal class DeX
    {
        public static void Main(string[] args)
        {
            var root = args[0];
            var dex = new DexProcessor();
            var files = FileService.GetFiles(root);
            
            foreach (var file in files)
            {
                dex.Process(file);
            }
        }
    }
}