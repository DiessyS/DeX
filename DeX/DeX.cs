using System;
using System.Collections.Generic;
using DeX.services;

namespace DeX
{
    internal class DeX
    {
        public static void Main(string[] args)
        {
            var path = "C:\\Users\\Diessy\\Downloads\\Robert_Camero";
            
            //var root = args[0];
            var dex = new DexProcessor();
            var files = FileService.GetFiles(path);
            
            foreach (var file in files)
            {
                try
                {
                    dex.Process(file);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + file);
                }
            }
        }
    }
}