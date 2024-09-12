using Architecture.FiniteStateMachine.States.Game;
using Architecture.Model;
using Architecture.Services.Input;
using Architecture.View;

namespace Architecture.Controller
{
    public class GameStateController
    {
        private readonly IModel<StateData> _stateModel;
        private readonly GameStateView _view;
        private readonly IPauseReader _pauseReader;
        private readonly IInputControlChanger _controlChanger;

        public GameStateController(IModel<StateData> stateModel, GameStateView view, IPauseReader pauseReader, 
            IInputControlChanger controlChanger)
        {
            _stateModel = stateModel;
            _view = view;
            _pauseReader = pauseReader;
            _controlChanger = controlChanger;
            Init();
        }

        public void SetPause()
        {
            _stateModel.Update(new StateData(typeof(Pause)));
            _controlChanger.ChangeInputControl(InputControlType.UI);
            _view.ShowPauseMenu();
        }

        public void SetPlay()
        {
            _stateModel.Update(new StateData(typeof(Play)));
            _controlChanger.ChangeInputControl(InputControlType.Gameplay);
            _view.HidePauseMenu();
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