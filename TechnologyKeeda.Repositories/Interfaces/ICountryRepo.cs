﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKeeda.Entity;

namespace TechnologyKeeda.Repositories.Interfaces
{
    public interface ICountryRepo
    {
        Task<IEnumerable<Country>>GetAll();
        Task<Country> GetById(int id);
        Task Save(Country country);
        Task Edit(Country country);
        Task RemoveData(Country country);
    }
}
