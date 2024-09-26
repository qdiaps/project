using Architecture.Model;
using Architecture.Model.Item;
using Architecture.Model.Level;
using Architecture.Services.Door;
using Configs;
using Core.Markers;
using UnityEngine;
using VContainer;

namespace Core.Player
{
    public class PickUpItemHandler : MonoBehaviour
    {
        [SerializeField] private AudioClip _pickUpSound;
        
        private IModel<ItemData> _itemModel;
        private int _maxKeyCount;
        private IDoorService _doorService;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Key key))
            {
                AudioSource.PlayClipAtPoint(_pickUpSound, transform.position);
                Destroy(other.gameObject);
                var currentCountKey = _itemModel.Read().KeyData.CurrentCount;
                _itemModel.Update(new ItemData(new KeyData(++currentCountKey)));
                Debug.Log("Key found");
                if (currentCountKey == _maxKeyCount)
                    _doorService.Open();
            }
        }

        [Inject]
        private void Construct(IModel<ItemData> itemModel, IModel<LevelData> levelModel, GameConfig config, 
            IDoorService doorService)
        {
            _itemModel = itemModel;
            var currentLevel = levelModel.Read().CurrentLevelData.CurrentLevel;
            _maxKeyCount = config.LevelConfigs[currentLevel].KeySpawnPoints.Length;
            _doorService = doorService;
        }
    }
}