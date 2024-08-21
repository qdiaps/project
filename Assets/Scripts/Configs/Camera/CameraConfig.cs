using UnityEngine;

namespace Configs.Camera
{
    [CreateAssetMenu(fileName="NewCameraConfig", menuName="CustomConfigs/CameraConfig")]
    public class CameraConfig : ScriptableObject
    {
        public bool CameraCanMove = true;
        public float MouseSensitivity = 5f;
        public float MaxLookAngle = 50f;
    }
}