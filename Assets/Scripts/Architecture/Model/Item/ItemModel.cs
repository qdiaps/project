using Architecture.Model.Level;
using Configs;

namespace Architecture.Model.Item
{
    public class ItemModel : IModel<ItemData>
    {
        private readonly GameConfig _config;
        private readonly int _allKeyCount;

        private int _currentKeyCount;

        public ItemModel(GameConfig config, IModel<LevelData> levelModel)
        {
            var currentLevel = levelModel.Read().CurrentLevelData.CurrentLevel;
            _allKeyCount = config.LevelConfigs[currentLevel].KeySpawnPoints.Length;
        }

        public ItemData Read() => 
            new(new KeyData(_currentKeyCount));

        public void Update(ItemData data)
        {
            if (_currentKeyCount < data.KeyData.CurrentCount && _allKeyCount >= data.KeyData.CurrentCount)
                _currentKeyCount = data.KeyData.CurrentCount;
        }
    }
}