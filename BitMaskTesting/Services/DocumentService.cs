using BitMaskTesting.Repositories.Interfaces;
using BitMaskTesting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitMaskTesting.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService
            (IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<List<SelectListItem>> GetDocumentTypesAsSelectListAsync()
        {
            var types = await _documentRepository.GetAllDocumentTypesAsync();

            return types.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.DocumentTypeId.ToString()
            }).ToList();
        }

    }
}
