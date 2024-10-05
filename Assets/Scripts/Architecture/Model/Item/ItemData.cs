namespace Architecture.Model.Item
{
    public class ItemData
    {
        public KeyData KeyData { get; private set; }

        public ItemData(KeyData keyData)
        {
            KeyData = keyData;
        }
    }
}