using Architecture.Model;
using Architecture.Model.Level;
using Architecture.Services.LevelLoad;
using Core.Player;
using UnityEngine;
using VContainer;

namespace Core.Win
{
    public class WinGameHandler : MonoBehaviour
    {
        private ILevelLoadService _levelLoadService;
        private IModel<LevelData> _levelModel;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out MoveController player))
            {
                var winLevelIndex = _levelModel.Read().CurrentLevelData.CurrentLevel;
                _levelModel.Update(new LevelData(new CompletedLevelData(winLevelIndex)));
                _levelLoadService.LoadNextLevel();
            }
        }

        [Inject]
        private void Construct(ILevelLoadService levelLoadService, IModel<LevelData> levelModel)
        {
            _levelLoadService = levelLoadService;
            _levelModel = levelModel;
        }
    }
}
