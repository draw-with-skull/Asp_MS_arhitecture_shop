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

			app.MapGet(Endpoints.STORAGE.INTERNAL.ORDER.GET_UNFINISHED_ORDERS, () => mongo.GetUnfinishedOrders());

			app.MapGet(Endpoints.STORAGE.INTERNAL.ORDER.GET_FINISHED_ORDERS, () => mongo.GetFinishedOrders());
			
			app.MapGet(Endpoints.STORAGE.INTERNAL.ORDER.GET_ALL_ORDERS, () => mongo.GetAllOrders());

			app.MapPost(Endpoints.STORAGE.INTERNAL.ORDER.POST_ORDER, (Order order) => mongo.Inser(order));

			app.MapPost(Endpoints.STORAGE.INTERNAL.ORDER.UPDATE_ORDER, (Order order) => mongo.UpdateOrder(order));

		}
	}
}
