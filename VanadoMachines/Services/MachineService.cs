using VanadoMachines.Dtos;
using VanadoMachines.Models;
using VanadoMachines.Repositories;

namespace VanadoMachines.Services
{
    public class MachineService : IMachineService
    {
        private readonly IDbRepository _repository;

        public MachineService(IDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateMachine(MachineDto machine)
        {
            var result =
            await _repository.EditData(
                "INSERT INTO public.machine (name) VALUES (@Name)",
                machine);
            return true;
        }

        public async Task<bool> DeleteMachine(int id)
        {
            var deleteMachine = await _repository.EditData("DELETE FROM public.machine WHERE id=@Id", new { id });
            return true;
        }

        public async Task<Machine> UpdateMachine(Machine machine)
        {
            var updateMachine =
            await _repository.EditData(
                "Update public.machine SET name=@Name WHERE id=@Id",
                machine);
            return machine;
        }

        public async Task<MachineInfoDto> GetMachine(int id)
        {
            var machine = await _repository.GetAsync<Machine>("SELECT * FROM public.machine where id=@id", new { id });
            if (machine is null) {
                return null;
            }
            var malfunctionList = await _repository.GetAll<Malfunction>($"SELECT * FROM public.malfunction WHERE public.malfunction.machinename='{machine.Name}'", new { });
            double averageMalfunctionDuration = CalculateAverageMalfunctionDuration(malfunctionList);
            MachineInfoDto mid = new MachineInfoDto();
            mid.Name = machine.Name;
            mid.RelatedMalfunctions = malfunctionList;
            mid.AverageMalfunctionDuration = $"{averageMalfunctionDuration:0.##} min";
            return mid;
        }

        public async Task<List<Machine>> GetAllMachines()
        {
            var machineList = await _repository.GetAll<Machine>("SELECT * FROM public.machine", new { });
            return machineList;
        }

        #region Helper Methods
        private double CalculateAverageMalfunctionDuration(List<Malfunction> malfunctionList)
        {
            double sum = 0.0;
            foreach (var malfunction in malfunctionList)
            {
                sum += malfunction.EndDate.Subtract(malfunction.StartDate).TotalMinutes;
            }

            if (malfunctionList.Count == 0 || sum == 0.0) 
                return 0.0; 
            
            return sum / malfunctionList.Count;
        }
        #endregion

    }
}
