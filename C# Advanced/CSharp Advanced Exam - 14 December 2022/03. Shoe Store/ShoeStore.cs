using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public string Name { get; set; }
        public int StorageCapacity { get; set; }

        public List<Shoe> Shoes = new List<Shoe>();

        public ShoeStore(string name, int capacity)
        {
            Name = name;
            StorageCapacity = capacity;
        }
        public int Count
        {
            get { return Shoes.Count; }
        }

        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }
            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int count = Shoes.RemoveAll(shoe => shoe.Material.ToLower() == material.ToLower());
            return count;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            return Shoes.FindAll(shoe => shoe.Type.ToLower() == type.ToLower());
        }

        public Shoe GetShoeBySize(double size)
        {
            return Shoes.Find(shoe => shoe.Size == size);
        }

        public string StockList(double size, string type)
        {
            List<Shoe> matchingShoes = Shoes.FindAll(shoe => shoe.Size == size && shoe.Type.ToLower() == type.ToLower());
            if (matchingShoes.Count == 0)
            {
                return "No matches found!";
            }

            string stockList = $"Stock list for size {size} - {type} shoes:\n";
            foreach (Shoe shoe in matchingShoes)
            {
                stockList += $"{shoe}\n";
            }
            return stockList;
        }
    }
}
