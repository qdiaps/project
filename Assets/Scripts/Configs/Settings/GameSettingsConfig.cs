using UnityEngine;

namespace Configs.Settings
{
    [CreateAssetMenu(fileName="NewGameSettingsConfig", menuName="CustomConfigs/GameSettingsConfig")]
    public class GameSettingsConfig : ScriptableObject
    {
        [Header("Path")] 
        public string PlayerPrefab;
        public string ParticlePrefab;
    }
}