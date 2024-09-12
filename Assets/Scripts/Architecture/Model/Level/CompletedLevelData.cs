namespace Architecture.Model.Level
{
    public class CompletedLevelData
    {
        public int LastCompletedLevel { get; private set; }

        public CompletedLevelData(int lastCompletedLevel) => 
            LastCompletedLevel = lastCompletedLevel;
    }
}