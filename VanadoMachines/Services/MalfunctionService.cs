using VanadoMachines.Models;
using VanadoMachines.Repositories;

namespace VanadoMachines.Services
{
    public class MalfunctionService : IMalfunctionService
    {
        private readonly IDbRepository _repository;

        public MalfunctionService(IDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateMalfunction(MalfunctionDto malfunction)
        {
            if (string.IsNullOrEmpty(malfunction.Description))
            {
                return false;
            }

            var activeMalfunctions = await _repository.GetAll<Malfunction>($"SELECT * FROM public.malfunction WHERE public.malfunction.machinename='{malfunction.MachineName}' AND public.malfunction.status<>2", new { });
            if (activeMalfunctions.Count > 0)
            {
                return false;
            }

            var result =
            await _repository.EditData(
                "INSERT INTO public.malfunction (name,machinename,priority,startdate,enddate,description,status) VALUES (@Name, @MachineName, @Priority, @StartDate, @EndDate, @Description, @Status)",
                malfunction);
            return true;
        }

        public async Task<bool> DeleteMalfunction(int id)
        {
            var deleteMalfunction = await _repository.EditData("DELETE FROM public.malfunction WHERE id=@Id", new { id });
            return true;
        }

        public async Task<Malfunction> UpdateMalfunction(Malfunction malfunction)
        {
            var updateMalfunction =
            await _repository.EditData(
                "Update public.malfunction SET name=@Name, machinename=@MachineName, priority=@Priority, startdate=@StartDate, enddate=@EndDate, description=@Description, status=@Status WHERE id=@Id",
                malfunction);
            return malfunction;
        }

        public async Task<Malfunction> GetMalfunction(int id)
        {
            var malfunction = await _repository.GetAsync<Malfunction>("SELECT * FROM public.malfunction where id=@id", new { id });
            return malfunction;
        }

        public async Task<List<Malfunction>> GetAllMalfunctions(int offset, int count)
        {
            var malfunctionList = await _repository.GetAll<Malfunction>("SELECT * FROM public.malfunction ORDER BY priority, startdate desc", new { });
            //malfunctionList = SortMalfunctions(malfunctionList);
            malfunctionList = malfunctionList.Skip(offset).Take(count).ToList();
            return malfunctionList;
        }

        #region Helper Methods
        private List<Malfunction> SortMalfunctions(List<Malfunction> malfunctionList)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
