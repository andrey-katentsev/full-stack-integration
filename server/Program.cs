var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddSingleton<CacheService>();
builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseCors(policy =>
		policy.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());

app.MapGet("/", () => "ASP.NET");

app.MapGet("/api/productlist", (CacheService cache) =>
{
	return cache.GetOrCreate("products", entry =>
	{
		entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
		return Data.LoadProducts();
	});
});

app.Run();