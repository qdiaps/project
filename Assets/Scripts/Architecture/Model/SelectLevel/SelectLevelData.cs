namespace Architecture.Model.SelectLevel
{
    public class SelectLevelData
    {
        public int Current { get; private set; }

        public SelectLevelData(int current) => 
            Current = current;
    }
}