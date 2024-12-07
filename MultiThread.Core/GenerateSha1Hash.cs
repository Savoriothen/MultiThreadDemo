using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

namespace MultiThread.Core;

public static class GenerateSha1Hash
{
    private static byte[] CreateSha1HashFrom(byte[] data)
    {
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] hash = sha1.ComputeHash(data);
            return hash;
        }
    }

    public static void GenerateSha1HashToDictionaryFromFileName(string fileName,
        ref ConcurrentDictionary<string, List<string>?> hashesWithFilenames,int taskId)
    {
        var data=FileOperations.ReadBytes(fileName,128);
        var hash=CreateSha1HashFrom(data);
        if (hashesWithFilenames.TryGetValue(BitConverter.ToString(hash).Replace("-", "").ToLower(),
                out List<string>? filenames))
        {
            if(filenames==null)
                filenames = new List<string>();
            filenames.Add(Path.GetFileName(fileName)+"   "+taskId);
        }
        else
        {
            hashesWithFilenames.TryAdd(BitConverter.ToString(hash).Replace("-", "").ToLower(),
                new List<string>() { Path.GetFileName(fileName)+"   "+taskId });
        }
    }
    public static string ResultStringCreator(ref ConcurrentDictionary<string, List<string>?> hashesWithFilenames)
    {
        StringBuilder sb=new StringBuilder();
        foreach (var hashesWithFilename in hashesWithFilenames)
        {
            if (hashesWithFilename.Value != null && hashesWithFilename.Value.Count > 1)
            {
                for (int i = 0; i < hashesWithFilename.Value.Count; i++)
                {
                    if (i == 0)
                        sb.AppendLine("Hash: " + hashesWithFilename.Key +
                                      Environment.NewLine +
                                      "FileName: " + hashesWithFilename.Value[i]);
                    else
                        sb.AppendLine("FileName: " + hashesWithFilename.Value[i]);
                }
                sb.AppendLine();
            }
        }
        return sb.ToString();
    }

}
