using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SimpleObjectMapper.AspnetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;
using Xunit;

namespace SimpleObjectMapper.Test.AspnetCore
{
    public class ServieCollectionExtensionsTest
    {
        [Fact]
        public void Should_load_all_derive_mappers()
        {

            var service = new ServiceCollection();

            service.AddSimpleObjectMappper(this.GetType().Assembly);
        }

        [Fact]
        public void Close_generic_with_singlton()
        {

            var services = new ServiceCollection();

            var class1SingleInstance = new Class1();
            var class2SingleInstance = new Class2();

            services.AddSingleton<IGeneric<SampleParam1>>(class1SingleInstance);
            services.AddSingleton<IGeneric<SampleParam2>>(class2SingleInstance);
            //services.AddSingleton<IGeneric<SampleParam2>>(x => x.GetRequiredService<Class2>());

            var provider = services.BuildServiceProvider();


            var class1 = provider.GetService<IGeneric<SampleParam1>>();
            var class2 = provider.GetService<IGeneric<SampleParam2>>();

            class1.Should().BeSameAs(class1SingleInstance);
            class2.Should().BeSameAs(class2SingleInstance);

            class2.Should().BeSameAs(class2SingleInstance);
        }

        [Fact]
        public void Close_generic_transient_return_new_object()
        {

            var services = new ServiceCollection();

            services.AddTransient(typeof(IGeneric<SampleParam1>), typeof(Class1));
            services.AddTransient(typeof(IGeneric<SampleParam2>), typeof(Class2));

            var provider = services.BuildServiceProvider();

            var class1 = provider.GetService<IGeneric<SampleParam1>>();
            var class2 = provider.GetService<IGeneric<SampleParam2>>();
            var class2Other = provider.GetService<IGeneric<SampleParam2>>();

            class1.Should().NotBeNull();

            class2.Should().NotBeNull();
            class2.GetHashCode().Should().NotBe(class2Other.GetHashCode());
        }

        [Fact]
        public void Close_generic_transient_return_new_with_reflection_to_register_object()
        {

            var services = new ServiceCollection();
            var interafceDefination1 = typeof(Class1).GetInterfaces()[0];
            var interafceDefination2 = typeof(Class2).GetInterfaces()[0];

            //var interafceDefination3 = typeof(Class2).GetInterfaces()[0].GetGenericTypeDefinition().GetGenericArguments()[0];
            //var inter4 = interafceDefination1.MakeGenericType(interafceDefination3);

            services.AddTransient(interafceDefination1, typeof(Class1));
            services.AddTransient(interafceDefination2, typeof(Class2));

            var provider = services.BuildServiceProvider();

            var sampleParamclass1 = provider.GetService<IGeneric<SampleParam1>>();
            var sampleParam1Other = provider.GetService<IGeneric<SampleParam1>>();

            var class2 = provider.GetService<IGeneric<SampleParam2>>();
            var class2Other = provider.GetService<IGeneric<SampleParam2>>();

            sampleParamclass1.Should().NotBeNull();
            sampleParamclass1.GetHashCode().Should().NotBe(sampleParam1Other.GetHashCode());
            sampleParamclass1.GetType().Should().Be<SampleParam1>();

            class2.Should().NotBeNull();
            class2.GetHashCode().Should().NotBe(class2Other.GetHashCode());
        }
    }
}
