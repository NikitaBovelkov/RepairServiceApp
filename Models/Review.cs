using System.ComponentModel.DataAnnotations;

namespace RepairServiceApp.Models
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        public int OrderId { get; set; } = 0;

        public string ReviewText { get; set; } = string.Empty;

        public short Rating { get; set; } = 0;
    }
}
