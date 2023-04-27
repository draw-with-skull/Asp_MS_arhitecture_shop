using Common;
using Common.DataStructure;
using Storage.src;

namespace Storage.Controllers
{
	public class OrderController
	{
		private readonly MongoDBWraper mongo;

		public OrderController(WebApplication app)
		{
			mongo = new();


			app.MapPost(Endpoints.STORAGE_INTERNAL.POST_ORDER, (Order order) => mongo.Inser(order));
		}
	}
}
