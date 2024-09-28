using UnityEngine;

namespace Architecture.View
{
    public class GameStateView : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _settingsMenu;

        private void Awake() => 
            DontDestroyOnLoad(this);

        public void ShowPauseMenu() =>
            _pauseMenu.SetActive(true);

        public void HidePauseMenu() =>
            _pauseMenu.SetActive(false);

        public void ShowSettingsMenu() => 
            _settingsMenu.SetActive(true);

        public void HideSettingsMenu() => 
            _settingsMenu.SetActive(false);
    }
}