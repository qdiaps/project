using UnityEngine;

namespace Configs.Scanner
{
    [CreateAssetMenu(fileName="NewParticleConfig", menuName="CustomConfigs/ParticleConfig")]
    public class ParticleConfig : ScriptableObject
    {
        public int MaxCountParticle = 100;
        public float Lifetime = 5f;
    }
}