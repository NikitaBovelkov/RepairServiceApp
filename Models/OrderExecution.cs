using System.ComponentModel.DataAnnotations;

namespace RepairServiceApp.Models
{
    public class OrderExecution
    {
        [Key]
        public Guid ExecutionId { get; set; }

        public Guid OrderId { get; set; }

        public Guid EmployeeId { get; set; }

        public string RepairType { get; set; } = string.Empty;

        public float RepairCost { get; set; } = 0;

        public DateTime ExecutionDate { get; set; }

        public bool Notification { get; set; }

        public DateTime ProductGet { get; set; }

        public float TotalCost { get; set; } = 0;
    }
}
