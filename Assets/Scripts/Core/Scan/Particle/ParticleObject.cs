using UnityEngine;

namespace Core.Scan.Particle
{
    public struct ParticleObject
    {
        public readonly GameObject Prefab;
        public readonly Particle Particle;

        public ParticleObject(GameObject prefab, Particle particle)
        {
            Prefab = prefab;
            Particle = particle;
        }
    }
}