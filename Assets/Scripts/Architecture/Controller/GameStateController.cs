using Architecture.FiniteStateMachine.States.Game;
using Architecture.Model;
using Architecture.Model.SelectLevel;
using Architecture.Model.State;
using Architecture.Services.Input;
using Architecture.View;
using Configs;

namespace Architecture.Controller
{
    public class GameStateController
    {
        private readonly IModel<StateData> _stateModel;
        private readonly IModel<SelectLevelData> _selectLevelModel;
        private readonly GameStateView _view;
        private readonly IPauseReader _pauseReader;
        private readonly IInputControlChanger _controlChanger;
        private readonly GameConfig _config;

        public GameStateController(IModel<StateData> stateModel, IModel<SelectLevelData> selectLevelModel, GameStateView view, 
            IPauseReader pauseReader, IInputControlChanger controlChanger, GameConfig config)
        {
            _stateModel = stateModel;
            _selectLevelModel = selectLevelModel;
            _view = view;
            _pauseReader = pauseReader;
            _controlChanger = controlChanger;
            _config = config;
            Init();
        }

        public void SetPause()
        {
            _stateModel.Update(new StateData(typeof(Pause)));
            _controlChanger.ChangeInputControl(InputControlType.UI);
            var currentLevel = _selectLevelModel.Read().Current;
            _view.UpdateLevelInfo(_config.LevelConfigs[currentLevel], ++currentLevel);
            _view.ShowPauseMenu();
            _view.HideSettingsMenu();
        }

        public void SetPlay()
        {
            _stateModel.Update(new StateData(typeof(Play)));
            _controlChanger.ChangeInputControl(InputControlType.Gameplay);
            _view.HidePauseMenu();
        }

        public void SetSettings()
        {
            _stateModel.Update(new StateData(typeof(Settings)));
            _controlChanger.ChangeInputControl(InputControlType.None);
            _view.ShowSettingsMenu();
        }

        public void ChangeSelectLevel(int to)
        {
            var currentLevel = _selectLevelModel.Read().Current;
            currentLevel += to;
            if (currentLevel < 0)
                currentLevel = _config.LevelConfigs.Length - 1;
            else if (currentLevel >= _config.LevelConfigs.Length)
                currentLevel = 0;
            _selectLevelModel.Update(new SelectLevelData(currentLevel));
            _view.UpdateLevelInfo(_config.LevelConfigs[currentLevel], ++currentLevel);
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