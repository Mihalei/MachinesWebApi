using Microsoft.AspNetCore.Mvc;
using VanadoMachines.Models;
using VanadoMachines.Services;

namespace VanadoMachines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachinesController : Controller
    {
        private readonly IMachineService _machineService;
        public MachinesController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMachine([FromBody] MachineDto machineDto)
        {
            var result = await _machineService.CreateMachine(machineDto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMachine([FromBody] Machine machine)
        {
            var result = await _machineService.UpdateMachine(machine);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            var result = await _machineService.DeleteMachine(id);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMachine(int id)
        {
            var result = await _machineService.GetMachine(id);

            if (result is null) 
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _machineService.GetAllMachines();

            return Ok(result);
        }

    }
}
