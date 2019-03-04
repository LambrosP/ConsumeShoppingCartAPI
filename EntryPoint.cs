using ConsumeShoppingCartAPI.ApiHelper.Implementation;
using ConsumeShoppingCartAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeShoppingCartAPI
{
    class EntryPoint
    {
        static int Main(string[] args)
        {
            PSPMessage responseResult = new PSPMessage();

            Console.WriteLine("Please give the uri string of the Web API EndPoint");

            var uriString = Console.ReadLine();

            ConsumeShoppingCart consumeShoppingCart = new ConsumeShoppingCart(uriString);

            //Add Product Item = 1 for Customer = 1 (Quantity = 100)
            BasketItemModel basketItem = new BasketItemModel()
            {
                CustomerId = 1,
                ProductId = 1,
                Quantity = 100
            };

            responseResult = consumeShoppingCart.AddBasketItemAsync(basketItem).GetAwaiter().GetResult();

            Console.WriteLine("Command:{0}  Status Code:{1}  Message:{2}", responseResult.command, responseResult.status, responseResult.message);


            //Add Product Item = 2 for Customer = 1 (Quantity = 100)
            basketItem.ProductId = 2;

            responseResult = consumeShoppingCart.AddBasketItemAsync(basketItem).GetAwaiter().GetResult();

            Console.WriteLine("Command:{0}  Status Code:{1}  Message:{2}", responseResult.command, responseResult.status, responseResult.message);


            //Add Product Item = 1 for Customer = 2 (Quantity = 100)
            basketItem.CustomerId = 2;

            responseResult = consumeShoppingCart.AddBasketItemAsync(basketItem).GetAwaiter().GetResult();

            Console.WriteLine("Command:{0}  Status Code:{1}  Message:{2}", responseResult.command, responseResult.status, responseResult.message);

            //Update Product Item = 1 for Customer = 1 (Quantity = 200)
            basketItem.CustomerId = 1;
            basketItem.ProductId = 1;
            basketItem.Quantity = 200;

            responseResult = consumeShoppingCart.UpdateBasketItemAsync(basketItem).GetAwaiter().GetResult();

            Console.WriteLine("Command:{0}  Status Code:{1}  Message:{2}", responseResult.command, responseResult.status, responseResult.message);


            //Get Customer Basket Items (customerId = 1)
            responseResult = consumeShoppingCart.GetCustomerBasketItemsAsync(1).GetAwaiter().GetResult();

            Console.WriteLine("Command:{0}  Status Code:{1}  Message:{2}", responseResult.command, responseResult.status, responseResult.message);


            //Get Customer Basket Items (customerId = 2)
            responseResult = consumeShoppingCart.GetCustomerBasketItemsAsync(2).GetAwaiter().GetResult();

            Console.WriteLine("Command:{0}  Status Code:{1}  Message:{2}", responseResult.command, responseResult.status, responseResult.message);


            //Remove Product Item = 1 for Customer = 1 (Total Quantity = 300)
            basketItem.CustomerId = 1;
            basketItem.ProductId = 1;

            responseResult = consumeShoppingCart.RemoveBasketItemAsync(basketItem).GetAwaiter().GetResult();

            Console.WriteLine("Command:{0}  Status Code:{1}  Message:{2}", responseResult.command, responseResult.status, responseResult.message);


            //Clear Basket Customer = 1
            basketItem.CustomerId = 1;

            responseResult = consumeShoppingCart.ClearCustomerBasketAsync(basketItem).GetAwaiter().GetResult();

            Console.WriteLine("Command:{0}  Status Code:{1}  Message:{2}", responseResult.command, responseResult.status, responseResult.message);

            //Clear Basket Customer = 2
            basketItem.CustomerId = 2;

            responseResult = consumeShoppingCart.ClearCustomerBasketAsync(basketItem).GetAwaiter().GetResult();

            Console.WriteLine("Command:{0}  Status Code:{1}  Message:{2}", responseResult.command, responseResult.status, responseResult.message);


            //Get Available Products Info
            responseResult = consumeShoppingCart.GetAvailableProductsInfoAsync().GetAwaiter().GetResult();

            Console.WriteLine("Command:{0}  Status Code:{1}  Message:{2}", responseResult.command, responseResult.status, responseResult.message);


            //Get Products = 1 Info
            responseResult = consumeShoppingCart.GetProductItemAsync(1).GetAwaiter().GetResult();

            Console.WriteLine("Command:{0}  Status Code:{1}  Message:{2}", responseResult.command, responseResult.status, responseResult.message);

            Console.ReadLine();

            return 0;
        }
    }
}
