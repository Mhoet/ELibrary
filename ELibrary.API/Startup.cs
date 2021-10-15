using ELibrary.API.Data;
using ELibrary.API.Model;
using ELibrary.API.Repository;
using ELibrary.API.Services;
using ELibrary.API.Services.ImageUploadService;
using ELibrary.API.Services.ImageUploadService.Interface;
using ELibrary.API.Services.PaginationService;
using ELibrary.API.Services.PaginationService.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace ELibrary.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ElibraryDbContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            //This service configures implementation for accessing HttpClient
            services.AddHttpContextAccessor();
            //This service configures implementation for getting the base url
            services.AddSingleton<IPageUriService>(options =>
            {
                var accessor = options.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new PageUriService(uri);
            });

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ElibraryDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options => options.User.RequireUniqueEmail = true);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = Configuration["JwtSettings:Audience"],
                        ValidIssuer = Configuration["JwtSettings:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding
                        .UTF8.GetBytes(Configuration["JwtSettings:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IBookRepository, BookRepository>()
                .AddTransient<IRatingRepository, RatingRepository>()
                .AddTransient<IReviewRepository, ReviewRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ELibrary.API", Version = "v1" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "Authorization header with the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
              { securitySchema, new[] { "Bearer" } }
            });
            });

            services.AddScoped<IUploadImage, UploadImage>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthUser, AuthUser>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<UploadSettings>(Configuration.GetSection("UploadSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager,
        UserManager<User> userManager, ElibraryDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ELibrary.API v1"));
                ELibrarySeeder.SeedELibraryDb(roleManager, userManager, context);
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected error was detected. Please try again later!");
                    });
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}