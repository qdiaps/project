using Architecture.Factory;
using Configs.Level;
using UnityEngine;
using VContainer;

namespace Architecture.Game
{
    public class MainEntryPoint : MonoBehaviour
    {
        [SerializeField] private LevelConfig _levelConfig;
        
        private PlayerFactory _playerFactory;

        [Inject]
        private void Construct(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            Init();
        }

        private void Init()
        {
            CreatePlayer();
        }

        private void CreatePlayer() => 
            _playerFactory.Create(_levelConfig.PlayerSpawnPoint.position, Quaternion.identity);
    }
}