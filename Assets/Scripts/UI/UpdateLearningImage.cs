using Architecture.Controller;
using UnityEngine;
using VContainer;

namespace UI
{
    public class UpdateLearningImage : MonoBehaviour
    {
        private LearningController _controller;

        [Inject]
        private void Construct(LearningController controller) => 
            _controller = controller;
        
        public void Next() => 
            _controller.UpdateLearning();
    }
}