using Microsoft.Extensions.Options;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using System.Reflection;
using WebCommerce.Catalog.Services.CategoryServices;
using WebCommerce.Catalog.Services.ProductDetailServices;
using WebCommerce.Catalog.Services.ProductImageServices;
using WebCommerce.Catalog.Services.ProductServices;
using WebCommerce.Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
//builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
//builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
//builder.Services.AddScoped<IFeatureService, FeatureService>();
//builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
//builder.Services.AddScoped<IBrandService, BrandService>();
//builder.Services.AddScoped<IAboutService, AboutService>();
//builder.Services.AddScoped<IContactService, ContactService>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
