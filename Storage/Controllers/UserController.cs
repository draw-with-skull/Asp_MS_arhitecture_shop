using Common;
using Common.DataStructure;
using Storage.src;
using System.Collections;

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
            app.MapGet(Endpoints.STORAGE_INTERNAL.GET_USER_SHOPPING_CART + "/{username}", async (string username) =>
            {
                return await mongo.GetUserShoppingCart(username);
            });
            app.MapPost(Endpoints.STORAGE_INTERNAL.UPDATE_CART_LIST, async (User user) =>
            {
               await mongo.UpdateUserShoppingCart(user);
            });
            app.MapDelete(Endpoints.STORAGE_INTERNAL.DELETE_ITEM_FROM_USER_CART + "/{userId}/{productId}", async (string userId, string productId) =>
            {
                await mongo.RemoveProductFromUserCart(userId, productId);
            });

            app.MapDelete(Endpoints.STORAGE_INTERNAL.EMPTY_USER_CART + "/{userId}", async (string userId) =>
            {
                await mongo.EmptyUserCart(userId);
            });
        }
    }
}
