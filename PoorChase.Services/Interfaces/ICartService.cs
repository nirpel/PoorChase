using PoorChase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoorChase.Services
{
    public interface ICartService
    {
        void AddToCart(int productId, string userName);

        void RemoveFromCart(int id);

        void Buy(int productId, string userName);
    }
}
