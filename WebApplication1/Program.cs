using ClassLibrary1;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<MyWallet>(sp =>
{
    return new MyWallet(1000);
});

builder.Services.AddScoped<MyService>();

var app = builder.Build();

app.UseMyMiddleware();

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello World \r\n");
});

app.Run();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();

