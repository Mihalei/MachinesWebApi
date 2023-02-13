using System.Diagnostics.CodeAnalysis;
using VanadoMachines.Enums;

namespace VanadoMachines.Models
{
    public class MalfunctionDto
    {
        public string Name { get; set; }
        public string MachineName { get; set; }
        public Priority Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
