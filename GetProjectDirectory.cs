namespace IDP
{
    internal class GetProjectDirectory
    {
        internal static string GetProjectDirectoryPath()
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
            return null!;
        }
    }
}
