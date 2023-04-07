using Common;
using MongoDB.Driver;

namespace Storage.src
{
    public class MongoDBWraper
    {
        private readonly string connectionString = "mongodb://Mongodb:27017";
        private readonly string dbName = "Database";
        private readonly string collectionName = "Products";
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<Product> collection;

        public MongoDBWraper()
        {
            client = new MongoClient(connectionString);
            db = client.GetDatabase(dbName);
            collection = db.GetCollection<Product>(collectionName);
        }

        public  async void Inser(Product product)
        {
            await collection.InsertOneAsync(product);
        }
        public async Task<List<Product>> GetAll()
        {
            List<Product> results = await collection.Find(_ => true).ToListAsync();
            return results;
        }

    }
}
