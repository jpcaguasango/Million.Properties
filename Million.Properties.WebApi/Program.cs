using Application.Services;
using Million.Properties.Domain.Interfaces;
using Million.Properties.Domain.Ports;
using Million.Properties.MongoDBRepository;
using Million.Properties.WebApi.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Configure service
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

builder.Services.AddAutoMapper(typeof(GlobalProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMongoDb();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IPropertiesService, PropertiesService>();
builder.Services.AddSingleton<IUnsplashService, UnsplashService>();
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<MongoDbSettings>>().Value);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
