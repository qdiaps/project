using Newtonsoft.Json;

namespace Architecture.Model.Level
{
    public class LevelData
    {
        public CurrentLevelData CurrentLevelData { get; private set; }
        public CompletedLevelData CompletedLevelData { get; private set; }

        [JsonConstructor]
        public LevelData(CurrentLevelData currentLevelData, CompletedLevelData completedLevelData)
        {
            CurrentLevelData = currentLevelData;
            CompletedLevelData = completedLevelData;
        }
        
        public LevelData(CurrentLevelData currentLevelData) =>
            CurrentLevelData = currentLevelData;
        
        public LevelData(CompletedLevelData completedLevelData) =>
            CompletedLevelData = completedLevelData;
    }
}