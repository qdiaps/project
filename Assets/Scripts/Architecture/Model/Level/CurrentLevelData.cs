namespace Architecture.Model.Level
{
    public class CurrentLevelData
    {
        public int CurrentLevel { get; private set; }

        public CurrentLevelData(int currentLevel) => 
            CurrentLevel = currentLevel;
    }
}