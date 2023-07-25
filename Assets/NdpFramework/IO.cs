using System;
using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Assets.NdpFramework
{
    // ReSharper disable once InconsistentNaming
    public static class IO
    {
        private static void ValidatePath(string path)
        {
            if (path.ToLower().EndsWith(".cs") || path.ToLower().EndsWith(".dll"))
                throw new Exception("Access is denied");
        }

        public static string ReadAllText(string path)
        {
            ValidatePath(path);
            return File.ReadAllText(path);
        }
        
        public static byte[] ReadAllBytes(string path)
        {
            ValidatePath(path);
            return File.ReadAllBytes(path);
        }

        public static string[] ReadAllLines(string path)
        {
            ValidatePath(path);
            return File.ReadAllLines(path);
        }

        public static async Task<string> ReadAllTextAsync(string path)
        {
            ValidatePath(path);
            return await File.ReadAllTextAsync(path);
        }

        public static async Task<string[]> ReadAllLinesAsync(string path)
        {
            ValidatePath(path);
            return await File.ReadAllLinesAsync(path);
        }
        
        public static async Task<byte[]> ReadAllBytesAsync(string path)
        {
            ValidatePath(path);
            return await File.ReadAllBytesAsync(path);
        }
        

        public static void WriteAllText(string path, string content)
        {
            ValidatePath(path);
            File.WriteAllText(path, content);
        }

        public static void WriteAllLines(string path, string[] content)
        {
            ValidatePath(path);
            File.WriteAllLines(path, content);
        }

        public static async Task WriteAllTextAsync(string path, string content)
        {
            ValidatePath(path);
            await File.WriteAllTextAsync(path, content);
        }

        public static async Task WriteAllLinesAsync(string path, string[] content)
        {
            ValidatePath(path);
            await File.WriteAllLinesAsync(path, content);
        }

        public static void WriteAllBytes(string path, byte[] content)
        {
            ValidatePath(path);
            File.WriteAllBytes(path, content);
        }
        
        public static async Task WriteAllBytesAsync(string path, byte[] content)
        {
            ValidatePath(path);
            await File.WriteAllBytesAsync(path, content);
        }
        
        public static FileStream Open(string path, FileMode mode)
        {
            ValidatePath(path);
            return new FileStream(path, mode);
        }
    }
}