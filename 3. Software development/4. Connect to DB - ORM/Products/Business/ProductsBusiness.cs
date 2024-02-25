using Products.Data;
using Products.Data.Model;

namespace Products.Business
{
    public class ProductsBusiness
    {
        public IEnumerable<Product> GetAll()
        {
            using (var context = new ProductContext())
            {
                return context.Products.ToList();
            }
        }

        public void Add(Product product)
        {
            using (var context = new ProductContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public Product Get(int id)
        {
            using (var context = new ProductContext())
            {
                return context.Products.FirstOrDefault(product => product.Id == id);
            }
        }

        public void Update(Product product)
        {
            using (var context = new ProductContext())
            {
                var productEntity = context.Products.FirstOrDefault(product => product.Id == product.Id);

                productEntity.Name = product.Name;
                productEntity.Price = product.Price;
                productEntity.Stock = product.Stock;

                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (var context = new ProductContext())
            {
                context.Products.Remove(product);

                context.SaveChanges();
            }
        }
    }
}
