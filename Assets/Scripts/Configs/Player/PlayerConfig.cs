using UnityEngine;

namespace Configs.Player
{
    [CreateAssetMenu(fileName="NewPlayerConfig", menuName="CustomConfigs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Movement")]
        public float WalkSpeed = 5f;
        public float MaxVelocityChange = 10f;
        public float SprintSpeed = 9f;
        [Header("Jump")]
        public float JumpPower = 5f;
        public float JumpCooldown = 0.3f;
        [Header("Other")]
        public float CheckGroundRayDistance = .75f;
    }
}