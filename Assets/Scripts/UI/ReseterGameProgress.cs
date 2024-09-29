using System.IO;
using Architecture.Model.Level;
using UnityEngine;

namespace UI
{
    public class ReseterGameProgress : MonoBehaviour
    {
        public void ResetProgress()
        {
            var path = CreatePath(typeof(LevelData).ToString());
            if (File.Exists(path))
                File.Delete(path);
        }
        
        private string CreatePath(string name) =>
            Path.Combine(Application.persistentDataPath, $"{name}.json");
    }
}