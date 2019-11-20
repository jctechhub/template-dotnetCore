using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using mvcWeb.Models;

namespace mvcWeb
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
