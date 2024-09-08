using Architecture.Model;
using Architecture.View;

namespace Architecture.Controller
{
    public class GameStateController
    {
        private readonly GameStateModel _model;
        private readonly GameStateView _view;

        public GameStateController(GameStateModel model, GameStateView view)
        {
            _model = model;
            _view = view;
        }
    }
}