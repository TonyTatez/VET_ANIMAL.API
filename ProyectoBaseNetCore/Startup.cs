using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProyectoBaseNetCore.Controllers;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Filters;
using ProyectoBaseNetCore.Middlewares;
using ProyectoBaseNetCore.Services;
using ProyectoBaseNetCore.Utilidades;
using Serilog;
using Serilog.Events;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace ProyectoBaseNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string projectName = Assembly.GetEntryAssembly().GetName().Name;
            services.AddControllers(opciones =>
            {
                //Log para captar todos los exeptions no capturados
                opciones.Filters.Add(typeof(ExceptionFilter));
            }).AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles).AddNewtonsoftJson();
            //QRCode
            services.AddTransient<QRCodeService>();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
                .WriteTo.File($"logs/{projectName}-.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog(Log.Logger);
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            //Autenticacion
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(opciones => opciones.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTKey"])),
                    ClockSkew = TimeSpan.Zero
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Proyecto_VetAnimalPlace.API",
                    Version = "v1",
                    Description = "Este es un Proyecto Base de API REST en .NET Core",
                    Contact = new OpenApiContact
                    {
                        Email = "atatez@apptelink.com",
                        Name = "Anthony Tatez",
                        Url = new Uri("https://Geo.blog")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT"
                    },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[]{}
                    }
                });


                var archivoXML = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var rutaXML = Path.Combine(AppContext.BaseDirectory, archivoXML);
                c.IncludeXmlComments(rutaXML);
                ////Omitir Endpoint que no pueden ser mapeados por swagger
                //c.DocInclusionPredicate((docName, apiDesc) => !new[] {
                //        (typeof(PruebasController), "Respuestas"),
                //       // (typeof(OtroControlador), "OtroMetodo")
                //      }.Any(t =>
                //      {
                //          var methodInfo = apiDesc.TryGetMethodInfo(out var info) ? info : null;
                //          return methodInfo != null && t.Item1 == methodInfo.DeclaringType && t.Item2 == methodInfo.Name;
                //      }));
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddAuthorization(opciones =>
            {
                opciones.AddPolicy("EsAdmin", politica => politica.RequireClaim("esAdmin"));
                //opciones.AddPolicy("EsVendedor", politica => politica.RequireClaim("esVendedor"));
            });
            services.AddScoped<LinqHelper>();
            services.AddDataProtection();

            services.AddTransient<HashService>();

            //CORS es relevante para navegadores y proyectos hechos en react, angular, etc, para aplicaciones moviles y de mas no tiene sentido realizarlo
            services.AddCors(opciones =>
            {
                opciones.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://www.apirequest.io").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders(new string[] { "cantidadTotalRegistros" });
                });
            });
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            //Captar todas las peticiones en logs y en terminal
            app.UseMiddleware<LogHTTPResponseMiddleware>();
            app.UseLoggerResponseHTTP();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProyectoBaseNetCore v1");
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            //CORS es relevante para navegadores y proyectos hechos en react, angular, etc, para aplicaciones moviles y de mas no tiene sentido realizarlo
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //    endpoints.MapHub<ChatHub>("/chatHub"); // Configura el hub de SignalR
            });
        }
    }
}