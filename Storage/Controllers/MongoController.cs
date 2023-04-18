using Common.DataStructure;
using Common;
using Storage.src;

namespace Storage.Controllers
{
    public class MongoController
    {
        MongoDBWraper mongo;
        public MongoController(WebApplication app)
        {
            mongo = new();
            app.MapGet(Endpoints.STORAGE_INTERNAL.GET_ITEM + "/{id}", (string id) =>
            {
                return mongo.GetItemByID(id);
            });
            app.MapGet(Endpoints.STORAGE_INTERNAL.GET_ITEMS, () =>
            {
                return mongo.GetAll();
            });

            app.MapGet(Endpoints.STORAGE_INTERNAL.GET_DISCOUNTED_ITEMS, () =>
            {
                return mongo.GetDiscountedItems();
            });

            app.MapPost(Endpoints.STORAGE_INTERNAL.UPDATE_ITEM, (Product product) => mongo.UpdateItem(product));
            app.MapPost(Endpoints.STORAGE_INTERNAL.POST_ITEM, (Product product) => mongo.Insert(product));

            app.MapDelete(Endpoints.STORAGE_INTERNAL.DELETE_ITEM + "/{id}", (string id) => mongo.RemoveOneByID(id));

        }
    }
}
