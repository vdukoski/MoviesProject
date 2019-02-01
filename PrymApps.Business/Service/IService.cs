namespace PrymApps.Business.Service
{
    public interface IService<T>
    {
        ServiceResult<T> LoadAll();

        ServiceResult<T> Load(T item);

        ServiceResult<T> Add(T item);

        ServiceResult<T> Edit(T item);

        ServiceResult<T> Remove(T item);
    }
}
