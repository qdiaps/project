using Architecture.FiniteStateMachine.States.Game;
using Architecture.Model;
using Architecture.Model.Level;
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
        private readonly IModel<LevelData> _levelModel;
        private readonly GameStateView _view;
        private readonly IPauseReader _pauseReader;
        private readonly GameConfig _config;

        public GameStateController(IModel<StateData> stateModel, IModel<SelectLevelData> selectLevelModel, IModel<LevelData> levelModel,
            GameStateView view, IPauseReader pauseReader, GameConfig config)
        {
            _stateModel = stateModel;
            _selectLevelModel = selectLevelModel;
            _levelModel = levelModel;
            _view = view;
            _pauseReader = pauseReader;
            _config = config;
            Init();
        }

        public void SetPause()
        {
            _stateModel.Update(new StateData(typeof(Pause)));
            var currentLevel = _selectLevelModel.Read().Current;
            var lastCompletedLevel = _levelModel.Read().CompletedLevelData.LastCompletedLevel;
            _view.UpdateLevelInfo(_config.LevelConfigs[currentLevel], ++currentLevel, 
                (--currentLevel <= ++lastCompletedLevel));
            _view.ShowPauseMenu();
            _view.HideSettingsMenu();
        }

        public void SetPlay()
        {
            _stateModel.Update(new StateData(typeof(Play)));
            _view.HidePauseMenu();
        }

        public void SetSettings()
        {
            _stateModel.Update(new StateData(typeof(Settings)));
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
            var lastCompletedLevel = _levelModel.Read().CompletedLevelData.LastCompletedLevel;
            _view.UpdateLevelInfo(_config.LevelConfigs[currentLevel], ++currentLevel, 
                (--currentLevel <= ++lastCompletedLevel));
        }

        private void Init() => 
            SettingInput();

        private void SettingInput()
        {
            _pauseReader.OnPauseEnter += SetPause;
            _pauseReader.OnPauseExit += SetPlay;
        }
    }
}