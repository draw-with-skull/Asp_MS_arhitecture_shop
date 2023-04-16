namespace Frontend.Src.Authentication
{
    //Temporary implemetation for testing
    public class UserAccountService
    {
        private List<UserAccount> users;
        public UserAccountService()
        {
            users = new()
            {
                new UserAccount{Username = "user",Password="1234",Role = "User"},
                new UserAccount{Username = "admin",Password="12345678",Role = "Admin"}
            };
        }

        public UserAccount? GetUserAccount(string username)
        {
            return users.FirstOrDefault(User => User.Username == username);
        }
    }
}
