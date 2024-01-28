using System.Collections.Generic;
using NAudio.Wave;

namespace DeX.services
{
    public static class AudioService
    {
        public static int[] ReadMp3(string path)
        {
            Mp3FileReader reader = new Mp3FileReader(path);
            //exctrac pcm data from mp3 stream
            var buffer = new List<int>();
            var readBuffer = new byte[reader.WaveFormat.AverageBytesPerSecond];
            
            Mp3WaveFormat waveFormat = reader.Mp3WaveFormat;
            var sampleProvider = reader.ToSampleProvider();
            var sampleBuffer = new float[reader.WaveFormat.SampleRate * reader.WaveFormat.Channels];
            
            
        }
        
        public static void WriteMp3(string path, float[] buffer)
        {
            var writer = new WaveFileWriter(path, new WaveFormat(44100, 16, 2));
            writer.WriteSamples(buffer, 0, buffer.Length);
            writer.Dispose();
        }
    }
}