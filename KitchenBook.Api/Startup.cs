using KitchenBook.Domain.UserModel;
using KitchenBook.Infrastructure;
using KitchenBook.Infrastructure.Data.RecipeModel;
using KitchenBook.Infrastructure.Data.UserModel;
using KitchenBook.Infrastructure.Repository;
using KitchenBook.Infrastructure.UoF;
using KitchenBook.Infrastructure.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace KitchenBook.Api
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
            services.AddDbContext<RecipeDbContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("RecipeConnection")));
            services.AddDbContext<UserDbContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("UserConnection")));
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Recipe", Version = "v1" }); });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins(new string[] { "http://localhost:4200" })
                            .AllowAnyMethod().AllowAnyHeader();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recipe v1"));
            }

            app.UseMiddleware<UserAuthenticationMiddleware>();

            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
