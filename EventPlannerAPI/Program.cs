using Library.DataAccessService;
using Library.DataContext.SecurityContext;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using Library.DataContext.Data;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace EventPlannerAPI
{

    public class Program
    {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; });

            builder.Services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new OpenApiInfo
                {

                    Version = "v1",
                    Title = "ZUYD event planner API",
                    Description = "This is a .net core web API for the zuyd event planner application.",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {

                        Name = "More info",
                        Url = new Uri("https://github.com/Anruina/EventPlannerCasus")

                    },
                    License = new OpenApiLicense
                    {

                        Name = "This is the current license that applies.",
                        Url = new Uri("https://github.com/Anruina/EventPlannerCasus/blob/master/LICENSE.txt")

                    }

                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddProgramContext("Server=.;Database=EventPlannerCasusData;Trusted_Connection=True;TrustServerCertificate=True");
            builder.Services.AddSecurityContext("Server=.;Database=EventPlannerCasusSecurity;Trusted_Connection=True;TrustServerCertificate=True");

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {

                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.User.RequireUniqueEmail = true;

            })
            .AddEntityFrameworkStores<SecurityDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddScoped<DataAccessService>();

            var app = builder.Build();

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
