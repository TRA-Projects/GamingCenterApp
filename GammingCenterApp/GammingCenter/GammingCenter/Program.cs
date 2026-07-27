
using GammingCenter.Repositories;
using GammingCenter.Services;
using Microsoft.EntityFrameworkCore;

namespace GammingCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {


            //services container ( place to register program services ) / dependency injection container
            var builder = WebApplication.CreateBuilder(args);

            ////////////////////////////////////////////////////////////////////
            

            // Add services to the container

            // 1- register context

            builder.Services.AddDbContext<GammingCenterContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            ////////////////////////////////////////////////////////////////////
            



            // 2- service lifetime

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

            builder.Services.AddScoped<VisitorService>();
            builder.Services.AddScoped<RoomService>();
            builder.Services.AddScoped<ReviewService>();
            builder.Services.AddScoped<PaymentService>();
            builder.Services.AddScoped<GamingDeviceService>();
            builder.Services.AddScoped<CompetitionService>();
            builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddScoped<BookingService>();
            builder.Services.AddScoped<BookingTypeService>();
            builder.Services.AddScoped<AvailableSlotService>();
            builder.Services.AddScoped<EmailService>();

            ////////////////////////////////////////////////////////////////////




            // ── Swagger with JWT
            builder.Services.AddControllers();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // *********************************************************************************



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                //app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
