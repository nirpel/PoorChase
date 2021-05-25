using PoorChase.Data;
using PoorChase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorChase.Services
{
    /// <summary>
    /// Service implementation for <see cref="Product"/>s by <see cref="IProductService"/>
    /// </summary>
    public class ProductService : IProductService
    {
        IDataRepository<Product> _repo;

        public ProductService() => _repo = new ProductRepository();

        /// <summary>
        /// Add new <see cref="Product"/> to products list
        /// </summary>
        /// <param name="product">New product to add</param>
        public void AddProduct(Product product)
        {
            product.Date = DateTime.Now;
            product.State = ProductState.Available;
            //TODO: Save image file somewhere and save photopaths as paths??? 
            _repo.Add(product);
        }

        /// <summary>
        /// Get all AVAILABLE products.
        /// </summary>
        /// <returns>Collection of all Products with state <see cref="ProductState.Available"/></returns>
        public IEnumerable<Product> GetProducts() => _repo.GetAll().Where(p => p.State == ProductState.Available);
        
        /// <summary>
        /// Get a product by his ID
        /// </summary>
        /// <param name="id">ID of the required product</param>
        /// <returns><see cref="Product"/> with the entered id.
        /// NULL if product with entered id not found.</returns>
        public Product GetById(int id) => _repo.GetById(id);
    }
}
