using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleObjectMapper.AspnetCore;

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
            //services.AddTransient<IMapper<>, TestClass>();
            //services.AddTransient<IMapper, TestClass2>();
            //services.AddTransient(typeof(IGeneric<>), typeof(Class1));
            //services.AddTransient(typeof(IGeneric<>), typeof(Class2));
            services.AddSimpleObjectMappper(typeof(Startup).Assembly);
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

    public class SampleParam1 { }
    public interface IGeneric<T>
    {
        void Process(T parameter);
    }
    public class Class1 : IGeneric<SampleParam1>
    {
        public void Process(SampleParam1 parameter)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Class2 : IGeneric<SampleParam2>
    {
        public void Process(SampleParam2 parameter)
        {
            throw new System.NotImplementedException();
        }
    }

    public class SampleParam2
    {
    }
}
