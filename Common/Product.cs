using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace Common
{
	public class Product
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Discount { get; set; }
		public int Price { get; set; }
		public string ImageBase64 { get; set; }

		public Product(string name, string description,int discount,int price,string imageBase64) {
			Name = name;
			Description = description;
			Discount = discount > 100 ? discount % 100 : discount;			//make sure discount is not grater than 100;
			Discount = this.Discount < 0 ? -this.Discount : this.Discount;	//make shure discount is not negative;
			Price = price < 0 ? -price : price;                            //make sure price is not negative;
			ImageBase64 = imageBase64;
		}
	}
}
