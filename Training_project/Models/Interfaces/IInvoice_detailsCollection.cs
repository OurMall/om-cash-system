using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training_project.Models.Entities;

namespace Training_project.Models.Interfaces
{
    interface IInvoice_detailsCollection
    {
        Task InsertDetails(Invoice_details details);
        Task UpdateDetails(Invoice_details details);
        Task DeleteDetails(string id);
        Task<List<Invoice_details>> GetAllDetails();
        Task<Invoice_details> GetDetailsById(string id);
    }
}
