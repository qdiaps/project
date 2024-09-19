using UnityEngine;

namespace Configs.Level
{
    [CreateAssetMenu(fileName="NewLevelConfig", menuName="CustomConfigs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public int BuildIndexScene;
        public Transform PlayerSpawnPoint;
        public Transform[] KeySpawnPoints;
        public GameObject DoorPrefab;
    }
}