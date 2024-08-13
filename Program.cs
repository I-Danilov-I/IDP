using Serilog;
using System.Diagnostics;

namespace IDP
{
    class Program
    {
        static void Main()
        {
            LoggerService.Initialize();
            Log.Information("Program start.");

            string projectDirectory = GetProjectDirectory.GetProjectDirectoryPath();

            string winrarInstaller = Path.Combine(projectDirectory, "DefaltPrograms\\WinRar.exe");
            string notepadppInstaller = Path.Combine(projectDirectory, "DefaltPrograms\\NotePlus.exe");

            InstallProgramms.InstallProgram(winrarInstaller, "/S");
            InstallProgramms.InstallProgram(notepadppInstaller, "/S");

            Log.Information("Program end."); 
        }
    }
}

