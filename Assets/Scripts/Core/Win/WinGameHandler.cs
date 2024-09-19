using Architecture.Services.LevelLoad;
using Core.Player;
using UnityEngine;
using VContainer;

namespace Core.Win
{
    public class WinGameHandler : MonoBehaviour
    {
        private ILevelLoadService _levelLoadService;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out MoveController player))
                _levelLoadService.LoadNextLevel();
        }

        [Inject]
        private void Construct(ILevelLoadService levelLoadService) =>
            _levelLoadService = levelLoadService;
    }
}
