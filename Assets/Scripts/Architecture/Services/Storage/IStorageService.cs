namespace Architecture.Services.Storage
{
    public interface IStorageService
    {
        void Save(object data);
        
        T Load<T>();
    }
}