using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Pfade zu den Installationsdateien
        string winrarInstaller = @"C:\Users\Anatolius\source\repos\IDP\DefaltPrograms\WinRar.exe"; // Ersetze den Pfad durch den tatsächlichen Pfad zur WinRAR-Installationsdatei
        string notepadppInstaller = @"C:\Users\Anatolius\source\repos\IDP\DefaltPrograms\NotePlus.exe"; // Ersetze den Pfad durch den tatsächlichen Pfad zur Notepad++-Installationsdatei

        // WinRAR Installation
        InstallProgram(winrarInstaller, "/S");

        // Notepad++ Installation
        InstallProgram(notepadppInstaller, "/S");

        Console.WriteLine("WinRAR und Notepad++ wurden erfolgreich installiert.");
    }

    static void InstallProgram(string filePath, string arguments)
    {
        if (File.Exists(filePath))
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = filePath;
                process.StartInfo.Arguments = arguments; // Argumente für stille Installation
                process.Start();
                process.WaitForExit(); // Warten bis die Installation abgeschlossen ist
                Console.WriteLine($"{Path.GetFileName(filePath)} wurde installiert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler bei der Installation von {Path.GetFileName(filePath)}: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"{filePath} existiert nicht.");
        }
    }
}
