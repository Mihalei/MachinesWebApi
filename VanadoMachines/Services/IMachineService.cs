using VanadoMachines.Dtos;
using VanadoMachines.Models;

namespace VanadoMachines.Services
{
    public interface IMachineService
    {
        Task<bool> CreateMachine(MachineDto machine);
        Task<bool> DeleteMachine(int id);
        Task<Machine> UpdateMachine(Machine machine);
        Task<MachineInfoDto> GetMachine(int id);
        Task<List<Machine>> GetAllMachines();
        
    }
}
