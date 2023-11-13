using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public int SellerId { get; set; }
        [ForeignKey(nameof(SellerId))]
        public virtual User Seller { get; set; }

        public int BuyerId { get; set; }
        [ForeignKey(nameof(BuyerId))]
        public virtual User Buyer { get; set; }
    }
}
