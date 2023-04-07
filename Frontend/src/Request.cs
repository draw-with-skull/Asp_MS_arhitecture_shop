using Common;

namespace Frontend.src
{
	public class Request
	{
		private HttpClient client;
		public Request()
		{
			client = new();
		}

		public async void get()
		{
			/*try
			{
				using var client = new HttpClient();
				using HttpResponseMessage response = await client.GetAsync("");
				TestClassCommon data = await response.Content.ReadFromJsonAsync<TestClassCommon>());
				string datamessage = data.b;
			}
			catch (Exception)
			{

				string datamessage = "error";
			}*/
		}
	}
}
