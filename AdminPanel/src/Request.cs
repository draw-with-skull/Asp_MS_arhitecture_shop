using Common;
using System.Xml.Linq;

namespace AdminPanel.src
{
    public class Request
    {
        private HttpClient client;
        public Request()
        {
            client = new();
        }

        public async void SaveItem(Product  product)
        {
            await client.PostAsJsonAsync(Endpoints.STORAGE.POST_ITEM_OUT, product);
        }
        public async Task<List<Product>> GetAllItems()
        {
            return await client.GetFromJsonAsync<List<Product>>(Endpoints.STORAGE.GET_ITEMS_OUT);
        }

        public async Task RemoveOneByID(Product product)
        {
            Console.WriteLine(product.Id);
            await client.PostAsJsonAsync(Endpoints.STORAGE.DELETE_ITEM_ID_OUT, product);
        }

    }
}
