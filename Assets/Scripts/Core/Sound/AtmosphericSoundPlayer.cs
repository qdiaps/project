using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Sound
{
    public class AtmosphericSoundPlayer : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;
        [SerializeField] private AudioClip[] _sounds;
        [SerializeField] private float _minPlayTime;
        [SerializeField] private float _maxPlayTime;

        private void Start() => 
            Invoke(nameof(PlaySound), Random.Range(_minPlayTime, _maxPlayTime));

        private void PlaySound()
        {
            AudioSource.PlayClipAtPoint(_sounds[GetRandom(_sounds.Length)], 
                _points[GetRandom(_points.Length)].position);
            Invoke(nameof(PlaySound), GetRandom(_maxPlayTime, _minPlayTime));
        }
        
        private int GetRandom(int max, int min = 0) =>
            Random.Range(min, max);
        
        private float GetRandom(float max, float min = 0) =>
            Random.Range(min, max);
    }
}