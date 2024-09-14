using System.IO;
using Architecture.Services.Stream;
using Newtonsoft.Json;
using UnityEngine;

namespace Architecture.Services.Storage
{
    public class JsonStorageService : IStorageService
    {
        private readonly IStreamService _streamService;

        public JsonStorageService(IStreamService streamService) => 
            _streamService = streamService;


        public void Serialize(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var path = CreatePath(data.GetType().ToString());
            _streamService.Save(json, path);
            Debug.Log("Serialize successful!");
        }

        public T Deserialize<T>()
        {
            var path = CreatePath(typeof(T).ToString());
            var data = _streamService.Load(path);
            if (data == null)
                return default;
            Debug.Log("Deserialize successful!");
            return JsonConvert.DeserializeObject<T>((string)data);
        }

        private string CreatePath(string name) =>
            Path.Combine(Application.persistentDataPath, $"{name}.json");
    }
}