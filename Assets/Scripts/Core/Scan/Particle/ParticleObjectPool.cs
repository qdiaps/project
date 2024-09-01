using Architecture.Factory;
using Configs.Scanner;
using UnityEngine;
using VContainer;

namespace Core.Scan.Particle
{
    public class ParticleObjectPool : MonoBehaviour
    {
        private ParticleConfig _config;
        private ParticleFactory _factory;
        private ParticleObject[] _particle;
        private int _lastNonActiveParticle;

        [Inject]
        private void Construct(ParticleConfig config, ParticleFactory factory)
        {
            _config = config;
            _factory = factory;
            CreateParticle();
        }

        public void EnableParticle(Vector3 position)
        {
            if (_lastNonActiveParticle == 0)
            {
                Debug.LogWarning("ParticleObjectPool._lastNonActiveParticle == 0");
                return;
            }

            _lastNonActiveParticle--;
            var particle = _particle[0];
            
            if (_lastNonActiveParticle != 0)
            {
                var temp = _particle[_lastNonActiveParticle];
                _particle[_lastNonActiveParticle] = particle;
                _particle[0] = temp;
            }

            particle.Particle.Index = _lastNonActiveParticle;
            particle.Prefab.SetActive(true);
            particle.Prefab.transform.position = position;
        }

        public void DisableParticle(int index)
        {
            var particle = _particle[index];
            particle.Prefab.SetActive(false);
            if (_lastNonActiveParticle == index)
                _lastNonActiveParticle++;
            else
            {
                var temp = _particle[_lastNonActiveParticle];
                _particle[_lastNonActiveParticle] = particle;
                _particle[index] = temp;
                temp.Particle.Index = index;
                _lastNonActiveParticle++;
            }
        }

        private void CreateParticle()
        {
            _lastNonActiveParticle = _config.MaxCountParticle;
            _particle = new ParticleObject[_lastNonActiveParticle];
            for (int i = 0; i < _particle.Length; i++)
            {
                var prefab = _factory.Create(gameObject.transform);
                var particleObject = new ParticleObject(prefab, prefab.GetComponent<Particle>());
                _particle[i] = particleObject;
                particleObject.Prefab.SetActive(false);
                particleObject.Particle.Init(this);
            }
        }
    }
}