using BitMaskTesting.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitMaskTesting.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Task<List<DocumentType>> GetAllDocumentTypesAsync();
    }
}
