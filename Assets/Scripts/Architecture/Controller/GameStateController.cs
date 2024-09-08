using Architecture.Model;

namespace Architecture.Controller
{
    public class GameStateController
    {
        private readonly GameStateModel _model;

        public GameStateController(GameStateModel model)
        {
            _model = model;
        }
    }
}