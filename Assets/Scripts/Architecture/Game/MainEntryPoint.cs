using Architecture.Factory;
using Architecture.Model;
using Architecture.Model.Level;
using Configs;
using UnityEngine;
using VContainer;

namespace Architecture.Game
{
    public class MainEntryPoint : MonoBehaviour
    {
        private int _indexCurrentLevel;
        private PlayerFactory _playerFactory;
        private GameConfig _config;

        [Inject]
        private void Construct(PlayerFactory playerFactory, GameConfig config, IModel<LevelData> levelModel)
        {
            _playerFactory = playerFactory;
            _config = config;
            _indexCurrentLevel = levelModel.Read().CurrentLevelData.CurrentLevel;
            Init();
        }

        private void Init()
        {
            CreatePlayer();
        }

        private void CreatePlayer() => 
            _playerFactory.Create(_config.LevelConfigs[_indexCurrentLevel].PlayerSpawnPoint.position, Quaternion.identity);
    }
}