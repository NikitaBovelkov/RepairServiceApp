using System.ComponentModel.DataAnnotations;

namespace RepairServiceApp.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;
    }
}
