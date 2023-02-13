using VanadoMachines.Models;

namespace VanadoMachines.Dtos
{
    public class MachineInfoDto
    {
        public string Name { get; set; }
        public List<Malfunction> RelatedMalfunctions { get; set; }
        public string AverageMalfunctionDuration { get; set; }
    }
}
