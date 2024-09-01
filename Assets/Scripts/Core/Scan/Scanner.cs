using System.Collections;
using System.Collections.Generic;
using Architecture.Services.Input;
using Configs.Scanner;
using Core.Scan.Particle;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Core.Scan
{
    public class Scanner : MonoBehaviour
    {
        [SerializeField] private Transform _castPoint;
        
        private ParticleObjectPool _pool;
        private ScannerConfig _config;
        private List<Vector3> _positionsList = new();

        [Inject]
        private void Construct(ParticleObjectPool pool, ScannerConfig config)
        {
            _pool = pool;
            _config = config;
        }

        public void Scan()
        {
            _positionsList.Clear();
            for (int i = 0; i < _config.PointsPerScan; i++)
            {
                Vector3 randomPoint = Random.insideUnitSphere * _config.Radius;
                randomPoint += _castPoint.position;

                Vector3 direction = (randomPoint - transform.position).normalized;
                if (Physics.Raycast(transform.position, direction, out RaycastHit hit, _config.MaxDistance))
                    _positionsList.Add(hit.point);
            }

            StartCoroutine(ApplyPositions());
        }

        private IEnumerator ApplyPositions()
        {
            foreach (Vector3 point in _positionsList)
            {
                _pool.EnableParticle(point);
                yield return new WaitForSeconds(_config.TimeSpawn);
            }
        }
    }
}