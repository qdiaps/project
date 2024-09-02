using Architecture.Factory;
using Configs;
using UnityEngine;
using VContainer;

namespace Architecture.Game
{
    public class MainEntryPoint : MonoBehaviour
    {
        [SerializeField] private int _indexCurrentScene;
        
        private PlayerFactory _playerFactory;
        private GameConfig _config;

        [Inject]
        private void Construct(PlayerFactory playerFactory, GameConfig config)
        {
            _playerFactory = playerFactory;
            _config = config;
            Init();
        }

        private void Init()
        {
            CreatePlayer();
        }

        private void CreatePlayer() => 
            _playerFactory.Create(_config.LevelConfigs[_indexCurrentScene].PlayerSpawnPoint.position, Quaternion.identity);
    }
}