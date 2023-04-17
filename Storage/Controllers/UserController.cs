using Common;
using Common.DataStructure;

namespace Storage.Controllers
{
    public class UserController
    {
        public UserController(WebApplication app)
        {
            app.MapPost(Endpoints.STORAGE.POST_USER, (User user) =>
            {

            });
        }
    }
}
