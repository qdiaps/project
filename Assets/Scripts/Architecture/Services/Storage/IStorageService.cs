namespace Architecture.Services.Storage
{
    public interface IStorageService
    {
        void Serialize(object data);
        
        T Deserialize<T>();
    }
}