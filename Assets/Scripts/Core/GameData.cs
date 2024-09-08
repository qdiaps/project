using Architecture.Services.Storage;

namespace Core
{
    public class GameData
    {
        private readonly IStorageService _storage;

        public GameData(IStorageService storage)
        {
            _storage = storage;
        }
    }
}