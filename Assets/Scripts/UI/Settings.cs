using Architecture.Controller;
using UnityEngine;
using VContainer;

namespace UI
{
    public class Settings : MonoBehaviour
    {
        private GameStateController _controller;

        [Inject]
        private void Construct(GameStateController controller) => 
            _controller = controller;
        
        public void Open() => 
            _controller.SetSettings();

        public void Close() => 
            _controller.SetPause();
    }
}