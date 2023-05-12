using Common.DataStructure;
using System.Net.Http.Json;
using static Common.Endpoints;

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
				return await client.GetFromJsonAsync<List<Product>>(STORAGE.PRODUCT.GET_PRODUCTS) ?? new();
			}
			catch (Exception) { return new(); }//silence ignore,storage ms is not working
		}

        public async Task<Product> GetItemByID(string id) {
			try
			{
				return await client.GetFromJsonAsync<Product>(Endpoints.STORAGE.PRODUCT.GET_PRODUCT+$"/{id}")??new();
		    }
			catch (Exception) { return new(); }//silence ignore,storage ms is not working
		}

        public async Task<List<Product>> GetDiscounted()
        {
			try
			{
				return await client.GetFromJsonAsync<List<Product>>(Endpoints.STORAGE.PRODUCT.GET_DISCOUNTED_PRODUCTS)??new();
            }
            catch (Exception){return new();}//silence ignore,storage ms is not working
        }

        public async Task<List<Product>> GetItemsWithTag(string tag)
        {
            try 
            { 
                return await client.GetFromJsonAsync<List<Product>>(Endpoints.STORAGE.PRODUCT.GET_PRODUCT_BY_TAG+ $"/{tag}")??new();
		    }
            catch (Exception){return new ();}//silence ignore,storage ms is not working
        }
	    public async Task RemoveItemByID(string id)
        {
			try
			{
				await client.DeleteAsync(Endpoints.STORAGE.PRODUCT.DELETE_ITEM + $"/{id}");
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }

        public async Task RemoveItemFromUserCart(string userId,string productId)
        {
			try
			{
				await client.DeleteAsync(Endpoints.STORAGE.USER.DELETE_ITEM_FROM_USER_CART + $"/{userId}/{productId}");
			}
			catch (Exception) { }//silence ignore,storage ms is not working
        }

        public async Task SaveItem(Product product)
        {
			try
			{
				await client.PostAsJsonAsync(Endpoints.STORAGE.PRODUCT.POST_ITEM, product);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }
        
        
        public async Task UpdateItem(Product product)
        {
			try
			{
				await client.PostAsJsonAsync(Endpoints.STORAGE.PRODUCT.UPDATE_ITEM, product);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }
        #endregion
        #region User
        public async Task SaveItem(User user)
        {
			try
			{
				await client.PostAsJsonAsync(Endpoints.STORAGE.USER.POST_USER, user);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }
        public async Task<User> GetUserData(string username,string password)
        {
			try
			{
				return await client.GetFromJsonAsync<User>(Endpoints.STORAGE.USER.GET_USER+ $"/{username}/{password}")??new();
			}
			catch (Exception) { return new(); }//silence ignore,storage ms is not working
        }

        public async Task<List<Product>> GetUserProductList(string username)
        {
			try
			{
				return await client.GetFromJsonAsync<List<Product>>(Endpoints.STORAGE.USER.GET_USER_SHOPPING_CART+$"/{username}")??new();
			}
			catch (Exception) { return new(); }//silence ignore,storage ms is not working
        }
        public async Task UpdateUserShoppingCart(User user)
        {
			try
			{
			await client.PostAsJsonAsync(Endpoints.STORAGE.USER.UPDATE_CART_LIST,user);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }
		public async void EmptyUserCart(string id)
		{
			try
			{
				await client.DeleteAsync(Endpoints.STORAGE.USER.EMPTY_USER_CART + $"/{id}");
			}
			catch (Exception) { }//silence ignore,storage ms is not working
		}
		#endregion

		#region Order
		public async Task SaveItem(Order order)
		{
			try
			{
			await client.PostAsJsonAsync(Endpoints.STORAGE.ORDER.POST_ORDER, order);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
		}
		public async Task<List<Order>> GetUnfinishedOrders()
        {
			try
			{
			return await client.GetFromJsonAsync<List<Order>>(Endpoints.STORAGE.ORDER.GET_UNFINISHED_ORDERS)??new();
			}
			catch (Exception) { return new(); }//silence ignore,storage ms is not working
        }
        public async Task<List<Order>> GetFinishedOrders()
        {
            try
            {
                return await client.GetFromJsonAsync<List<Order>>(Endpoints.STORAGE.ORDER.GET_FINISHED_ORDERS) ?? new();
            }
            catch (Exception) { return new(); }//silence ignore,storage ms is not working
        }

        public async Task<List<Order>> GetAllOrders()
		{
            try
            {
                return await client.GetFromJsonAsync<List<Order>>(Endpoints.STORAGE.ORDER.GET_ALL_ORDERS) ?? new();
            }
            catch (Exception) { return new(); }//silence ignore,storage ms is not working
        }

        public async Task UpdateOrder(Order order)
        {
			try
			{
				await client.PostAsJsonAsync(Endpoints.STORAGE.ORDER.UPDATE_ORDER, order);
			}
			catch (Exception) {}//silence ignore,storage ms is not working
        }

		public async Task SetRunInterval(int ms)
		{
            try
            {
				await client.GetAsync(Endpoints.ORDER.SET_INTERVAL + $"/{ms}");
            }
            catch (Exception) { }//silence ignore,storage ms is not working

        }

		public async void StartOrderMs()
		{
            try
            {
                await client.GetAsync(Endpoints.ORDER.START);
            }
            catch (Exception) { }//silence ignore,storage ms is not working
        }
        public async void StopOrderMs()
        {
            try
            {
                await client.GetAsync(Endpoints.ORDER.STOP);
            }
            catch (Exception) { }//silence ignore,storage ms is not working
        }

        #endregion
    }
}
