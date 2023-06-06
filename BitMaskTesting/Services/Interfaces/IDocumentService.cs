using BitMaskTesting.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitMaskTesting.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<List<SelectGroup>> GetDocumentTypesForSelectedFormEnumAsync(int id);
        Task<List<SelectGroup>> GetDocumentTypesForSelectedFormDBAsync(int id);

        Task<List<SelectListItem>> GetFormTypesSelectListAsync();
    }
}
