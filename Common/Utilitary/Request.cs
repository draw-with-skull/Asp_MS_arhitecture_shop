using Common.DataStructure;
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
            return await client.GetFromJsonAsync<List<Product>>(Endpoints.STORAGE.GET_ITEMS)??new();
        }

        public async Task<Product> GetItemByID(string id) {
            return await client.GetFromJsonAsync<Product>(Endpoints.STORAGE.GET_ITEM+$"/{id}")??new();
        }

        public async Task RemoveItemByID(string id)
        {
            await client.DeleteAsync(Endpoints.STORAGE.DELETE_ITEM + $"/{id}");
        }

        public async Task SaveItem(Product product)
        {
           await client.PostAsJsonAsync(Endpoints.STORAGE.POST_ITEM, product);
        }
        

        public async Task UpdateItem(Product product)
        {
            await client.PostAsJsonAsync(Endpoints.STORAGE.UPDATE_ITEM, product);
        }
        #endregion
        #region User
        public async Task SaveItem(User user)
        {
            await client.PostAsJsonAsync(Endpoints.STORAGE.POST_USER, user);
        }
        public async Task<User> GetUserData(string username,string password)
        {
            return await client.GetFromJsonAsync<User>(Endpoints.STORAGE.GET_USER+ $"/{username}/{password}");
        }
        #endregion
    }
}
