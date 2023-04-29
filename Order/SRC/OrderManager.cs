using Common.DataStructure;
using Common.Utilitary;

namespace Order.SRC
{
	public class OrderManager: BackgroundService
	{
		private readonly PeriodicTimer timer;
		private readonly Request request;
		public OrderManager(int intervalMs) { 
			timer = new(TimeSpan.FromMilliseconds(intervalMs));
			request = new();
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (await timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
			{
				ProcessOrders();
			}
		}
		private async void ProcessOrders() {
			List<Common.DataStructure.Order> orders = new();
			try
			{
				orders = await request.GetUnfinishedOrders();
			}
			catch (Exception)
			{
				//ignore
				//storage ms may not be running
			}
			orders.ForEach((order =>
			{
				int OrderTotal = 0;
				order.Products.ForEach((Product product) =>
				{
					float minusPercent = (product.Discount / 100f);
					int amount = (int)(product.Discount == 0 ? product.Price : (product.Price - (product.Price * minusPercent)));
					OrderTotal += amount;
				});
				order.Total = OrderTotal;
				_ = request.UpdateOrder(order);
			}));
		}
	}
}
