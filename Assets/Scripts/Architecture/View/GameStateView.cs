using Configs.Level;
using TMPro;
using UnityEngine;

namespace Architecture.View
{
    public class GameStateView : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _settingsMenu;
        [SerializeField] private TMP_Text _levelName;
        [SerializeField] private TMP_Text _levelComplexity;
        [SerializeField] private TMP_Text _levelCountKeys;

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

        public void UpdateLevelInfo(LevelConfig levelConfig, int levelIndex)
        {
            _levelName.text = $"Номер уровня: {levelIndex}";
            var coplexity = "нету";
            switch (levelConfig.Complexity)
            {
                case ComplexityType.Ease:
                    coplexity = "легко";
                    break;
                case ComplexityType.Normal: 
                    coplexity = "нормально";
                    break;
                case ComplexityType.Hard:
                    coplexity = "сложно";
                    break;
            }

            _levelComplexity.text = $"Сложность: {coplexity}";
            _levelCountKeys.text = $"Ключей: {levelConfig.KeySpawnPoints.Length}";
        }
    }
}