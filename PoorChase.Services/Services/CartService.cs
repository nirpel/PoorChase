using PoorChase.Data;
using PoorChase.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PoorChase.Services
{
    /// <summary>
    /// Service implementation for managing a shopping cart by ADD INTERFACE HERE/>
    /// </summary>
    public class CartService : ICartService
    {
        IDataRepository<User> _userRepo;
        IDataRepository<Product> _productRepo;

        public CartService()
        {
            _userRepo = new UserRepository();
            _productRepo = new ProductRepository();
        }

        /// <summary>
        /// Add a <see cref="Product"/> to buyer's cart. 
        /// The product will be unavailabled to other customers as long as it stays in the cart.
        /// </summary>
        /// <param name="productId">The ID of the product to add to the cart</param>
        public void AddToCart(int productId, string userName)
        {
            var product = GetValidProductById(productId);
            var user = _userRepo.GetAll().FirstOrDefault(x => x.UserName == userName);
            //user = null means that the cart belongs to a guest (non-user)
            if (user != null)
                product.UserId = user.Id;
            product.State = ProductState.Occupied;
            _productRepo.Update(product);
        }

        /// <summary>
        /// Remove product from buyer's cart. The product will be now available to customers.
        /// </summary>
        /// <param name="id">The ID of the product to remove from the cart</param>
        public void RemoveFromCart(int id)
        {
            var product = GetValidProductById(id);
            product.User = null;
            product.State = ProductState.Available;
            _productRepo.Update(product);
        }

        /// <summary>
        /// Buy a product. the product will be unavailable in store.
        /// </summary>
        /// <param name="id">The ID of the product to buy</param>
        public void Buy(int productId, string userName)
        {
            var product = GetValidProductById(productId);
            var user = _userRepo.GetAll().FirstOrDefault(x => x.UserName == userName);
            if (user != null)
                product.UserId = user.Id;
            product.State = ProductState.Sold;
            _productRepo.Update(product);
        }

        #region Helpers

        /// <summary>
        /// Get a product by his ID, avoid nulls.
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="Product"/> instance of the product with entered id</returns>
        private Product GetValidProductById(int id)
        {
            var product = _productRepo.GetById(id);
            if (product == null)
                throw new ProductNotFoundException($"Product with Id = {id} not found");
            return product;
        }

        #endregion
    }
}
