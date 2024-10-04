using Architecture.Model;
using Architecture.Model.Learning;
using Architecture.View;
using Configs;
using Core.Hint;
using UnityEngine;
using VContainer;

namespace Architecture.Controller
{
    public class LearningController : MonoBehaviour
    {
        [SerializeField] private LearningView _view;
        
        private GameConfig _config;
        private IModel<LearningData> _model;

        private void Start()
        {
            _model.Update(new LearningData(0));
            _view.Show();
            _view.ShowNextLearnButton();
            UpdateLearning();
        }

        [Inject]
        private void Construct(HintWriter hint, GameConfig config, IModel<LearningData> model)
        {
            hint.Clear();
            _config = config;
            _model = model;
        }

        public void UpdateLearning()
        {
            var index = _model.Read().CurrentIndex;
            if (index == _config.LearningConfig.LearningSprites.Length - 1)
                _view.ShowStopLearnButton();
            _view.UpdateLeanImage(_config.LearningConfig.LearningSprites[index]);
            _model.Update(new LearningData(++index));
        }
    }
}