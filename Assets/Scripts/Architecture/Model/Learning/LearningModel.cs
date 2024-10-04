using Configs;

namespace Architecture.Model.Learning
{
    public class LearningModel : IModel<LearningData>
    {
        private readonly GameConfig _config;
        
        private int _currentIndex;
        
        public LearningModel(GameConfig config) => 
            _config = config;

        public LearningData Read() => 
            new(_currentIndex);

        public void Update(LearningData data)
        {
            var allIndexes = _config.LearningConfig.LearningSprites.Length;
            if (data.CurrentIndex >= 0 && data.CurrentIndex < allIndexes)
                _currentIndex = data.CurrentIndex;
        }
    }
}