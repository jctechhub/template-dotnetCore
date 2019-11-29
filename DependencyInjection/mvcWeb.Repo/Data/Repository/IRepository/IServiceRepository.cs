using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using mvcWeb.Models;

namespace mvcWeb.Repo.Data.Repository.IRepository
{
    public interface IServiceRepository : IRepository<Service>
    {

        void Update(Service service);
    }
}
