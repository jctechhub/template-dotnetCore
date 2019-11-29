using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using mvcWeb.Models;
using mvcWeb.Repo.Data.Initializer;
using mvcWeb.Repo.Data.Repository;
using mvcWeb.Repo.Data.Repository.IRepository;

namespace mvcWeb
{
    public class AutofacServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<BookRepo>().As<IBookRepo>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
      //      builder.RegisterType<DbInitializer>().As<IDbInitializer>();

        }
    }
}
