namespace Architecture.Model
{
    public interface IModel<TData>
    {
        TData Read();
        
        void Update(TData data);
    }
}