using Serilog;
using System.Diagnostics;

namespace IDP
{
    internal class InstallProgramms
    {
        internal static void InstallProgram(string filePath, string arguments)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    Process process = new();
                    process.StartInfo.FileName = filePath;
                    process.StartInfo.Arguments = arguments; // Argumente für stille Installation
                    process.StartInfo.Verb = "runas"; // Administratorrechte anfordern
                    process.Start();
                    process.WaitForExit(); // Warten bis die Installation abgeschlossen ist
                    Log.Information($"{Path.GetFileName(filePath)} wurde installiert.");
                }
                catch (Exception ex)
                {
                    Log.Information($"Fehler bei der Installation von {Path.GetFileName(filePath)}: {ex.Message}");
                }
            }
            else
            {
                Log.Information($"{filePath} existiert nicht.");
            }
        }
    }
}
