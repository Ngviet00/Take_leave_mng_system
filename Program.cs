using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using TakeLeaveMngSystem.Application;
using TakeLeaveMngSystem.Application.SeedData;
using TakeLeaveMngSystem.Application.Services;
using TakeLeaveMngSystem.Infrastructure.Data;
using TakeLeaveMngSystem.Presentation.Middleware;

namespace TakeLeaveMngSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnectionDb")));

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<TicketService>();
            builder.Services.AddScoped<AuthService>();

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                DbSeeder.SeedAsync(dbContext).GetAwaiter().GetResult();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.MapControllers();

            //app.UseExceptionHandler("/Home/Error"); 
            //app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");

            app.Run();

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    Global.WriteLog(TYPE_ERROR.ERROR, $"[UnhandledException] {ex.Message}\n{ex.StackTrace}");
                }
            };
        }
    }
}
