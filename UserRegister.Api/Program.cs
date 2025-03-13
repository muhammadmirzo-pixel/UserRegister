
using Microsoft.EntityFrameworkCore;
using UserRegister.Api.Middlewares;
using UserRegister.Data.AppsDbContext;
using UserRegister.Data.IRepositories;
using UserRegister.Data.Repositories;
using UserRegister.Service.Interfaces;
using UserRegister.Service.Mappers;
using UserRegister.Service.Services;

namespace UserRegister.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(option
            => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        //MiddleWares
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionHandlerMiddleware>(); 

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
