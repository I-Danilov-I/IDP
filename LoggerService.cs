﻿using Serilog;

namespace IDP
{
    public class LoggerService
    {
        static LoggerService()
        {
            // Logger-Konfiguration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // Setzt das minimale Log-Level
                .WriteTo.Console() // Ausgabe der Logs in die Konsole
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Ausgabe der Logs in eine Datei, die täglich rotiert
                .CreateLogger();
        }
        public static void Initialize()
        {
            Log.Information("Logger wurde initialisiert.");
        }
    }
}