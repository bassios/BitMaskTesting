using BitMaskTesting.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitMaskTesting.Services.Interfaces
{
    public interface IDocumentService
    {
        #region SelectGroup stuff

        Task<List<SelectGroup>> GetDocumentTypesForSelectedFormEnumAsync(int id);
        Task<List<SelectGroup>> GetDocumentTypesForSelectedFormDBAsync(int id);

        #endregion

        Task<List<SelectListItem>> GetFormTypesSelectListAsync();

        #region Select2ReturnObject stuff

        Task<Select2ReturnObject<Select2Group>> GetDocumentTypesSelect2ForSelectedFormEnumAsync(int id, string search);
        Task<Select2ReturnObject<Select2Group>> GetDocumentTypesSelect2ForSelectedFormDBAsync(int id, string search);

        #endregion
    }
}
