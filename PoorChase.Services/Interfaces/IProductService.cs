using PoorChase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoorChase.Services
{
    /// <summary>
    /// General service interface for <see cref="Product"/> handling
    /// </summary>
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        Product GetById(int id);

        void AddProduct(Product product);
    }
}
