using Architecture.Services.Learning;
using UnityEngine;
using VContainer;

namespace UI
{
    public class StopLearning : MonoBehaviour
    {
        private ILearningService _learningService;

        [Inject]
        private void Construct(ILearningService learningService) => 
            _learningService = learningService;

        public void Stop() =>
            _learningService.Stop();
    }
}