using Common.DataStructure;
using Common;
using Storage.src;

namespace Storage.Controllers
{
    public class ProductController
    {
        readonly MongoDBWraper mongo;
        public ProductController(WebApplication app)
        {
            mongo = new();
            app.MapGet(Endpoints.STORAGE.INTERNAL.PRODUCT.GET_PRODUCT + "/{id}", (string id) =>
            {
                return mongo.GetItemByID(id);
            });
            app.MapGet(Endpoints.STORAGE.INTERNAL.PRODUCT.GET_PRODUCTS, () =>
            {
                Console.WriteLine("got here");
                return mongo.GetAll();
            });

            app.MapGet(Endpoints.STORAGE.INTERNAL.PRODUCT.GET_DISCOUNTED_PRODUCTS, () =>
            {
                return mongo.GetDiscountedItems();
            });

            app.MapGet(Endpoints.STORAGE.INTERNAL.PRODUCT.GET_PRODUCT_BY_TAG + "/{tag}", (string tag) =>
            {
                return mongo.GetItemsWithTag(tag);
            });

            app.MapPost(Endpoints.STORAGE.INTERNAL.PRODUCT.UPDATE_ITEM, (Product product) => mongo.UpdateItem(product));
            app.MapPost(Endpoints.STORAGE.INTERNAL.PRODUCT.POST_ITEM, (Product product) => mongo.Insert(product));

            app.MapDelete(Endpoints.STORAGE.INTERNAL.PRODUCT.DELETE_ITEM + "/{id}", (string id) => mongo.RemoveOneByID(id));

        }
    }
}
