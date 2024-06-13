using ForUserApi.Common.Helpers;
using ForUserApi.DbContexts;
using ForUserApi.Interfaces.Repositories;
using ForUserApi.Interfaces.Services;
using ForUserApi.Repositories;
using ForUserApi.Services;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.Configure<ConfigurationOptions>(
                builder.Configuration.GetSection("RedisCacheOptions"));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisCacheConnectionString");
    options.InstanceName = "UsersAPI";
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DevelopmentDb"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddTransient<IUserInterface, UserRepository>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRedisService, RedisService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Services.GetService<IHttpContextAccessor>() is not null)
{
    HttpContextHelper.Accessor = app.Services.GetRequiredService<IHttpContextAccessor>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
