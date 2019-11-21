using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DotnetCore.WebClient.Models;

namespace DotnetCore.WebClient
{
    public class AutofacServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<BookRepo>().As<IBookRepo>();
        }
    }
}
