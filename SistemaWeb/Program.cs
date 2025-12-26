using Microsoft.AspNetCore.Builder;
using SistemaWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddScoped<SP_Opciones, SP_Opciones>();
builder.Services.AddScoped<SP_Puesto, SP_Puesto>();
builder.Services.AddScoped<SP_Departamento, SP_Departamento>();
builder.Services.AddScoped<SP_Localidad, SP_Localidad>();
builder.Services.AddScoped<SP_Tipo, SP_Tipo>();
builder.Services.AddScoped<SP_Estatus, SP_Estatus>();
builder.Services.AddScoped<SP_Resguardo, SP_Resguardo>();
builder.Services.AddScoped<SP_Office, SP_Office>();
builder.Services.AddScoped<SP_Select_Empleado, SP_Select_Empleado>();
builder.Services.AddScoped<SP_Procesador, SP_Procesador>();
builder.Services.AddScoped<SP_Ram, SP_Ram>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

//app.Use(async (context, next) =>
//{
//    context.Response.OnStarting(state =>
//    {
//        var httpContext = (HttpContext)state;
//        httpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
//        httpContext.Response.Headers.Add("Pragma", "no-cache");
//        httpContext.Response.Headers.Add("Expires", "0");
//        return Task.CompletedTask;
//    }, context);

//    await next();
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");
app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//builder.Services.AddSession(options =>
//{
//	options.IdleTimeout = TimeSpan.FromMinutes(20); // Tiempo de expiración de la sesión
//	options.Cookie.HttpOnly = true;
//	options.Cookie.IsEssential = true;
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
//app.UseSession();
//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//	name: "Usuarios",
//	pattern: "{controller=Usuarios}/{action=Listar}/{id?}");

//app.Run();
