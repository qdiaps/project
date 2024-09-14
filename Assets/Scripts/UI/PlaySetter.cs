using Architecture.Controller;
using UnityEngine;
using VContainer;

namespace UI
{
    public class PlaySetter : MonoBehaviour
    {
        private GameStateController _controller;

        [Inject]
        private void Construct(GameStateController controller) => 
            _controller = controller;

        public void Play() => 
            _controller.SetPlay();
    }
}