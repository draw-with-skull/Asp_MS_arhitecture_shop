﻿using Common.DataStructure;
using System.Net.Http.Json;
namespace Common.Utilitary
{
    public class Request
    {
        private readonly HttpClient client;
        public Request()
        {
            client = new();
        }
        #region Product
        public async Task<List<Product>> GetAllItems()
        {
            try
            {
				return await client.GetFromJsonAsync<List<Product>>(Endpoints.STORAGE.GET_ITEMS) ?? new();
			}
			catch (Exception) { return new(); }//silence ignore,storage ms is not working
		}

        public async Task<Product> GetItemByID(string id) {
			try
			{
				return await client.GetFromJsonAsync<Product>(Endpoints.STORAGE.GET_ITEM+$"/{id}")??new();
		    }
			catch (Exception) { return new(); }//silence ignore,storage ms is not working
		}

        public async Task<List<Product>> GetDiscounted()
        {
			try
			{
				return await client.GetFromJsonAsync<List<Product>>(Endpoints.STORAGE.GET_DISCOUNTED_ITEMS)??new();
            }
            catch (Exception){return new();}//silence ignore,storage ms is not working
        }

        public async Task<List<Product>> GetItemsWithTag(string tag)
        {
            try 
            { 
                return await client.GetFromJsonAsync<List<Product>>(Endpoints.STORAGE.GET_ITEM_BY_TAG + $"/{tag}")??new();
		    }
            catch (Exception){return new ();}//silence ignore,storage ms is not working
        }
	    public async Task RemoveItemByID(string id)
        {
			try
			{
				await client.DeleteAsync(Endpoints.STORAGE.DELETE_ITEM + $"/{id}");
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }

        public async Task RemoveItemFromUserCart(string userId,string productId)
        {
			try
			{
				await client.DeleteAsync(Endpoints.STORAGE.DELETE_ITEM_FROM_USER_CART + $"/{userId}/{productId}");
			}
			catch (Exception) { }//silence ignore,storage ms is not working
        }

        public async Task SaveItem(Product product)
        {
			try
			{
				await client.PostAsJsonAsync(Endpoints.STORAGE.POST_ITEM, product);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }
        
        
        public async Task UpdateItem(Product product)
        {
			try
			{
				await client.PostAsJsonAsync(Endpoints.STORAGE.UPDATE_ITEM, product);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }
        #endregion
        #region User
        public async Task SaveItem(User user)
        {
			try
			{
				await client.PostAsJsonAsync(Endpoints.STORAGE.POST_USER, user);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }
        public async Task<User> GetUserData(string username,string password)
        {
			try
			{
				return await client.GetFromJsonAsync<User>(Endpoints.STORAGE.GET_USER+ $"/{username}/{password}")??new();
			}
			catch (Exception) { return new(); }//silence ignore,storage ms is not working
        }

        public async Task<List<Product>> GetUserProductList(string username)
        {
			try
			{
				return await client.GetFromJsonAsync<List<Product>>(Endpoints.STORAGE.GET_USER_SHOPPING_CART+$"/{username}")??new();
			}
			catch (Exception) { return new(); }//silence ignore,storage ms is not working
        }
        public async Task UpdateUserShoppingCart(User user)
        {
			try
			{
			await client.PostAsJsonAsync(Endpoints.STORAGE.UPDATE_CART_LIST,user);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }
		public async void EmptyUserCart(string id)
		{
			await client.DeleteAsync(Endpoints.STORAGE.EMPTY_USER_CART + $"/{id}");
		}
		#endregion

		#region Order
		public async Task SaveItem(Order order)
		{
			try
			{
			await client.PostAsJsonAsync(Endpoints.STORAGE.POST_ORDER, order);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
		}
		public async Task<List<Order>> GetUnfinishedOrders()
        {
			try
			{
			return await client.GetFromJsonAsync<List<Order>>(Endpoints.STORAGE.GET_UNFINISHED_ORDERS)??new();
			}
			catch (Exception) { return new(); }//silence ignore,storage ms is not working
        }

        public async Task UpdateOrder(Order order)
        {
			try
			{
			await client.PostAsJsonAsync(Endpoints.STORAGE.UPDATE_ORDER, order);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }
        #endregion
    }
}
