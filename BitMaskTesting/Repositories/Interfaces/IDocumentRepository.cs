using BitMaskTesting.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitMaskTesting.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Task<List<DocumentType>> GetAllDocumentTypesAsync();

        Task<List<DocumentCategory>> GetAllDocumentCategoriesAsync();

        Task<List<DocumentFormMask>> GetAllDocumentFormMasksAsync();

        IQueryable<DocumentType> GetAllDocumentTypes();
    }
}
