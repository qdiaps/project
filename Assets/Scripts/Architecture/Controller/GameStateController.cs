using Architecture.FiniteStateMachine.States.Game;
using Architecture.Model;
using Architecture.Services.Input;
using Architecture.View;

namespace Architecture.Controller
{
    public class GameStateController
    {
        private readonly GameStateModel _model;
        private readonly GameStateView _view;
        private readonly IPauseReader _pauseReader;

        public GameStateController(GameStateModel model, GameStateView view, IPauseReader pauseReader)
        {
            _model = model;
            _view = view;
            _pauseReader = pauseReader;
            Init();
        }

        public void SetPause()
        {
            if (_model.SetState(typeof(Pause)))
            {
            }
        }

        public void SetPlay()
        {
            if (_model.SetState(typeof(Play)))
            {
            }
        }

        private void Init()
        {
            SettingInput();
        }

        private void SettingInput()
        {
            _pauseReader.OnPauseEnter += SetPause;
            _pauseReader.OnPauseExit += SetPlay;
        }
    }
}