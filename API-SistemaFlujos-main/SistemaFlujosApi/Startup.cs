
using api.grupokmm.flujos.Helpers;
using api.grupokmm.flujos.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NSwag.Generation.Processors.Security;
using System;
using System.Text;

namespace api.grupokmm.flujos
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSwaggerDocument(document =>
            {
                // Add an authenticate button to Swagger for JWT tokens
                document.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
                document.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT", new NSwag.OpenApiSecurityScheme
                {
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}. You can get a JWT token from /Authorization/Authenticate."
                }));

                // Post process the generated document
                document.PostProcess = d =>
                {
                    d.Info.Version = SwaggerConfiguration.DocNameV1;
                    d.Info.Title = SwaggerConfiguration.DocInfoTitle;
                    d.Info.Description = SwaggerConfiguration.DocInfoDescription;
                    d.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = SwaggerConfiguration.ContactName,
                        Url = SwaggerConfiguration.ContactUrl
                    };
                };

            });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<BitacorasServices, BitacorasServices>();
            services.AddScoped<ClasificacionesServices, ClasificacionesServices>();
            services.AddScoped<CobradoRealServices, CobradoRealServices>();
            services.AddScoped<ConceptoServices, ConceptoServices>();
            services.AddScoped<DepartamentoServices, DepartamentoServices>();
            services.AddScoped<DetalleProyeccionServices, DetalleProyeccionServices>();
            services.AddScoped<DiaSemanaServices, DiaSemanaServices>();
            services.AddScoped<EmpresaServices, EmpresaServices>();
            services.AddScoped<InstitucionesServices, InstitucionesServices>();
            services.AddScoped<LineasCreditoServices, LineasCreditoServices>();
            services.AddScoped <ProyeccionServices, ProyeccionServices>();
            services.AddScoped<RolesAsignadoServices , RolesAsignadoServices>();
            services.AddScoped<RolesServices, RolesServices>();
            services.AddScoped<SemanaServices , SemanaServices>();
            services.AddScoped<SesionesServices , SesionesServices>();
            services.AddScoped<TipoProyeccionServices, TipoProyeccionServices>();
            services.AddScoped<TiposMovimientoBitacoraServices , TiposMovimientoBitacoraServices>();
            services.AddScoped<UsuariosServices , UsuariosServices>();
            services.AddScoped<VariacionProyeccionServices , VariacionProyeccionServices>();
            services.AddScoped<BillServices, BillServices>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseOpenApi();
            app.UseSwaggerUi3(cfg =>
            {
                cfg.CustomStylesheetPath = new Uri("/swagger-ui.css", UriKind.Relative).ToString();
            });

            app.UseMvc();
        }
    }
}