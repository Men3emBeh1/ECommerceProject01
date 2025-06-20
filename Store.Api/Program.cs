
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Services;
using Services.Abstractions;
using Services.MappingProfiles;
using Shared.ErrorModels;
using Store.Api.Extensions;
using Store.Api.Middlewares;

namespace Store.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.RegisterAllServices(builder.Configuration);

            var app = builder.Build();

            app.ConfigureMiddleWares();

            app.Run();
        }
    }
}
