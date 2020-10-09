using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using wowments_api.Model;

namespace wowments_api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            // Add Cors
            // services.AddCors(o => o.AddPolicy("HealthPolicy", builder => {
            //     builder.AllowAnyOrigin()
            //         .AllowAnyMethod()
            //         .AllowAnyHeader();
            // }));

            services.AddControllers ();
            services.AddMvc ();

            services.AddDbContext<WowMents_DevContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("DefaultConnection")));

            services.AddCors (options => {
                options.AddPolicy ("AllowAllOrigins",
                    builder => {
                        builder.AllowAnyOrigin ();
                        builder.AllowAnyHeader ();
                        builder.AllowAnyMethod ();
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            // app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();
            app.UseCors ("AllowAllOrigins");

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}