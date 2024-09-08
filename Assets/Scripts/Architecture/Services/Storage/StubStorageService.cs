namespace Architecture.Services.Storage
{
    public class StubStorageService : IStorageService
    {
        public void Save(object data) { }

        public T Load<T>() => default;
    }
}