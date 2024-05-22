using MySql.Data.MySqlClient;
using SpinnerWallArt_FEBE.Server.Models;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;

namespace SpinnerWallArt_FEBE.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<MySqlConnection>(_ =>
            
                new MySqlConnection(builder.Configuration.GetConnectionString("spinner")));             

            builder.Services.AddSingleton<IAdmin, AdminRepository>();
            // Add services to the container.
            builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            var app = builder.Build();

            app.UseDefaultFiles();
           
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "Models/Photos")),
                RequestPath = "/Models/Photos"
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}");

            app.MapFallbackToFile("/index.html");

            app.Run();
  
        }
    }
}
