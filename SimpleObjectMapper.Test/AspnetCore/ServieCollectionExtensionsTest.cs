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
        public void Close_genericText()
        {

            var services = new ServiceCollection();

            var class1Instance = new Class1();
            var class2SingleInstance = new Class2();

            services.AddSingleton<IGeneric<SampleParam1>>(class1Instance);
            services.AddSingleton<IGeneric<SampleParam2>>(class2SingleInstance);
            services.AddTransient(typeof(IGeneric<SampleParam2>), typeof(Class2));
            //services.AddSingleton<IGeneric<SampleParam2>>(x => x.GetRequiredService<Class2>());

            var provider = services.BuildServiceProvider();


            var class1 = provider.GetService<IGeneric<SampleParam1>>(); // An instance of Foo
            var class2 = provider.GetService<IGeneric<SampleParam2>>(); // An instance of Foo

            var class2Transit = provider.GetService<IGeneric<SampleParam2>>(); // An instance of Foo

            class1.Should().BeSameAs(class1Instance);
            class2.Should().BeSameAs(class2SingleInstance);

            class2.Should().BeSameAs(class2SingleInstance);
        }

        [Fact]
        public void Close_genericText1()
        {

            var services = new ServiceCollection();

            var class1Instance = new Class1();
            var class2SingleInstance = new Class2();

            //services.AddSingleton<IGeneric<SampleParam1>>(class1Instance);
            //services.AddSingleton<IGeneric<SampleParam2>>(class2SingleInstance);
            services.AddTransient(typeof(Class2).GetInterfaces()[0], typeof(Class2));
            services.AddTransient(typeof(Class1).GetInterfaces()[0], typeof(Class1));
            //services.AddSingleton<IGeneric<SampleParam2>>(x => x.GetRequiredService<Class2>());

            var provider = services.BuildServiceProvider();


            var class1 = provider.GetService<IGeneric<SampleParam1>>(); // An instance of Foo
            var class2 = provider.GetService<IGeneric<SampleParam2>>(); // An instance of Foo

            var class2Transit = provider.GetService<IGeneric<SampleParam2>>(); // An instance of Foo

            class1.Should().BeSameAs(class1Instance);
            class2.Should().BeSameAs(class2SingleInstance);

            class2.Should().BeSameAs(class2SingleInstance);
        }
    }
}
