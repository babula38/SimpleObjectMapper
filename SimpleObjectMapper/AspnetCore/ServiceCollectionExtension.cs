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

            assembly.GetTypes()
                    .Where(t => t.IsClass)
                    .Where(t => t.GetInterfaces()
                                    .Any(t => t.IsGenericType
                                                && t.GetGenericTypeDefinition() == typeof(IMapper<,>)))
                    .ToList()
                         .ForEach(implementationType =>
                         {
                             var serviceType = implementationType.GetInterfaces()
                                                            .First(i => i.GetGenericTypeDefinition() == typeof(IMapper<,>));
                             services.AddTransient(serviceType, implementationType);
                         });

            //foreach (var item in typ)
            //{
            //    services.AddTransient(typeof(IMapper<,>), item);
            //}

            //System.Reflection.Assembly.GetExecutingAssembly()
            //                         .GetTypes()
            //                         .Where(t => t.IsClass)
            //                         .Where(item => item.GetInterfaces()
            //                         .Where(i => i.IsGenericType)
            //                                    .Any(i => i.GetGenericTypeDefinition() == typeof(IMapper<,>))
            //                                                        && !item.IsAbstract && !item.IsInterface)
            //                         .ToList()
            //                         .ForEach(assignedTypes =>
            //                         {
            //                             var serviceType = assignedTypes.GetInterfaces()
            //                                                            .First(i => i.GetGenericTypeDefinition() == typeof(IMapper<,>));
            //                             services.AddTransient(serviceType, assignedTypes);
            //                         });


            return services;
        }
    }
}
