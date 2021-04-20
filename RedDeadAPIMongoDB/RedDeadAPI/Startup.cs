using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RedDeadAPI.Helpers;
using RedDeadAPI.Interfaces;
using RedDeadAPI.Models;
using RedDeadAPI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RedDeadAPI
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
			services.AddCors(options =>
			{
				options.AddPolicy("AllowMyOrigin",
				builder => builder.WithOrigins(
					"http://localhost:8080")
					.WithMethods("POST", "GET", "PUT")
					.AllowAnyHeader()
					);
			});
			// requires using Microsoft.Extensions.Options
			services.Configure<RedDeadAPITestDatabaseSettings>(
				Configuration.GetSection(nameof(RedDeadAPITestDatabaseSettings)));

			services.AddSingleton<IRedDeadAPIDatabaseSettings>(sp =>
				sp.GetRequiredService<IOptions<RedDeadAPITestDatabaseSettings>>().Value);

			services.AddSingleton<ItemService>();
			services.AddSingleton<GameService>();
			services.AddSingleton<WeaponService>();
			services.AddSingleton<MountService>();
			services.AddSingleton<PersonService>();
			services.AddSingleton<LocationService>();
			services.AddScoped<IUserService, UserService>();

			services.AddAuthentication("BasicAuthentication")
				.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

			services.AddControllers();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo 
				{ 
					Title = "RedDeadAPI",
					Version = "v1",
					Description = "The Red Dead Series API with data from every Red Dead Game... even Revolver! Have all the data you want from the three games: Games, Items, Locations, Mounts, People, Weapons.",
					TermsOfService = new Uri("https://example.com/terms"),
					Contact = new OpenApiContact
					{
						Name = "Christian Moore",
						Email = string.Empty,
						Url = new Uri("https://www.linkedin.com/in/christiangmoore/"),
					},
				});
				// Set the comments path for the Swagger JSON and UI.
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseStaticFiles();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "RedDeadAPI");
				c.RoutePrefix = string.Empty;
				c.InjectStylesheet("/Assests/css/filename.css");
			});
			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseCors("AllowMyOrigin");
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
