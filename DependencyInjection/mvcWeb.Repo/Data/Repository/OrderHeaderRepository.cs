using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcWeb.Repo.Data.Repository.IRepository;
using mvcWeb.Models;

namespace mvcWeb.Repo.Data.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader> , IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

       public void ChangeOrderStatus(int orderHeaderId, string status)
        {
            var orderFromDb = _db.OrderHeader.FirstOrDefault(o => o.Id == orderHeaderId);
            orderFromDb.Status = status;
            _db.SaveChanges();
        }

    }
}
