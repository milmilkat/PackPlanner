using PackPlanner.Repository.Context;
using PackPlanner.Repository.Implementations;
using PackPlanner.Repository.Interfaces;
using PackPlanner.Services.Implementations;
using PackPlanner.Services.Interfaces;
using PackPlanner.Utils.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>();
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddTransient<IPackService, PackService>();
builder.Services.AddTransient<IPackRepository, PackRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddControllers();
//builder.Services.AddAutoMapper();
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
