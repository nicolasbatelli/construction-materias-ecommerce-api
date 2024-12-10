using AutoMapper;
using ConstructionMaterials.Application.Mappings;
using ConstructionMaterials.Application.Models;
using ConstructionMaterials.Application.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ConstructionMaterials.Infrastructure.Repositories;
using ConstructionMaterials.Infrastructure.UnitOfWork;

namespace ConstructionMaterials.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductDto).Assembly));

            return services;
        }

        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            // Add AutoMapper

            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }

        public static IServiceCollection ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]))
                };
            });

            return services;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                // Configure Swagger to use JWT Authentication
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        { 
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
            });

            return services;
        }
    }
}