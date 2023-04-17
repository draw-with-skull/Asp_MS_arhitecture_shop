using Common.DataStructure;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Storage.src
{
    public class MongoDBWraper
    {
        private readonly string connectionString = "mongodb://Mongodb:27017";
        private readonly string dbName = "Database";
        
        private readonly string collectionProductName = "Products";
        private readonly string collectionUserName = "Users";

        private readonly MongoClient client;
        private readonly IMongoDatabase db;

        private readonly IMongoCollection<Product> collectionProduct;
        private readonly IMongoCollection<User> collectionUser;

        public MongoDBWraper()
        {
            client = new MongoClient(connectionString);
            db = client.GetDatabase(dbName);
            collectionProduct = db.GetCollection<Product>(collectionProductName);
            collectionUser = db.GetCollection<User>(collectionUserName);
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
            User user = (await collectionUser.FindAsync(U => (U.Username == name && U.Password == password))).First();
            if (user != null)
            {
                user.Password = "";
            }
            return user;
        }

        #endregion
    }
}
