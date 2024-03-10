﻿using Products_Web.Data.Entities;

namespace Products_Web.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);

        IEnumerable<Product> GetAll();

        void Delete(int id);

        void Edit(Product product);

        Product Get(int id);
    }
}
