using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.DataAccess;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;
using voresgruppe.ThirdSemesterExamBackend.Domain.Services;
using voresgruppe.ThirdSemesterExamBackend.Security;
using voresgruppe.ThirdSemesterExamBackend.Security.IRepositories;
using voresgruppe.ThirdSemesterExamBackend.Security.IServices;
using voresgruppe.ThirdSemesterExamBackend.Security.Repositories;
using voresgruppe.ThirdSemesterExamBackend.Security.Services;

namespace voresgruppe.ThirdSemesterExamBackend.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo() {Title = "voresgruppe.ThirdSemesterExamBackend.WebApi", Version = "v1"});
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddAuthentication(authenticationOptions =>
                {
                    authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"])),
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["Jwt:Audience"],
                        ValidateLifetime = true
                    };
                });

                

            //Setting up dependency injection
                //MainDbSeeder
            services.AddScoped<IMainDbSeeder, MainDbSeeder>();
                //HairStyle
            services.AddScoped<IHairstyleRepository, HairstyleRepository>();
            services.AddScoped<IHairStyleService, HairstyleService>();
                //Customer
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
                //Admin
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

                //Security
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthUserService>();
            services.AddScoped<IAuthDbSeeder, AuthDbSeeder>();

                //Appointment
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            

            
            //Setting up DB info
            services.AddDbContext<MainDbContext>(
                options =>
                {
                    options.UseSqlite("Data Source=main.db");
                });
            //Setup Security Context
            services.AddDbContext<AuthDbContext>(
                options =>
                {
                    options.UseSqlite("Data Source=auth.db");
                });
            
            services.AddCors(options =>
            {
                options.AddPolicy("Dev-cors", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
                options.AddPolicy("Prod-cors", policy =>
                {
                    policy.WithOrigins("https://thirdsemesterexam-d35a1.firebaseapp.com",
                            "https://thirdsemesterexam-d35a1.web.app")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MainDbContext context, AuthDbContext authDbContext, ISecurityService securityService,
            IMainDbSeeder mainDbSeeder, IAuthDbSeeder authDbSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "voresgruppe.ThirdSemesterExamBackend.WebApi"));
                app.UseCors("Dev-cors");
                mainDbSeeder.SeedDevelopment();
                authDbSeeder.SeedDevelopment();
            }
            else
            {
                app.UseCors("Prod-cors");
                mainDbSeeder.SeedProduction();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}