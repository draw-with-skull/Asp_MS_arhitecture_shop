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


    }
}
