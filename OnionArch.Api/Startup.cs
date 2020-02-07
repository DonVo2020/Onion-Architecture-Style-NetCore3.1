using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnionArch.Domain.Interfaces;
using OnionArch.Infrastructure.Data;
using OnionArch.Services;
using OnionArch.Services.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace OnionArch.Api
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
            services.AddControllers();

            services.AddHttpClient("API Client", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44395/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddRouting(options => options.LowercaseUrls = true);

            DependencyInjectionSystem(services);

            services.AddDbContext<CreditContext>
               (options => options.UseSqlServer(Configuration.GetConnectionString
               ("DefaultConnection"), x => x.MigrationsAssembly("OnionArch.Infrastructure.Data")
                                            .CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds)));

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddApiVersioning(options => options.ReportApiVersions = true)
                    .AddVersionedApiExplorer(options => { options.GroupNameFormat = "'v'VVV"; options.SubstituteApiVersionInUrl = true; })
                    .AddSwaggerGen();

            //services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(policy => policy.AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowAnyOrigin());

            app.UseRouting();

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

        private void DependencyInjectionSystem(IServiceCollection services)
        {
            services.AddOptions();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IBasicMemberService, BasicMemberService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IChargeService, ChargeService>();
            services.AddTransient<IChargeWideService, ChargeWideService>();
            services.AddTransient<ICorpMemberService, CorpMemberService>();
            services.AddTransient<ICorporationService, CorporationService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IOverdueService, OverdueService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IPaymentWideService, PaymentWideService>();
            services.AddTransient<IProviderService, ProviderService>();
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IStatementService, StatementService>();
            services.AddTransient<IStatementWideService, StatementWideService>();
            services.AddTransient<IStatusService, StatusService>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}
