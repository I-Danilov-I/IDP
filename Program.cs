using Serilog;
using System.Diagnostics;

namespace IDP
{
    class Program
    {
        static void Main()
        {
            LoggerService.Initialize();
            Log.Information("Program start."); // Direktes Logging mit Serilog

            // Vom Debug-Verzeichnis zum Projektverzeichnis wechseln
            string? projectDirectory = GetProjectDirectory();

            if (string.IsNullOrEmpty(projectDirectory))
            {
                Log.Warning("Projektverzeichnis konnte nicht gefunden werden.");
                return; // Beenden, da das Projektverzeichnis benötigt wird
            }
       
            // Dynamische Pfade zu den Installationsdateien im "DefaultPrograms"-Ordner im Projektverzeichnis
            string winrarInstaller = Path.Combine(projectDirectory, "DefaltPrograms\\WinRar.exe");
            string notepadppInstaller = Path.Combine(projectDirectory, "DefaltPrograms\\NotePlus.exe");
            // WinRAR Installation
            InstallProgram(winrarInstaller, "/S");

            // Notepad++ Installation
            InstallProgram(notepadppInstaller, "/S");
            Log.Information("Program end."); // Direktes Logging mit Serilog
        }

        static string? GetProjectDirectory()
        {
            // Startpfad ist das aktuelle Basisverzeichnis
            string? currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            while (currentDirectory != null)
            {
                // Überprüfen, ob eine .csproj-Datei im aktuellen Verzeichnis vorhanden ist
                if (Directory.GetFiles(currentDirectory, "*.csproj").Length > 0)
                {
                    return currentDirectory; // Projektverzeichnis gefunden
                }

                // Eine Ebene nach oben gehen
                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            }

            // Projektverzeichnis wurde nicht gefunden
            return null;
        }

        static void InstallProgram(string filePath, string arguments)
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

