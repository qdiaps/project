using UnityEngine;

namespace Configs.Scanner
{
    [CreateAssetMenu(fileName="NewScannerConfig", menuName="CustomConfigs/ScannerConfig")]
    public class ScannerConfig : ScriptableObject
    {
        public int PointsPerScan;
        public float Radius;
        public float MaxDistance;
        public float TimeSpawn;
    }
}