﻿using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories.Interfaces;

namespace Products_Web.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext context;

        public ProductRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
            => context.Products.ToList();

        public void Delete(int id)
        {
            var product = Get(id);
            // ToDo: add null value validation

            context.Products.Remove(product);
            context.SaveChanges();
        }

        private Product Get(int id)
            => context.Products.FirstOrDefault(product => product.Id == id);
    }
}
