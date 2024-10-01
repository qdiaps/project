using System;
using Architecture.Factory;
using Architecture.Model;
using Architecture.Model.Level;
using Configs;
using Core.Hint;
using UnityEngine;
using VContainer;

namespace Architecture.Game
{
    public class MainEntryPoint : MonoBehaviour
    {
        private int _indexCurrentLevel;
        private PlayerFactory _playerFactory;
        private GameConfig _config;
        private KeyFactory _keyFactory;
        private HintWriter _hintWriter;

        [Inject]
        private void Construct(PlayerFactory playerFactory, GameConfig config, IModel<LevelData> levelModel, KeyFactory keyFactory,
            HintWriter hintWriter)
        {
            _playerFactory = playerFactory;
            _config = config;
            _indexCurrentLevel = levelModel.Read().CurrentLevelData.CurrentLevel;
            _keyFactory = keyFactory;
            _hintWriter = hintWriter;
            Init();
        }

        private void Init()
        {
            CreatePlayer();
            CreateKeys();
            _hintWriter.Clear();
            _hintWriter.Write(HintType.StartedLevel);
        }

        private void CreatePlayer() => 
            _playerFactory.Create(_config.LevelConfigs[_indexCurrentLevel].PlayerSpawnPoint.position, Quaternion.identity);

        private void CreateKeys()
        {
            var levelConfig = _config.LevelConfigs[_indexCurrentLevel];
            if (levelConfig.KeySpawnPoints == null)
                throw new ArgumentException("levelConfig.KeySpawnPoints == null");

            foreach (var point in levelConfig.KeySpawnPoints)
                _keyFactory.Create(point.position);
        }
    }
}