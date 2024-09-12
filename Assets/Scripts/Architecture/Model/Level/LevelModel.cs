using Architecture.Services.Storage;
using Configs;

namespace Architecture.Model.Level
{
    public class LevelModel : IModel<LevelData>
    {
        private readonly IStorageService _storageService;
        private readonly GameConfig _config;

        private int _allLevels;
        private int _currentLevel;
        private int _lastCompletedLevel;
        
        public LevelModel(IStorageService storageService, GameConfig config)
        {
            _storageService = storageService;
            _config = config;
            LoadAllData();
        }

        public LevelData Read() => 
            new(new CurrentLevelData(_currentLevel), new CompletedLevelData(_lastCompletedLevel));

        public void Update(LevelData data)
        {
            var canSave = false;
            if (data.CurrentLevelData != null)
                canSave = ValidateCurrentLevelData(data.CurrentLevelData);

            if (data.CompletedLevelData != null)
                CheckSave(ValidateCompletedLevelData(data.CompletedLevelData));

            void CheckSave(bool value)
            {
                if (value == false)
                    return;
                canSave = true;
            }
            
            if (canSave)
                Save();
        }

        private void LoadAllData()
        {
            _allLevels = _config.LevelConfigs.Length;
            var level = _storageService.Deserialize<LevelData>() ?? 
                        new LevelData(new CurrentLevelData(0), new CompletedLevelData(-1));
            _currentLevel = level.CurrentLevelData.CurrentLevel;
            _lastCompletedLevel = level.CompletedLevelData.LastCompletedLevel;
        }

        private bool ValidateCurrentLevelData(CurrentLevelData data)
        {
            var currentLevel = data.CurrentLevel;
            if (currentLevel >= 0 && currentLevel < _allLevels && currentLevel != _currentLevel)
            {
                _currentLevel = currentLevel;
                return true;
            }

            return false;
        }

        private bool ValidateCompletedLevelData(CompletedLevelData data)
        {
            var lastCompletedLevel = data.LastCompletedLevel;
            if (lastCompletedLevel > _lastCompletedLevel && lastCompletedLevel < _allLevels)
            {
                _lastCompletedLevel = lastCompletedLevel;
                return true;
            }
            
            return false;
        }

        private void Save() => 
            _storageService.Serialize(Read());
    }
}