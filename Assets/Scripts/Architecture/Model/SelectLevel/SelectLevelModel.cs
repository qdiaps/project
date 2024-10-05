using Architecture.Model.Level;
using Configs;

namespace Architecture.Model.SelectLevel
{
    public class SelectLevelModel : IModel<SelectLevelData>
    {
        private readonly GameConfig _config;

        private int _currentLevel;

        public SelectLevelModel(GameConfig config, IModel<LevelData> levelModel)
        {
            _config = config;
            _currentLevel = levelModel.Read().CurrentLevelData.CurrentLevel;
        }
        
        public SelectLevelData Read() => 
            new(_currentLevel);

        public void Update(SelectLevelData data)
        {
            if (data.Current > 0 || data.Current < _config.LevelConfigs.Length)
                _currentLevel = data.Current;
        }
    }
}