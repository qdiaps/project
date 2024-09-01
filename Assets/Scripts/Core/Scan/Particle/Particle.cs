using System.Collections;
using Configs.Scanner;
using UnityEngine;
using VContainer;

namespace Core.Scan.Particle
{
    [RequireComponent(typeof(ParticleSystem))]
    public class Particle : MonoBehaviour
    {
        public int Index { get; set; }
        
        private ParticleObjectPool _particleObjectPool;
        private ParticleConfig _config;
        private ParticleSystem _particle;
        private bool _isInited;

        private void Awake() => 
            _particle = GetComponent<ParticleSystem>();

        private void OnEnable()
        {
            if (_isInited)
            {
                _particle.Play();
                StartCoroutine(DisableCooldown(_config.Lifetime));
            }
        }

        [Inject]
        private void Construct(ParticleConfig config) => 
            _config = config;

        public void Init(ParticleObjectPool particleObjectPool)
        {
            if (_isInited == false)
            {
                _particleObjectPool = particleObjectPool;
                _isInited = true;
            }
        }

        private IEnumerator DisableCooldown(float time)
        {
            yield return new WaitForSeconds(time);

            _particle.Stop();
            _particleObjectPool.DisableParticle(Index);
        }
    }
}