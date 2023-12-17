using System;
using DeX.models;

namespace DeX.services
{
    public class SampleSlicerService
    {
        private float[] _audioBuffer;
        
        public bool IsAudioLoaded()
        {
            return _audioBuffer != null;
        }
        
        public void LoadAudio(string path)
        {
            try
            {
                _audioBuffer = AudioService.ReadMp3(path);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error loading audio");
                Console.WriteLine("Path: " + path);
                Console.WriteLine();
                Console.ResetColor();
            }
        }
        
        public void UnloadAudio()
        {
            _audioBuffer = null;
        }
    }
}