using Common.DataStructure;
using System.Net.Http.Json;
using Common.DataStructure;
namespace Common.Utilitary
{
    public class Request
    {
        private readonly HttpClient client;
        public Request()
        {
            client = new();
        }

        public async Task<List<Product>> GetAllItems()
        {
            return await client.GetFromJsonAsync<List<Product>>(Endpoints.STORAGE.GET_ITEMS)??new();
        }

        public async Task<Product> GetItemByID(string id) {
            return new();
        }

        public async Task RemoveItemByID(string id)
        {
            await client.DeleteAsync(Endpoints.STORAGE.DELETE_ITEM + $"/{id}");
        }

        public async Task SaveItem(Product product)
        {
           await client.PostAsJsonAsync<Product>(Endpoints.STORAGE.POST_ITEM, product);
        }

        public async Task UpdateItem(Product product)
        {
            //
        }
    }
}
