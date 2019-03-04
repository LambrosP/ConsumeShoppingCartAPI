using ConsumeShoppingCartAPI.ApiHelper.Interfaces;
using ConsumeShoppingCartAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeShoppingCartAPI.ApiHelper.Implementation
{
    public class ConsumeShoppingCart : IConsumeShoppingCart
    {
        private readonly HttpClient client;

        public ConsumeShoppingCart(string uriString)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uriString);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<PSPMessage> AddBasketItemAsync(BasketItemModel basketItemModel)
        {
            var response = await client.PutAsJsonAsync<BasketItemModel>("api/v1/addBasketItem", basketItemModel);

            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<PSPMessage>(result);
        }

        public async Task<PSPMessage> UpdateBasketItemAsync(BasketItemModel basketItemModel)
        {
            var response = await client.PostAsJsonAsync<BasketItemModel>("api/v1/updateBasketItem", basketItemModel);

            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<PSPMessage>(result);
        }

        public async Task<PSPMessage> RemoveBasketItemAsync(BasketItemModel basketItemModel)
        {
            var response = await client.PostAsJsonAsync<BasketItemModel>("api/v1/removeBasketItem", basketItemModel);

            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<PSPMessage>(result);
        }

        public async Task<PSPMessage> ClearCustomerBasketAsync(BasketItemModel basketItemModel)
        {
            var response = await client.PostAsJsonAsync<BasketItemModel>("api/v1/clearCustomerBasket", basketItemModel);

            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<PSPMessage>(result);
        }

        public async Task<PSPMessage> GetCustomerBasketItemsAsync(int customerId)
        {
            string requestUri = String.Format("api/v1/getCustomerBasketItems?customerId={0}", customerId);

            var response = await client.GetAsync(requestUri);

            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<PSPMessage>(result);
        }

        public async Task<PSPMessage> GetAvailableProductsInfoAsync()
        {
            var response = await client.GetAsync("api/v1/getAvailableProductsInfo");

            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<PSPMessage>(result);
        }

        public async Task<PSPMessage> GetProductItemAsync(int productId)
        {
            string requestUri = String.Format("api/v1/getProductItem?productId={0}", productId);

            var response = await client.GetAsync(requestUri);

            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<PSPMessage>(result);
        }
    }
}
