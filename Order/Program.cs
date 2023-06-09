using Common;
using Common.DataStructure;
using Order.SRC;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Background order Processing
OrderManager orderManager = new(60*1000);// One minute by default

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet(Endpoints.ORDER.INTERNAL.SET_INTERVAL + "/{ms}", (int ms) => orderManager.ChangeTimer(ms));
app.MapGet(Endpoints.ORDER.INTERNAL.START, () => orderManager.StartAsync(cancellationToken: default));
app.MapGet(Endpoints.ORDER.INTERNAL.STOP, () => orderManager.StopAsync(cancellationToken: default));


orderManager.StartAsync(cancellationToken:default);

app.Run();