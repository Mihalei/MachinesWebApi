using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using VanadoMachines.Models;
using VanadoMachines.Services;

namespace VanadoMachines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MalfunctionsController : Controller
    {
        private readonly IMalfunctionService _malfunctionService;
        public MalfunctionsController(IMalfunctionService malfunctionService)
        {
            _malfunctionService = malfunctionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMalfunction([FromBody] MalfunctionDto malfunctionDto)
        {
            var result = await _malfunctionService.CreateMalfunction(malfunctionDto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMalfunction([FromBody] Malfunction malfunction)
        {
            var result = await _malfunctionService.UpdateMalfunction(malfunction);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMalfunction(int id)
        {
            var result = await _malfunctionService.DeleteMalfunction(id);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMalfunction(int id)
        {
            var result = await _malfunctionService.GetMalfunction(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QueryParameters parameters)
        {
            var result = await _malfunctionService.GetAllMalfunctions(parameters.Offset, parameters.Count);

            return Ok(result);
        }
    }

    #region Helpers
    public class QueryParameters
    {
        [BindRequired]
        public int Offset { get; set; }

        [BindRequired]
        public int Count { get; set; }
    }
    #endregion
}
