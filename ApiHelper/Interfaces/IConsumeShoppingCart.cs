using ConsumeShoppingCartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeShoppingCartAPI.ApiHelper.Interfaces
{
    public interface IConsumeShoppingCart
    {
        Task<PSPMessage> AddBasketItemAsync(BasketItemModel basketItemModel);
        Task<PSPMessage> UpdateBasketItemAsync(BasketItemModel basketItemModel);
        Task<PSPMessage> RemoveBasketItemAsync(BasketItemModel basketItemModel);
        Task<PSPMessage> ClearCustomerBasketAsync(BasketItemModel basketItemModel);
        Task<PSPMessage> GetCustomerBasketItemsAsync(int customerId);
        Task<PSPMessage> GetAvailableProductsInfoAsync();
        Task<PSPMessage> GetProductItemAsync(int productId);
    }
}
