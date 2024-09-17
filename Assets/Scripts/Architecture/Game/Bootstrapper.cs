using Architecture.Services.LevelLoad;
using UnityEngine;
using VContainer;

namespace Architecture.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        private ILevelLoadService _levelLoadService;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        [Inject]
        private void Construct(ILevelLoadService levelLoadService)
        {
            _levelLoadService = levelLoadService;
            LoadLevel();
        }

        private void LoadLevel() => 
            _levelLoadService.LoadLastLevelFromSave();
    }
}