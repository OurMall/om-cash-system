using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training_project.Models.Entities;

namespace Training_project.Models.Interfaces
{
    interface IClosingCollection
    {
        Task InsertClosing(Closing closing);
        Task<List<Closing>> GetAllClosing();
        Task<List<Closing>> GetClosingByDate(DateTime date);
    }
}
