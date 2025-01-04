using DBExplorer.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register HttpClient with the IHttpClientFactory pattern for injection into services
builder.Services.AddHttpClient<DatabaseService>(client =>
{
  client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5002");
});

builder.Services.AddHttpClient<DataOperationsService>(client =>
{
  client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5002");
});

builder.Services.AddHttpClient<QueryService>(client =>
{
  client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5002");
});

// Register services
builder.Services.AddScoped<DatabaseService>();
builder.Services.AddScoped<DataOperationsService>();
builder.Services.AddScoped<QueryService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
