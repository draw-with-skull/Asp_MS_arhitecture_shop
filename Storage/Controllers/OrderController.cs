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

			app.MapGet(Endpoints.STORAGE_INTERNAL.GET_UNFINISHED_ORDERS, () => mongo.GetUnfinishedOrders());

			app.MapPost(Endpoints.STORAGE_INTERNAL.POST_ORDER, (Order order) => mongo.Inser(order));

			app.MapPost(Endpoints.STORAGE_INTERNAL.UPDATE_ORDER, (Order order) => mongo.UpdateOrder(order));

		}
	}
}
