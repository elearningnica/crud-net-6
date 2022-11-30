namespace crud_net_6.Data.Interfaces
{
    public interface IStudent<T>
    {
        Task<List<T>> GetAll();
    }
}
