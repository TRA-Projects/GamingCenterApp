
using GammingCenter.Repositories;
using GammingCenter.Services;
using Microsoft.EntityFrameworkCore;

namespace GammingCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //// ── Manual wiring ──────────────────────────────────────────────
            //GammingCenterContext context = new GammingCenterContext();

            //// Repositories
            //VisitorRepository visitorRepo = new VisitorRepository(context);
            //GamingDeviceRepository gamingDeviceRepo = new GamingDeviceRepository(context);
            //CategoryRepository categoryRepo = new CategoryRepository(context);
            //BookingRepository bookingRepo = new BookingRepository(context);
            //PaymentRepository paymentRepo = new PaymentRepository(context);
            //RoomRepository roomRepo = new RoomRepository(context);
            //ReviewRepository reviewRepo = new ReviewRepository(context);
            //AvailableSlotRepository availableSlotRepo = new AvailableSlotRepository(context);
            //CompetitionRepository competitionRepo = new CompetitionRepository(context);
            //BookingTypeRepository bookingTypeRepo = new BookingTypeRepository(context);

            //// Services
            //VisitorService visitorService = new VisitorService(visitorRepo);
            //GamingDeviceService gamingDeviceService = new GamingDeviceService(gamingDeviceRepo);
            //CategoryService categoryService = new CategoryService(categoryRepo);
            //BookingService bookingService = new BookingService(bookingRepo);
            //PaymentService paymentService = new PaymentService(paymentRepo);
            //RoomService roomService = new RoomService(roomRepo);
            //ReviewService reviewService = new ReviewService(reviewRepo);
            //AvailableSlotService availableSlotService = new AvailableSlotService(availableSlotRepo);
            //CompetitionService competitionService = new CompetitionService(competitionRepo);
            //BookingTypeService bookingTypeService = new BookingTypeService(bookingTypeRepo);

            //// Presentations
            //VisitorPresentation visitorPresentation = new VisitorPresentation(visitorService);
            //GamingDevicePresentation gamingDevicePresentation = new GamingDevicePresentation(gamingDeviceService);
            //CategoryPresentation categoryPresentation = new CategoryPresentation(categoryService);
            //BookingPresentation bookingPresentation = new BookingPresentation(bookingService);
            //PaymentPresentation paymentPresentation = new PaymentPresentation(paymentService);
            //RoomPresentation roomPresentation = new RoomPresentation(roomService);
            //ReviewPresentation reviewPresentation = new ReviewPresentation(reviewService);
            //AvailableSlotPresentation availableSlotPresentation = new AvailableSlotPresentation(availableSlotService);
            //CompetitionPresentation competitionPresentation = new CompetitionPresentation(competitionService);
            //BookingTypePresentation bookingTypePresentation = new BookingTypePresentation(bookingTypeService);




            var builder = WebApplication.CreateBuilder(args);


            //Connection string
            builder.Services.AddDbContext<GammingCenterContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));








            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
