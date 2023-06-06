using BitMaskTesting.DbModels;
using BitMaskTesting.Models;
using BitMaskTesting.Models.Enums;
using BitMaskTesting.Repositories.Interfaces;
using BitMaskTesting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<SelectGroup>> GetDocumentTypesForSelectedFormEnumAsync(int id)
        {
            var formType = (FormMask)id;

            var types = await _documentRepository.GetAllDocumentTypes()
                .Where(w => ((FormMask)w.FormMaskInt & formType) == formType)
                .OrderBy(o => o.Name)
                .ToListAsync();

            return await GetDocTypesByCategorySelectListAsync(types);
        }

        public async Task<List<SelectListItem>> GetFormTypesSelectListAsync()
        {
            return (await _documentRepository.GetAllDocumentFormMasksAsync())
                .OrderBy(o => o.FormName)
                .Select(s => new SelectListItem()
                {
                    Text = s.FormName,
                    Value = s.BitValue.ToString()
                }).ToList();
        }

        private async Task<List<SelectGroup>> GetDocTypesByCategorySelectListAsync(List<DocumentType> documentTypes)
        {
            var list = new List<SelectGroup>();
            var groups = await _documentRepository.GetAllDocumentCategoriesAsync();

            foreach (var group in groups)
            {
                if (!documentTypes.Any(d => d.DocumentCategory.Name.Equals(group.Name))) continue;

                list.Add(new SelectGroup()
                {
                    Name = group.Name,
                    Items = documentTypes.Where(w => w.DocumentCategory.Name.Equals(group.Name))
                        .Select(s => new SelectGroupItem()
                        {
                            Text = s.Name,
                            Value = s.DocumentTypeId.ToString()
                        }).ToList()
                });
            }

            return list;
        }
    }
}
