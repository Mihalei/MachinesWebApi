using VanadoMachines.Models;

namespace VanadoMachines.Services
{
    public interface IMalfunctionService
    {
        Task<bool> CreateMalfunction(MalfunctionDto malfunction);
        Task<bool> DeleteMalfunction(int id);
        Task<Malfunction> UpdateMalfunction(Malfunction malfunction);
        Task<Malfunction> GetMalfunction(int id);
        Task<List<Malfunction>> GetAllMalfunctions(int offset, int count);
    }
}
