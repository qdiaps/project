using System.Collections;
using Configs.Scanner;
using Configs.Settings;
using NTC.Pool;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Core.Scan
{
    public class Scanner : MonoBehaviour
    {
        [SerializeField] private Transform _castPoint;
        
        private ScannerConfig _config;
        private ParticleSystem _particle;

        [Inject]
        private void Construct(GameSettingsConfig gameSettingsConfig, ScannerConfig config)
        {
            _particle = gameSettingsConfig.ScannerParticle;
            _config = config;
        }

        public IEnumerator Scan()
        {
            for (int i = 0; i < _config.PointsPerScan; i++)
            {
                Vector3 randomPoint = Random.insideUnitSphere * _config.Radius;
                randomPoint += _castPoint.position;

                Vector3 direction = (randomPoint - transform.position).normalized;
                if (Physics.Raycast(transform.position, direction, out RaycastHit hit, _config.MaxDistance))
                {
                    NightPool.Spawn(_particle, hit.point, Quaternion.identity)
                        .DespawnOnComplete();
                    yield return new WaitForSeconds(_config.TimeSpawn);
                }
            }
        }
    }
}