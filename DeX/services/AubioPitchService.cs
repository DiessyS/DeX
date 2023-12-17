namespace DeX.services
{
    public class AubioPitchService
    {
        private const string AubioPitchCmd = "aubiopitch";
        
        private static string Calling(string path)
        {
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = AubioPitchCmd;
            process.StartInfo.Arguments = "-i " + path + " -r 44100";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            
            var output = process.StandardOutput.ReadToEnd();
            process.Close();

            return output;
        }
        
        
        public static string ExtractPitch(string path)
        {
            var output = Calling(path);
            return "AubioPitchService";
        }
    }
}