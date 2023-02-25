using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyStoreAPI.Data;
using VarietyStoreAPI.Repositories;
using VarietyStoreAPI.Repositories.Interfaces;

namespace VarietyStoreAPI {
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) => {
                    services.AddEntityFrameworkSqlServer()
                        .AddDbContext<ManagerSystemDBContext>(
                            options => options.UseSqlServer(hostContext.Configuration.GetConnectionString("DataBase"))
                        );
                    services.AddScoped<IUserRepositorie, UserRepositorie>();
                    services.AddScoped<IProductRepositorie, ProductRepositorie>();
                })
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
