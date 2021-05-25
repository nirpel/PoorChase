using Microsoft.EntityFrameworkCore;
using PoorChase.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PoorChase.Data
{
    /// <summary>
    /// Manage data for <see cref="Product"/> entities
    /// </summary>
    public class ProductRepository : BaseRepository<Product>
    {
        /// <summary>
        /// Add new <see cref="Product"/> to saved data
        /// </summary>
        /// <param name="entity">The new product</param>
        public override void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get all Products from saved data
        /// </summary>
        /// <returns>Collection of all products from data</returns>
        public override IEnumerable<Product> GetAll() => _context.Products.Include(x => x.User).Include(x => x.Owner);

        /// <summary>
        /// Get a specific <see cref="Product"/> by it's ID
        /// </summary>
        /// <param name="id">Required product's ID</param>
        /// <returns><see cref="Product"/> Instance of the product with the entered ID.
        /// NULL if no such product found.</returns>
        public override Product GetById(int id)
        {
            var products = GetAll();
            if (products != null)
                return products.FirstOrDefault(p => p.Id == id);
            return null;
        }

        /// <summary>
        /// Remove a <see cref="Product"/> from saved data
        /// </summary>
        /// <param name="entity">Product to remove</param>
        public override void Remove(Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates a <see cref="Product"/> from existed data
        /// </summary>
        /// <param name="entity">the product after being changed/edited</param>
        public override void Update(Product entity)
        {
            //var oldEntity = _context.Products.Find(entity.Id);
            //_context.Entry(oldEntity).CurrentValues.SetValues(oldEntity);
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
