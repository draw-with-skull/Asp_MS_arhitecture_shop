
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

app.MapGet(Endpoints.STORAGE_INTERNAL.GET_ITEM+"/{id}", (string id) =>
{
    return mongo.GetItemByID(id);
});
app.MapGet(Endpoints.STORAGE_INTERNAL.GET_ITEMS, () =>
{
    return mongo.GetAll();
});

app.MapPost(Endpoints.STORAGE_INTERNAL.POST_ITEM, (Product product) => mongo.Inser(product));
app.MapDelete(Endpoints.STORAGE_INTERNAL.DELETE_ITEM +"/{id}", (string id) => mongo.RemoveOneByID(id));

app.Run();
