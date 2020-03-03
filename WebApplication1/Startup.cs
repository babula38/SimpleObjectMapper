using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomAutomapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication1
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
            services.AddControllers();
            //services.AddTransient<IMapper, TestClass>();
            //services.AddTransient<IMapper, TestClass2>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    //public static class ServiceCollectionExtensions
    //{
    //    public static void AddScopedDynamic<TInterface>(this IServiceCollection services, IEnumerable<Type> types)
    //    {
    //        services.AddScoped<Func<string, TInterface>>(serviceProvider => tenant =>
    //        {
    //            //var type = types.FilterByInterface<TInterface>()
    //            //                .Where(x => x.Name.Contains(tenant))
    //            //                .FirstOrDefault();

    //            //if (null == type)
    //            //    throw new KeyNotFoundException("No instance found for the given tenant.");

    //            return (TInterface)serviceProvider.GetService(null);
    //        });
    //    }
    //}
}
