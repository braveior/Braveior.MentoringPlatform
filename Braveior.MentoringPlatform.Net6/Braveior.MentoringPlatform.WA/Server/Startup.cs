using Braveior.MentoringPlatform.Repository;
using Braveior.MentoringPlatform.Repository.Models;
using Braveior.MentoringPlatform.Services;
using Braveior.MentoringPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Braveior.MentoringPlatform.WA.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {


                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
            services.AddControllers();



            services.AddControllersWithViews();


           // services.AddScoped<IKanboardService, KanboardService>();
            services.AddScoped<ILoginService, LoginService>();
           // services.AddScoped<IStoryService, StoryService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IVideoBookService, VideoBookService>();
            services.AddScoped<IWebinarService, WebinarService>();

            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("thisisasecretkeyanddontsharewithanyone")),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            });

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Braveior Mentoring API", Version = "v1.0" });

                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };


                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme,new List<string>()}
                });

            });
            services.AddAutoMapper(typeof(Startup));

            services.AddRazorPages();
            services.AddDbContext<braveiordbContext>(options =>
            //options.UseMySql("server=localhost;user=root;password=password;database=taskmanager_dotnet", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql")));
            options.UseSqlServer("Data Source=tcp:s10.everleap.com;Initial Catalog=DB_7090_braveior;User ID=DB_7090_braveior_user;Password=Sreelami1981$$;Integrated Security=False;", providerOptions => providerOptions.EnableRetryOnFailure()));
            //options.UseSqlServer("Server=.\\sqlexpress;Database=DB_7090_braveior;Trusted_Connection=True;", providerOptions => providerOptions.EnableRetryOnFailure()));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            app.UseSwagger();

            app.UseSwaggerUI(ui =>
            {
                ui.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Braveior Mentoring Platform API Endpoint");
            });
        }
    }
}
