
using Common;
using Common.DataStructure;
using Storage.src;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
MongoDBWraper mongo = new() ;
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.MapGet(Endpoints.STORAGE.GET_ITEM_IN, () =>
{
    return "default store route";
});
app.MapGet(Endpoints.STORAGE.GET_ITEMS_IN, () =>
{
    return mongo.GetAll();
});

app.MapPost(Endpoints.STORAGE.POST_ITEM_IN, (Product product) => mongo.Inser(product));
app.MapPost(Endpoints.STORAGE.DELETE_ITEM_ID_IN, (Product product) =>
{
    mongo.RemoveOneByID(product);
});
app.Run();
