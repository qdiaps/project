namespace Architecture.Model.Learning
{
    public class LearningData
    {
        public int CurrentIndex { get; private set; }

        public LearningData(int currentIndex) => 
            CurrentIndex = currentIndex;
    }
}