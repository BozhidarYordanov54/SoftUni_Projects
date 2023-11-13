using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public int SellerId { get; set; }
        [ForeignKey(nameof(User.Id))]


        public int BuyerId { get; set; }
        [ForeignKey(nameof(User.Id))]


    }
}
