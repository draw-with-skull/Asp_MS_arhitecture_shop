using Common;
using Common.DataStructure;

namespace Frontend.src
{
    public class Request
	{
		private HttpClient client;
		public Request()
		{
			client = new();
		}
		public async Task<List<Product>> GetAllItems()
		{
			return await client.GetFromJsonAsync<List<Product>>(Endpoints.STORAGE.GET_ITEMS_OUT);
		}


	}
}
