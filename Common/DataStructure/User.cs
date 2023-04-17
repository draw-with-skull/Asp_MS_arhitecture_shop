namespace Common.DataStructure
{
    public class User
    {
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";

        public List<string> ProductsList=new();

    }
}
