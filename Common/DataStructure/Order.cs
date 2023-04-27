using MongoDB.Bson.Serialization.Attributes;


namespace Common.DataStructure
{
	public class Order
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string UserID { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public DateTime CreationDate { get; set; }
		public bool Finished { get; set; }
		public Order(string name, string surname, string userId,string city,string address)
		{
			Name = name;
			Surname = surname;
			UserID = userId;
			City = city;
			Address = address;
			CreationDate = DateTime.Now;
			Finished = false;

		}
	}
}
