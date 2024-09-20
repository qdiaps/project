using UnityEngine;

namespace Architecture.View
{
    public class GameStateView : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;

        private void Awake() => 
            DontDestroyOnLoad(this);

        public void ShowPauseMenu() =>
            _pauseMenu.SetActive(true);

        public void HidePauseMenu() =>
            _pauseMenu.SetActive(false);
    }
}