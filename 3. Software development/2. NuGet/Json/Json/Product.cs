using System.Text;

namespace Json
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Product(int id, string name, double price, int stock, DateTime expirationDate)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Id: {Id}");
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Price: {Price}");
            stringBuilder.AppendLine($"Stock: {Stock}");
            stringBuilder.AppendLine($"ExpirationDate: {ExpirationDate}");

            return stringBuilder.ToString();
        }
    }
}
