using Data;
using Data.Entities;
using Data.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Repository.Implementation;
using Repository.Implmentation;
using Repository.Interfaces;
using Services.Implementation;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
         
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
            services.AddScoped(typeof(IClientRepo), typeof(ClientRepo));
            services.AddScoped(typeof(IFournisseurRepo), typeof(FournisseurRepo));
            services.AddScoped(typeof(IUserRepo), typeof(UserRepo));
            services.AddScoped(typeof(IGrossiteRepo), typeof(GrossisteRepo));

            //Sprint2
            services.AddScoped(typeof(IBonDeCommandeFournisseurRepo), typeof(BonDeCommandeFournisseurRepo));
            services.AddScoped(typeof(IBonDeReceptionFournisseurRepo), typeof(BonDeReceptionFournisseurRepo));
            services.AddScoped(typeof(IFactureFournisseurRepo), typeof(FactureFournisseurRepo));

            services.AddScoped(typeof(IDetailsBonCommandeFournisseurRepo), typeof(DetailsBonCommandeFournisseurRepo));
            services.AddScoped(typeof(IDetailsBonReceptionFournisseurRepo), typeof(DetailsBonDeReceptionRepo));
            services.AddScoped(typeof(IDetailsFactureFournisseurRepo), typeof(DetailsFactureRepo));

            services.AddScoped(typeof(IBonCommandeClientRepo), typeof(BonCommandeClientRepo));
            services.AddScoped(typeof(IBonLivraisonClientRepo), typeof(BonLivraisonClientRepo));
            services.AddScoped(typeof(IBonSortieClientRepo), typeof(BonSortieClientRepo));
            services.AddScoped(typeof(IDevisClientRepo), typeof(DevisClientRepo));
            services.AddScoped(typeof(IFactureClientRepo), typeof(FactureClientRepo));

            services.AddScoped(typeof(IDetailsBonSortieClientRepo), typeof(DetailsBonSortieClientRepo));
            services.AddScoped(typeof(IDetailsCommandeClientRepo), typeof(DetailsCommandeClientRepo));
            services.AddScoped(typeof(IDetailsBonSortieClientRepo), typeof(DetailsBonSortieClientRepo));
            services.AddScoped(typeof(IDetailsDevisClientRepo), typeof(DetailsDevisClientRepo));
            services.AddScoped(typeof(IDetailsFactureClientRepo), typeof(DetailsFactureClientRepo));

            services.AddScoped(typeof(IStockProduitRepo), typeof(StockProduitRepo));
            services.AddScoped(typeof(IProduitRepo), typeof(ProduitRepo));
            services.AddScoped(typeof(IStockRepo), typeof(StockRepo));


            #endregion


            #region Services Addtransient
            //sprint1
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGrossisteService, GrossisteService>();
            services.AddTransient<IFournisseurService, FournisseurService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IMailingService, MailingService>();

            //sprint2
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IProduitService, ProduitService>();
            services.AddTransient<IStockProduitService, StockProduitService>();

            services.AddTransient<IBonDeCommandeFournisseurService, BonDeCommandeFournisseurService>();
            services.AddTransient<IBonDeReceptionFournisseurService, BonDeReceptionFournisseurService>();
            services.AddTransient<IFactureFournisseurService, FactureFournisseurService>();

            services.AddTransient<IDetailsBonCommandeFournisseurService, DetailsBonCommandService>();
            services.AddTransient<IDetailsBonDeReceptionFournisseurService, DetailsBonReceptionService>();
            services.AddTransient<IDetailsFactureFournisseurService, DetailsFactureFournisseurService>();

            services.AddTransient<IBonCommandeClientService, BonCommandeClientService>();
            services.AddTransient<IBonLivraisonClientService, BonLivraisonClientService>();
            services.AddTransient<IBonSortieClientService, BonSortieClientService>();
            services.AddTransient<IDevisClientService, DevisClientService>();
            services.AddTransient<IFactureClientService, FactureClientService>();

            services.AddTransient<IDetailsCommandeClientService, DetailsCommandeClientService>();
            services.AddTransient<IDetailsLivraisonClientService, DetailsLivraisonClientService>();
            services.AddTransient<IDetailsBonSortieClientService, DetailsBonSortieClientService>();
            services.AddTransient<IDetailsDevisClientService, DetailsDevisClientService>();
            services.AddTransient<IDetailsFactureClientService, DetailsFactureClientService>();
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
