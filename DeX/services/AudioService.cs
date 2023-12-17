using System.Collections.Generic;
using NAudio.Wave;

namespace DeX.services
{
    public class AudioService
    {
        public static float[] ReadMp3(string path)
        {
            var reader = new Mp3FileReader(path);
            var sampleProvider = reader.ToSampleProvider();
            var buffer = new float[reader.WaveFormat.SampleRate];
            sampleProvider.Read(buffer, 0, buffer.Length);
            return buffer;
        }
        
        public static void WriteMp3(string path, float[] buffer)
        {
            var writer = new WaveFileWriter(path, new WaveFormat(44100, 16, 2));
            writer.WriteSamples(buffer, 0, buffer.Length);
            writer.Dispose();
        }
    }
}