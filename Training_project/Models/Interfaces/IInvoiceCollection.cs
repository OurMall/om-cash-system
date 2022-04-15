using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training_project.Models.Entities;

namespace Training_project.Models.Interfaces
{
    interface IInvoiceCollection
    {
        Task InsertInvoice(Invoice invoice);
        Task UpdateInvoice(Invoice invoice);
        Task DeleteInvoice(string id);
        Task<List<Invoice>> GetAllInvoices();
        Task<Invoice> GetInvoiceById(string id);
    }
}
