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
			List<Common.DataStructure.Order> orders = await request.GetUnfinishedOrders();
			orders.ForEach((order =>
			{
				int OrderTotal = 0;
				order.Products.ForEach((Product product) =>
				{
					int amount = (int)(product.Discount == 0 ? product.Price : (product.Price - (product.Price * (float)(product.Discount / 100))));
					OrderTotal += amount;
				});
				order.Total = OrderTotal;
				Console.WriteLine(order.Id);
				Console.WriteLine(order.Total);
			}));
		}
	}
}
