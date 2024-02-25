using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Products.Data.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Stock { get; set; }

        public Product()
        { }

        public Product(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("> Product:");
            stringBuilder.AppendLine($"  Id: {Id}");
            stringBuilder.AppendLine($"  Name: {Name}");
            stringBuilder.AppendLine($"  Price: {Price:f2}");
            stringBuilder.AppendLine($"  Stock: {Stock}");

            return stringBuilder.ToString();
        }
    }
}
