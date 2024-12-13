using System.ComponentModel.DataAnnotations;

namespace RepairServiceApp.Models
{
    public class Malfunction
    {
        [Key]
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
