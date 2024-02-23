using Json;
using Newtonsoft.Json;

var product = new Product(1, "Bread", 2, 50, new DateTime(2024, 2, 20));

var productJson = JsonConvert.SerializeObject(product);

Console.WriteLine(productJson);

var product2 = JsonConvert.DeserializeObject<Product>(productJson);

Console.WriteLine(product2);

Console.WriteLine();

var products = new[]
{
    product,
    new Product(2, "Cheese", 10.50, 20, new DateTime(2024, 3, 15))
};

var productsJson = JsonConvert.SerializeObject(products);

Console.WriteLine(productsJson);

var products2 = JsonConvert.DeserializeObject<Product[]>(productsJson);

Console.WriteLine(string.Join("\n", products2.Select(p => p.ToString())));