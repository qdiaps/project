using Architecture.Controller;
using UnityEngine;
using VContainer;

namespace UI
{
    public class ChangerSelectLevel : MonoBehaviour
    {
        private GameStateController _controller;

        [Inject]
        private void Construct(GameStateController controller) =>
            _controller = controller;
        
        public void Change(int to) => 
            _controller.ChangeSelectLevel(to);
    }
}