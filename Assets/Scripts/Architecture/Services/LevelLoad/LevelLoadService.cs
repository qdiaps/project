using System;
using Architecture.Model;
using Architecture.Model.Level;
using Configs;
using UnityEngine.SceneManagement;

namespace Architecture.Services.LevelLoad
{
    public class LevelLoadService : ILevelLoadService
    {
        private readonly IModel<LevelData> _levelModel;
        private readonly GameConfig _config;

        public LevelLoadService(IModel<LevelData> levelModel, GameConfig config)
        {
            _levelModel = levelModel;
            _config = config;
        }
        
        public void LoadLevel(int index)
        {
            var indexLevel = GetLevelIndex(index);
            if (indexLevel == -1)
                throw new ArgumentException("index out of range");
            _levelModel.Update(new LevelData(new CurrentLevelData(indexLevel)));
            SceneManager.LoadScene(index);
        }

        public void LoadNextLevel()
        {
            var nextLevelIndex = _levelModel.Read().CurrentLevelData.CurrentLevel + 1;
            if (nextLevelIndex == _config.LevelConfigs.Length)
                LoadLevel(_config.LevelConfigs[0].BuildIndexScene);
            else
                LoadLevel(_config.LevelConfigs[nextLevelIndex].BuildIndexScene);
        }

        public void LoadLastLevelFromSave() => 
            LoadLevel(_config.LevelConfigs[0].BuildIndexScene);

        private int GetLevelIndex(int index)
        {
            for (int i = 0; i < _config.LevelConfigs.Length; i++)
            {
                if (_config.LevelConfigs[i].BuildIndexScene == index)
                    return i;
            }

            return -1;
        }
    }
}