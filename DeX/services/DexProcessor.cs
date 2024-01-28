using System;
using System.Collections.Generic;
using System.Linq;
using NAudio.Dsp;

namespace DeX.services
{
    public class DexProcessor
    {
        private const int SampleRate = 44100;
        private const int FrameSize = SampleRate * 1;
        private float[] _audioBuffer;
        private string outputFolder = "output";

        public void Process(string audioPath)
        {
            if (!LoadAudio(audioPath))
            {
                return;
            }
            
            var filtered = Filter(_audioBuffer);
            var threshold = GetThreshold(filtered);
            SearchAndCut(filtered, _audioBuffer, threshold);
        }
        
        private void SearchAndCut(float[] filtered, float[] buffer, float threshold)
        {
            var chance = 0.02f;
            var fallbackFrames = 64;
            var frames = new float[FrameSize];
            
            for (var i = 0; i < filtered.Length; i++)
            {
                if(filtered[i] > threshold && (new Random().NextDouble() < chance))
                {
                    i = i > fallbackFrames ? i - fallbackFrames : 0;
                    
                    Array.Copy(
                        buffer, 
                        i, 
                        frames, 
                        0, 
                        FrameSize
                    );
                    
                    AudioService.WriteMp3(
                        outputFolder + "/" + Guid.NewGuid() + ".mp3", 
                        frames
                    );
                    i += FrameSize;
                }
            }
        }
        
        private float GetThreshold(float[] buffer)
        {
            var highPeak = GetHighPeak(buffer);
            return highPeak * 0.86f;
        }
        
        private float GetHighPeak(float[] buffer)
        {
            return buffer.Select(Math.Abs).Prepend(0f).Max();
        }
        
        private float [] Filter(IReadOnlyList<float> buffer)
        {
            var output = new float[buffer.Count];
            var r = BiQuadFilter.LowPassFilter(44100, 10000, 1);

            for(var i = 0; i < buffer.Count; i++)
            {
                output[i] = r.Transform(buffer[i]);
            }
            
            return output;
        }
        
        private bool LoadAudio(string path)
        {
            try {
                _audioBuffer = AudioService.ReadMp3(path);
                return true;
            }
            catch {
                Console.WriteLine("Error loading audio: " + path);
                return false;
            }
        }
    }
}