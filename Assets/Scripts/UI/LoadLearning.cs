using Architecture.Controller;
using Architecture.Services.Learning;
using UnityEngine;
using VContainer;

namespace UI
{
    public class LoadLearning : MonoBehaviour
    {
        private ILearningService _learningService;
        private GameStateController _controller;

        [Inject]
        private void Construct(ILearningService learningService, GameStateController controller)
        {
            _learningService = learningService;
            _controller = controller;
        }

        public void Load() => 
            _learningService.Setup();
    }
}