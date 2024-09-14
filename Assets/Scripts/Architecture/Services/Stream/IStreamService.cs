namespace Architecture.Services.Stream
{
    public interface IStreamService
    {
        void Save(object data, string path);
        
        object Load(string path);
    }
}