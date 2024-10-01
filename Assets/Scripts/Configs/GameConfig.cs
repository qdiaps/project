using Configs.Camera;
using Configs.Hint;
using Configs.Level;
using Configs.Player;
using Configs.Scanner;
using Configs.Settings;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName="NewGameConfig", menuName="CustomConfigs/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [Header("Settings")] 
        public PathConfig PathConfig;
        public LevelConfig[] LevelConfigs;
        [Header("Player")]
        public PlayerConfig PlayerConfig;
        public CameraConfig CameraConfig;
        [Header("Scanner")]
        public ScannerConfig ScannerConfig;
        [Header("Hint")]
        public HintConfig HintConfig;

        private void OnValidate()
        {
            if (PathConfig == null)
                Debug.LogError($"{name}.PathConfig is missing");
            if (LevelConfigs == null)
                Debug.LogError($"{name}.LevelConfigs is missing");
            if (PlayerConfig == null)
                Debug.LogError($"{name}.PlayerConfig is missing");
            if (CameraConfig == null)
                Debug.LogError($"{name}.CameraConfig is missing");
            if (ScannerConfig == null)
                Debug.LogError($"{name}.ScannerConfig is missing");
            if (HintConfig == null)
                Debug.LogError($"{name}.HintConfig is missing");
        }
    }
}