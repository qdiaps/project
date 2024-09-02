using System.Collections;
using Configs;
using NTC.Pool;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Core.Scan
{
    public class Scanner : MonoBehaviour
    {
        [SerializeField] private Transform _castPoint;
        
        private GameConfig _config;
        private ParticleSystem _particle;

        [Inject]
        private void Construct(GameConfig config)
        {
            _config = config;
        }

        public IEnumerator Scan()
        {
            for (int i = 0; i < _config.ScannerConfig.PointsPerScan; i++)
            {
                Vector3 randomPoint = Random.insideUnitSphere * _config.ScannerConfig.Radius;
                randomPoint += _castPoint.position;

                Vector3 direction = (randomPoint - transform.position).normalized;
                if (Physics.Raycast(transform.position, direction, out RaycastHit hit, _config.ScannerConfig.MaxDistance))
                {
                    NightPool.Spawn(_config.PathConfig.ScannerParticle, hit.point, Quaternion.identity)
                        .DespawnOnComplete();
                    yield return new WaitForSeconds(_config.ScannerConfig.TimeSpawn);
                }
            }
        }
    }
}