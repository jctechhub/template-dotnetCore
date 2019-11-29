using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using mvcWeb.Models;

namespace mvcWeb.Repo.Data.Repository.IRepository
{
    public interface IFrequencyRepository : IRepository<Frequency>
    {
        IEnumerable<SelectListItem> GetFrequencyListForDropDown();

        void Update(Frequency frequency);
    }
}
