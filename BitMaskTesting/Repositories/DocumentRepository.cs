using BitMaskTesting.Data;
using BitMaskTesting.DbModels;
using BitMaskTesting.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
                .ToListAsync();
        }
    }
}
