using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training_project.Models.Entities;

namespace Training_project.Models.Interfaces
{
    interface IWorkSpaceCollection
    {
        Task InsertWorkSpace(WorkSpace workSpace);
        Task UpdateWorkSpace(WorkSpace workSpace);
        Task DeleteWorkSpace(string id);
        Task<List<WorkSpace>> GetAllWorkSpaces();
        Task<List<WorkSpace>> GetWorkSpaceById(string id);
    }
}
