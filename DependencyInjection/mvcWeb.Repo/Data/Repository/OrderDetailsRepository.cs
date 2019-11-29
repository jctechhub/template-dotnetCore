using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcWeb.Repo.Data.Repository.IRepository;
using mvcWeb.Models;

namespace mvcWeb.Repo.Data.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails> , IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        
    }
}
