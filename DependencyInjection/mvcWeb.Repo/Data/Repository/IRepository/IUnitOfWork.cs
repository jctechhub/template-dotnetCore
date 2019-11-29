using System;
using System.Collections.Generic;
using System.Text;

namespace mvcWeb.Repo.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IFrequencyRepository Frequency { get; }
        IServiceRepository Service { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }

        //ISP_Call SP_Call { get; }

        //IUserRepository User { get; }
        void Save();
    }
}
