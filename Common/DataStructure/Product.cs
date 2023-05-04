using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.DataStructure
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Discount { get; set; } = 0;
        public int Price { get; set; } = 0;
        public string ImageBase64 { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();

        public Product() { }
        public Product(string name, string description, int discount, int price, string imageBase64, List<string> tags)
        {
            Name = name;
            Description = description;
            Discount = discount > 100 ? discount % 100 : discount;          //make sure discount is not grater than 100;
            Discount = Discount < 0 ? -Discount : Discount;                 //make shure discount is not negative;
            Price = price < 0 ? -price : price;                            //make sure price is not negative;
            ImageBase64 = imageBase64;
            Tags = tags;

        }
    }
}
