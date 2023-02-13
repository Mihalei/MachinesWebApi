using VanadoMachines.Enums;

namespace VanadoMachines.Models
{
    public class Malfunction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MachineName { get; set; }
        public Priority Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
