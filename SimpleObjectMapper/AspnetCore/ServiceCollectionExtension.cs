using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleObjectMapper.AspnetCore
{
    public static class ServiceCollectionExtension
    {
        //TODO: Need to fix this as for now i do not know how to do Assembly.GetExecutingAssembly() for AspnetCore apps
        public static IServiceCollection AddSimpleObjectMappper(this IServiceCollection services, Assembly assembly)
        {
            //var types = Assembly.GetExecutingAssembly()
            //                    .GetTypes()
            //                    .Where(t => t.IsClass)
            //                    .Where(tt => tt.GetInterface(typeof(IMapper<,>).Name) != null);

            var typ = assembly.GetTypes()
                                .Where(t => t.IsClass)
                                .Where(t => t.GetInterfaces()
                                                .Any(t => t.IsGenericType
                                                            && t.GetGenericTypeDefinition() == typeof(IMapper<,>))
                                );

            return services;
        }
    }
}
