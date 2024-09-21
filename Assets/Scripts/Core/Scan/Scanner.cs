using System.Collections;
using Configs;
using Core.Markers;
using Core.Player;
using NTC.Pool;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Core.Scan
{
    [RequireComponent(typeof(LineRenderer))]
    public class Scanner : MonoBehaviour
    {
        public bool CanScan;
        
        [SerializeField] private Transform _castPoint;
        [SerializeField] private Transform _player;
        
        private GameConfig _config;
        private ParticleSystem _particle;
        private LineRenderer _line;

        private void Awake() => 
            _line = GetComponent<LineRenderer>();

        [Inject]
        private void Construct(GameConfig config) => 
            _config = config;

        public IEnumerator Scan()
        {
            _line.enabled = true;
            for (int i = 0; i < _config.ScannerConfig.PointsPerScan; i++)
            {
                Vector3 randomPoint = Random.insideUnitSphere * _config.ScannerConfig.Radius;
                randomPoint += _castPoint.position;

                Vector3 direction = (randomPoint - transform.position).normalized;
                if (Physics.Raycast(transform.position, direction, out RaycastHit hit, _config.ScannerConfig.MaxDistance))
                {
                    if (hit.transform.TryGetComponent(out Key key))
                        SpawnParticle(_config.PathConfig.ScannerKeyParticle, hit.point);
                    else if (hit.transform.TryGetComponent(out MoveController player))
                        continue;
                    else
                        SpawnParticle(_config.PathConfig.ScannerDefaultParticle, hit.point);
                    _line.SetPositions(new []{ _player.position, hit.point });
                    yield return new WaitForSeconds(_config.ScannerConfig.TimeSpawn);
                }
            }
            _line.enabled = false;
            if (CanScan)
                StartCoroutine(Scan());
        }
        
        private void SpawnParticle(ParticleSystem particle, Vector3 position) =>
            NightPool.Spawn(particle, position, Quaternion.identity).DespawnOnComplete();
    }
}