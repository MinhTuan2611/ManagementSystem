using System;
using System.IO;

public class ErrorLogger
{
    private string logFilePath;

    public ErrorLogger(string logFilePath)
    {
        this.logFilePath = logFilePath;
    }

    public void LogError(string errorMessage)
    {
        try
        {
            // Create or open the log file for appending
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine($"[Error] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {errorMessage}");
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions related to logging, e.g., console output
            Console.WriteLine($"Error logging failed: {ex.Message}");
        }
    }
}