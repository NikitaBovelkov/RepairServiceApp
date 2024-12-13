using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepairServiceApp.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid ProductId { get; set; }

        public bool Warranty { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
