using UnityEngine;

namespace Configs.Scanner
{
    [CreateAssetMenu(fileName="NewScannerConfig", menuName="CustomConfigs/ScannerConfig")]
    public class ScannerConfig : ScriptableObject
    {
        [Header("Scan settings")]
        public int PointsPerScan;
        public float Radius;
        public float MaxDistance;
        public float TimeSpawn;
        [Header("Model params")]
        public int AttemptRate;
        public float AttemptResetTime;
        public float AllAttemptResetTime;
    }
}