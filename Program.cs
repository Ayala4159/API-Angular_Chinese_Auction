using Chinese_Auction.Mappings;
using ChineseAuction.Data;
using ChineseAuction.Repositoreis;
using ChineseAuction.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddControllers();
builder.WebHost.UseStaticWebAssets();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ChinesActionDbContext>(options => options.UseSqlServer("Server=ELBOGEN\\SQLEXPRESS;DataBase=Chinese Auction;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;"));
builder.Services.AddDbContext<ChinesActionDbContext>(options => options.UseSqlServer("Server=DESKTOP-FFFCT8A\\SQLEXPRESS;DataBase=Chinese Auction;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;"));

//repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPackageRepository,PackageRepository>();
builder.Services.AddScoped<IDonorRpository, DonorRpository>();
builder.Services.AddScoped<IGiftRepository, GiftRepository>();
//services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IGiftService, GiftService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();