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

        private async void SaveItem(Product  product,string EndPoint)
        {
            Console.WriteLine(EndPoint);
            await client.PostAsJsonAsync(EndPoint, product);
        }
        public void Save(Product product) =>SaveItem(product, Endpoints.STORAGE.POST_ITEM_OUT);


    }
}
