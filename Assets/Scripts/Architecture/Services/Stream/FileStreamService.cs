using System.IO;
using UnityEngine;

namespace Architecture.Services.Stream
{
    public class FileStreamService : IStreamService
    {
        public void Save(object data, string path)
        {
            using var fileStream = new StreamWriter(path);
            fileStream.Write(data);
            Debug.Log("Save successful!");
        }

        public object Load(string path)
        {
            if (File.Exists(path) == false)
            {
                Debug.LogWarning("File does not exist!");
                return null;
            }

            using var fileStream = new StreamReader(path);
            Debug.Log("Load successful!");
            return fileStream.ReadToEnd();
        }
    }
}