using Common.DataStructure;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Storage.src
{
    public class MongoDBWraper
    {
        private readonly string connectionString = "mongodb://Mongodb:27017";
        private readonly string dbName = "Database";
        private readonly string collectionName = "Products";
        private readonly MongoClient client;
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<Product> collection;

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
            return await collection.Find(_ => true).ToListAsync();
        }

        public void RemoveOneByID(string Id)
        {
            collection.DeleteOneAsync(P=>P.Id == Id);
        }

        public async Task<Product> GetItemByID(string Id) 
        {
            return (await collection.FindAsync(P => P.Id == Id)).First();
        }

        public async Task UpdateItem(Product product) 
        {
            UpdateDefinition<Product> definition = Builders<Product>.Update
                .Set(P => P.Name, product.Name)
                .Set(P=>P.Description,product.Description)
                .Set(P=>P.Discount,product.Discount)
                .Set(P=>P.Price,product.Price)
                .Set(P=>P.ImageBase64,product.ImageBase64);
            await collection.UpdateOneAsync(P=>P.Id==product.Id,definition);
        }


    }
}
