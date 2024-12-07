using System.Collections.Concurrent;
using Serilog;

namespace MultiThread.Core;

public static class FileOperations
{
    public static byte[] ReadBytes(string sourceFile,int readableByte)
    {
        Log.Logger = new LoggerConfiguration()
        .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        byte[] fByte = new byte[readableByte];                                                             
        try
        {
            using (var fr = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read)) 
            using (var ms=new MemoryStream(fByte))    
            {
                fr.CopyTo(ms, readableByte); 
            }               
        }
        catch (Exception ex)
        {
             Log.Logger.Error(ex.Message);                            
        }
        return fByte;
    }
    public static void GetFileNames(string upperDirectory, ref BlockingCollection<string> filenames)
    {
            var directoryFilenames=Directory.GetFiles(upperDirectory);
            foreach (var filename in directoryFilenames)
            {
                if(!filenames.IsAddingCompleted)
                    filenames.Add(filename);
            }
            var directories = Directory.GetDirectories(upperDirectory);
            foreach (var directory in directories)
            {
                GetFileNames(directory, ref filenames);
            }
    }
}