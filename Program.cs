using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Data;
using PoliziaMunicipale.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Data Source=(local)\\SQLEXPRESS;Database=PoliziaMunicipale;Trusted_Connection=True;TrustServerCertificate=True;"));

// Services (DI)
builder.Services.AddScoped<IAnagraficaService, AnagraficaService>();
builder.Services.AddScoped<ITipoViolazioneService, TipoViolazioneService>();
builder.Services.AddScoped<IVerbaleService, VerbaleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
