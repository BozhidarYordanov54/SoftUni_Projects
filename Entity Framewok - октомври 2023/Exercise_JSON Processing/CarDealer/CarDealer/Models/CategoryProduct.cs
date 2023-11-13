using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

    }
}
