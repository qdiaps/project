using Architecture.Model;
using Architecture.Model.Item;
using Architecture.Model.Level;
using Configs;
using Core.Markers;
using UnityEngine;
using VContainer;

namespace Core.Player
{
    public class PickUpItemHandler : MonoBehaviour
    {
        private IModel<ItemData> _itemModel;
        private int _maxKeyCount;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Key key))
            {
                Destroy(other.gameObject);
                var currentCountKey = _itemModel.Read().KeyData.CurrentCount;
                _itemModel.Update(new ItemData(new KeyData(++currentCountKey)));
                if (currentCountKey == _maxKeyCount)
                    Debug.Log("All key found!!!");
                Debug.Log("Key found");
            }
        }

        [Inject]
        private void Construct(IModel<ItemData> itemModel, IModel<LevelData> levelModel, GameConfig config)
        {
            _itemModel = itemModel;
            var currentLevel = levelModel.Read().CurrentLevelData.CurrentLevel;
            _maxKeyCount = config.LevelConfigs[currentLevel].KeySpawnPoints.Length;
        }
    }
}