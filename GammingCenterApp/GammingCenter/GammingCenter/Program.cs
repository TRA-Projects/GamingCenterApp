using GammingCenter.Repositories;
using GammingCenter.Services;
using Microsoft.EntityFrameworkCore;

// JWT Authentication
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GammingCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Register services in the Dependency Injection container
            var builder = WebApplication.CreateBuilder(args);


            ////////////////////////////////////////////////////////////////////
            // 1- Register Database Context
            ////////////////////////////////////////////////////////////////////

            // Register DbContext with SQL Server
            // Scoped lifetime creates one DbContext instance per HTTP request
            builder.Services.AddDbContext<GammingCenterContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString(
                        "DefaultConnection"
                    )
                )
            );


            ////////////////////////////////////////////////////////////////////
            // 2- Register Repositories
            ////////////////////////////////////////////////////////////////////

            // Register repositories in Dependency Injection
            // Repositories are responsible for accessing the database

            builder.Services.AddScoped<VisitorRepository>();
            builder.Services.AddScoped<RoomRepository>();
            builder.Services.AddScoped<ReviewRepository>();
            builder.Services.AddScoped<PaymentRepository>();
            builder.Services.AddScoped<GamingDeviceRepository>();
            builder.Services.AddScoped<CompetitionRepository>();
            builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddScoped<BookingRepository>();
            builder.Services.AddScoped<BookingTypeRepository>();
            builder.Services.AddScoped<AvailableSlotRepository>();

            


            ////////////////////////////////////////////////////////////////////
            // 3- Register Services
            ////////////////////////////////////////////////////////////////////

            // Register services in Dependency Injection
            // Services contain the business logic of the application

            builder.Services.AddScoped<VisitorService>();
            builder.Services.AddScoped<RoomService>();
            builder.Services.AddScoped<ReviewService>();
            builder.Services.AddScoped<PaymentService>();
            builder.Services.AddScoped<GamingDeviceService>();
            builder.Services.AddScoped<CompetitionService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<BookingService>();
            builder.Services.AddScoped<BookingTypeService>();
            builder.Services.AddScoped<AvailableSlotService>();

            // Email Service
            builder.Services.AddScoped<EmailService>();

            // Authentication Service
            builder.Services.AddScoped<AuthService>();


            ////////////////////////////////////////////////////////////////////
            // 4- Configure JWT Authentication
            ////////////////////////////////////////////////////////////////////

            // Add JWT Bearer Authentication
            // The API uses JWT Token to authenticate users
            builder.Services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme
            )
            .AddJwtBearer(options =>
            {
                // Configure how the JWT Token should be validated
                options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        // Validate the token signature
                        ValidateIssuerSigningKey = true,

                        // Get the secret key from appsettings.json
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(
                                    builder.Configuration["Jwt:Key"]
                                )
                            ),


                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["Jwt:Audience"],

                        ValidateLifetime = true
                    };
            });


            ////////////////////////////////////////////////////////////////////
            // 5- Add Authorization

            // Enable authorization for protected endpoints
            builder.Services.AddAuthorization();


   

            // Register API Controllers
            builder.Services.AddControllers();



            ////////////////////////////////////////////////////////////////////
            // 7- Configure Swagger / OpenAPI with JWT

            // Enable API Explorer
            builder.Services.AddEndpointsApiExplorer();

            // Configure Swagger to support JWT Authentication
            builder.Services.AddSwaggerGen(options =>
            {
                // Add JWT Bearer Authentication to Swagger
                options.AddSecurityDefinition(
                    "Bearer",
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,

                        // Explain how to enter the JWT Token
                        Description =
                            "Enter your JWT token: "
                    });

                // Apply JWT Authentication to Swagger requests
                options.AddSecurityRequirement(
                    new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                    {
                        {
                            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                            {
                                Reference =
                                    new Microsoft.OpenApi.Models.OpenApiReference
                                    {
                                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                            },

                            Array.Empty<string>()
                        }
                    });
            });


            // Build Application
        

            var app = builder.Build();


            ////////////////////////////////////////////////////////////////////
            // 9- Configure HTTP Request Pipeline
            ////////////////////////////////////////////////////////////////////

            if (app.Environment.IsDevelopment())
            {
       
                app.UseSwagger();

                app.UseSwaggerUI();
            }


            // Redirect HTTP requests to HTTPS
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        }
    }
}