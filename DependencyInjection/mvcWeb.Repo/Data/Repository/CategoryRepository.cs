using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcWeb.Repo.Data.Repository.IRepository;
using mvcWeb.Models;

namespace mvcWeb.Repo.Data.Repository
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            //return _db.Category.Select(i => new SelectListItem()
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});

            //returns some dummy value
            return new List<SelectListItem>()
            {
                new SelectListItem("hello", "111"),
                new SelectListItem("hello2", "222"),

            };
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(s => s.Id == category.Id);

            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;

            _db.SaveChanges();

        }
    }
}
