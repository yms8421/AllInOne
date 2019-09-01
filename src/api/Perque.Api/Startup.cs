using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Perque.Business;
using Perque.Business.Abstractions;
using Perque.Contracts;
using Perque.Data;
using Perque.Data.Context;
using Perque.Data.Repository;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Perque.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);
            services.AddDbContext<PerqueContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptions<AppSettings>>();

            services.AddScoped<DbContext, PerqueContext>(ctx => new PerqueContext(options));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            var context = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            services.AddScoped<IClaims, AuthClaims>(sp => 
            {
                return new AuthClaims(context.HttpContext.User);
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Values Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                                                        {
                                                            In = "header",
                                                            Description = "Token bilgisini buraya yapıştırın",
                                                            Name = "Authorization",
                                                            Type = "apiKey"
                                                        });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "Bearer", Enumerable.Empty<string>() },
            });

            });
            services.AddCors();

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            )
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = options.Value.Jwt.Issuer,
                    ValidateIssuer = true,
                    ValidIssuer = options.Value.Jwt.Issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Jwt.SecretKey))
                };
                o.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = ctx =>
                    {
                        return ctx.Response.WriteAsync($"Exception: {ctx.Exception.Message}");
                    }
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(opt =>
            {
                if (env.IsDevelopment())
                {
                    opt.WithOrigins("http://localhost:5002", "http://localhost:5001")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                }
            });
            app.UseAuthentication();
            app.UseMvc();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Perque.Api");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
