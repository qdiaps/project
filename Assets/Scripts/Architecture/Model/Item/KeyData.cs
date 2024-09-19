namespace Architecture.Model.Item
{
    public class KeyData
    {
        public int CurrentCount { get; private set; }

        public KeyData(int currentCount) => 
            CurrentCount = currentCount;
    }
}