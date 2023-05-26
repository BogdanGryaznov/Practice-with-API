using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApiShop2Context>(
                options => options.UseSqlServer(
                    "Server=lab116-p;Database=API-SHOP-2;User Id=sa;Password=12345;TrustServerCertificate=true"));

            builder.Services.AddScoped<Domain.Interfaces.IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Интернет-магазин API",
                    Description = "Куплю-продам гараж",
                    Contact = new OpenApiContact
                    {
                        Name = "Name",
                        Url = new Uri("https://youtu.be/QLyhfakB-QY")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License",
                        Url = new Uri("https://www.washingtonpost.com/wp-srv/national/longterm/unabomber/manifesto.text.htm")
                    }
                });   

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

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
        }
    }
}