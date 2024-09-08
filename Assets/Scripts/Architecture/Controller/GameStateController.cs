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
        private readonly IInputControlChanger _controlChanger;

        public GameStateController(GameStateModel model, GameStateView view, IPauseReader pauseReader, 
            IInputControlChanger controlChanger)
        {
            _model = model;
            _view = view;
            _pauseReader = pauseReader;
            _controlChanger = controlChanger;
            Init();
        }

        public void SetPause()
        {
            if (_model.SetState(typeof(Pause)))
            {
                _controlChanger.ChangeInputControl(InputControlType.UI);
                _view.ShowPauseMenu();
            }
        }

        public void SetPlay()
        {
            if (_model.SetState(typeof(Play)))
            {
                _controlChanger.ChangeInputControl(InputControlType.Gameplay);
                _view.HidePauseMenu();
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