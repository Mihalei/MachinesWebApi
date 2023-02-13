namespace VanadoMachines.Repositories
{
    public interface IDbRepository
    {
        Task<int> CreateData<T>(string command, object parms);
        Task<int> DeleteData<T>(string command, object parms);
        Task<int> EditData(string command, object parms);
        Task<T> GetAsync<T>(string command, object parms);
        Task<List<T>> GetAll<T>(string command, object parms);
    }
}
