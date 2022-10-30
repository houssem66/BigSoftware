using Data;
using Data.Entities;
using Data.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Repository.Implementation;
using Repository.Implmentation;
using Repository.Interfaces;
using Services.Implementation;
using Services.Interfaces;
using System.Reflection;
using System.Text;
using WebApi.Helpers;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        string policyName = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
      

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.ConfigureRepositoryWrapper();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //Conection string
            services.AddDbContext<BigSoftContext>(options =>
                           options.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddControllers();

            //JSON
            services.AddMvc(option => option.EnableEndpointRouting = false)
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            #region SwaggerConfig
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BigSoftWare", Version = "v1" });
            });
            #endregion
            //SignalIR
            services.AddSignalR();
            #region Repositories AddScoped

            //Add GenericRepo
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Sprint 1
            services.AddScoped(typeof(IFournisseurRepo), typeof(FournisseurRepo));
            services.AddScoped(typeof(IUserRepo), typeof(UserRepo));
            services.AddScoped(typeof(IGrossiteRepo), typeof(GrossisteRepo));

            //Sprint2
          


            #endregion


            #region Services Addtransient
            //sprint1
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGrossisteService, GrossisteService>();
            services.AddTransient<IFournisseurService, FournisseurService>();
            services.AddTransient<IMailingService, MailingService>();

            //sprint2
        
            #endregion
            #region JWT Config 
            //Identity Config
            services.AddIdentity<Utilisateur, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;

            }

           ).AddEntityFrameworkStores<BigSoftContext>()
            .AddDefaultTokenProviders();
            // JWT Config
            services.Configure<JWT>(Configuration.GetSection("JWT"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                 .AddJwtBearer(o =>
                 {
                     o.RequireHttpsMetadata = false;
                     o.SaveToken = false;
                     o.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidIssuer = Configuration["JWT:Issuer"],
                         ValidAudience = Configuration["JWT:Audience"],
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                     };
                 });
            #endregion
            #region Mail
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseCors(options =>
                         options.WithOrigins("http://localhost:3000")
                         .AllowCredentials()
                         .AllowAnyMethod()
                         .AllowAnyHeader());


            app.UseMvc();
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BigSoftWare v1"));
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
