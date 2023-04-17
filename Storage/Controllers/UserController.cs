using Common;
using Common.DataStructure;
using Storage.src;

namespace Storage.Controllers
{
    public class UserController
    {
        private readonly MongoDBWraper mongo;
        public UserController(WebApplication app)
        {
            mongo = new();

            app.MapPost(Endpoints.STORAGE_INTERNAL.POST_USER, (User user) =>
            { 
                mongo.Insert(user);
            });
            app.MapGet(Endpoints.STORAGE_INTERNAL.GET_USER + "/{username}/{password}", async (string username,string password) =>
            {
                return await mongo.CheckUser(username,password);
            });
        }
    }
}
