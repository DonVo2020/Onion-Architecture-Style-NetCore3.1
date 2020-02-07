using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OnionArch.Domain.Entities;
using OnionArch.Infrastructure.Data;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace OnionArch.AuthService
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
            services.AddCors();
            //services.AddDbContext<AuthContext>(options =>
            //    options.UseSqlServer(
            //    Configuration.GetConnectionString("SqlConnectionString")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<AuthContext>()
               .AddDefaultTokenProviders();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddControllers();

            services.AddHttpClient("API Client", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44353/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddDbContext<AuthContext>
               (options => options.UseSqlServer(Configuration.GetConnectionString
               ("SqlConnectionString"), x => x.MigrationsAssembly("OnionArch.Infrastructure.Data")
                                            .CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds)));

            //JWT
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme =
                JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["JwtIssuer"],
                    ValidAudience = Configuration["JwtIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                          Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddNewtonsoftJson(opt =>
                opt.SerializerSettings.ReferenceLoopHandling =
                ReferenceLoopHandling.Ignore);

            services.AddApiVersioning(options => options.ReportApiVersions = true)
                    .AddVersionedApiExplorer(options => { options.GroupNameFormat = "'v'VVV"; options.SubstituteApiVersionInUrl = true; })
                    .AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(policy => policy.AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowAnyOrigin());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
                c.DocExpansion(DocExpansion.None);
                c.EnableValidator();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
