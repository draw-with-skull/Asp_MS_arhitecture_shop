using Common.DataStructure;
using MongoDB.Bson;
using MongoDB.Driver;
using static Common.Endpoints;

namespace Storage.src
{
    public class MongoDBWraper
    {
        private readonly string connectionString = "mongodb://Mongodb:27017";
        private readonly string dbName = "Database";
        
        private readonly string collectionProductName = "Products";
        private readonly string collectionUserName = "Users";
        private readonly string collectionOrderName = "Order";

        private readonly MongoClient client;
        private readonly IMongoDatabase db;

        private readonly IMongoCollection<Product> collectionProduct;
        private readonly IMongoCollection<User> collectionUser;
        private readonly IMongoCollection<Order> collectionOrder;

        public MongoDBWraper()
        {
            client = new MongoClient(connectionString);
            db = client.GetDatabase(dbName);
            collectionProduct = db.GetCollection<Product>(collectionProductName);
            collectionUser = db.GetCollection<User>(collectionUserName);
            collectionOrder = db.GetCollection<Order>(collectionOrderName);
        }
        #region Product_Area
        public async void Insert(Product product)
        {
            await collectionProduct.InsertOneAsync(product);
        }

        public async Task<List<Product>> GetAll()
        {
            return await collectionProduct.Find(_ => true).ToListAsync();
        }

        public async Task<List<Product>> GetDiscountedItems()
        {
            return await collectionProduct.Find(P => P.Discount > 0).ToListAsync();
        }
        public async Task<List<Product>>GetItemsWithTag(string tag)
        {
            return await collectionProduct.Find(P => P.Tags.Contains(tag)).ToListAsync();

        }
        public void RemoveOneByID(string Id)
        {
            collectionProduct.DeleteOneAsync(P => P.Id == Id);
        }

        public async Task<Product> GetItemByID(string Id)
        {
            return (await collectionProduct.FindAsync(P => P.Id == Id)).First();
        }

        public async Task UpdateItem(Product product)
        {
            UpdateDefinition<Product> definition = Builders<Product>.Update
                .Set(P => P.Name, product.Name)
                .Set(P => P.Description, product.Description)
                .Set(P => P.Discount, product.Discount)
                .Set(P => P.Price, product.Price)
                .Set(P => P.Tags, product.Tags)
                .Set(P => P.ImageBase64, product.ImageBase64);
            await collectionProduct.UpdateOneAsync(P => P.Id == product.Id, definition);
        }
        #endregion

        #region User_Area

        public async void Insert(User user)
        {
            await collectionUser.InsertOneAsync(user);
        }

        public async Task<User> CheckUser(string name,string password)
        {
            User user;
            try
            {
                user = (await collectionUser.FindAsync(U => (U.Username == name && U.Password == password))).First();
                user.Password = "";
            }
            catch (Exception)
            {
                user = new();
            }

            return user;
        }

        public async Task<List<Product>> GetUserShoppingCart(string username)
        {
            return (await collectionUser.FindAsync(P => P.Username == username)).First().ShoppingCartProducts;
        }

        public async Task UpdateUserShoppingCart(User user) {
            UpdateDefinition<User> definition = Builders<User>.Update.Set(P => P.ShoppingCartProducts, user.ShoppingCartProducts);
            await collectionUser.UpdateOneAsync(P => P.Username == user.Username, definition);
        }

        public async Task RemoveProductFromUserCart(string userId,string productId)
        {
            UpdateDefinition<User> definition = Builders<User>.Update.PullFilter(
                P => P.ShoppingCartProducts,
                Builders<Product>.Filter.Where(P => P.Id == productId));
            await collectionUser.UpdateOneAsync(P => P.Id == userId,definition);
        }
		public async Task EmptyUserCart(string userId)
		{
            UpdateDefinition<User> definition = Builders<User>.Update
                .Set(P => P.ShoppingCartProducts, new());
            await collectionUser.UpdateOneAsync(P => P.Id == userId, definition);

		}
		#endregion

		#region Order
		public async Task Inser(Order order)
        {
            await collectionOrder.InsertOneAsync(order);
        }

		public async Task<List<Order>> GetUnfinishedOrders()
		{
            return await collectionOrder.Find(P => P.Finished == false).ToListAsync();
		}
        public async Task UpdateOrder(Order order)
        {
            UpdateDefinition<Order> definition = Builders<Order>.Update
                .Set(P => P.Total, order.Total)
                .Set(P => P.Finished,true);
			await collectionOrder.UpdateOneAsync(P => P.Id == order.Id, definition);
		}

		
		#endregion
	}
}
