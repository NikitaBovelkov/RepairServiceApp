using System.ComponentModel.DataAnnotations;

namespace RepairServiceApp.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Specs { get; set; } = string.Empty;

        public int WarrantyTime { get; set; } = 0;
    }
}
