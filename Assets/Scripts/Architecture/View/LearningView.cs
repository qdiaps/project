using UnityEngine;
using UnityEngine.UI;

namespace Architecture.View
{
    public class LearningView : MonoBehaviour
    {
        [SerializeField] private GameObject _learningUI;
        [SerializeField] private Image _learnImage;
        [SerializeField] private GameObject _stopLearnButton;
        [SerializeField] private GameObject _nextLearnButton;
        
        public void Show() =>
            _learningUI.SetActive(true);

        public void UpdateLeanImage(Sprite img) => 
            _learnImage.sprite = img;

        public void ShowStopLearnButton()
        {
            _nextLearnButton.SetActive(false);
            _stopLearnButton.SetActive(true);
        }

        public void ShowNextLearnButton()
        {
            _nextLearnButton.SetActive(true);
            _stopLearnButton.SetActive(false);
        }
    }
}