using System.Collections.Concurrent;

namespace MultiThread.Core;

public static class FileOperations
{
    public static byte[] ReadBytes(string sourceFile,int readableBytesNumber)
    {
        if (!File.Exists(sourceFile))
        {
            throw new FileNotFoundException(@"The specified file could not be found or does not exist.: "+sourceFile);
        }
        using (FileStream fs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            readableBytesNumber= (int)Math.Min(readableBytesNumber, fs.Length); 
            byte[] readBytes = new byte[readableBytesNumber];
            int numberOfReadBytes =fs.Read(readBytes, 0, readableBytesNumber);
            if (numberOfReadBytes < readableBytesNumber)
            {

                Array.Resize(ref readBytes, numberOfReadBytes);
            }
            return readBytes; 
        }
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