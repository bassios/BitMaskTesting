using BitMaskTesting.Data;
using BitMaskTesting.DbModels;
using BitMaskTesting.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitMaskTesting.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly BitMaskDbContext _dbContext;

        public DocumentRepository(BitMaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DocumentType>> GetAllDocumentTypesAsync()
        {
            return await _dbContext.DocumentTypes
                .Include(i => i.DocumentCategory)
                .ToListAsync();
        }


        public async Task<List<DocumentCategory>> GetAllDocumentCategoriesAsync()
        {
            return await _dbContext.DocumentCategories
                .ToListAsync();
        }

        public async Task<List<DocumentFormMask>> GetAllDocumentFormMasksAsync()
        {
            return await _dbContext.DocumentFormMasks
                .ToListAsync();
        }

        public IQueryable<DocumentType> GetAllDocumentTypes()
        {
            return _dbContext.DocumentTypes
                .Include(i => i.DocumentCategory);
        }
    }
}
