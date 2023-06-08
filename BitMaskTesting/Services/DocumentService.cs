using BitMaskTesting.DbModels;
using BitMaskTesting.Models;
using BitMaskTesting.Models.Enums;
using BitMaskTesting.Repositories.Interfaces;
using BitMaskTesting.Services.Interfaces;
using LinqKit;
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

        #region SelectGroup stuff

        public async Task<List<SelectGroup>> GetDocumentTypesForSelectedFormEnumAsync(int id)
        {
            var formType = (FormMask)id;

            var types = await _documentRepository.GetAllDocumentTypes()
                .Where(w => ((FormMask)w.FormMaskInt & formType) == formType)
                .OrderBy(o => o.Name)
                .ToListAsync();

            return await GetDocTypesByCategorySelectListAsync(types);
        }

        public async Task<List<SelectGroup>> GetDocumentTypesForSelectedFormDBAsync(int id)
        {
            var test = await _documentRepository.GetAllDocumentTypes()
                .Where(w => (id & w.FormMaskInt) == id)
                .OrderBy(o => o.Name)
                .ToListAsync();

            return await GetDocTypesByCategorySelectListAsync(test);
        }

        #endregion

        #region Select2ReturnObject stuff

        public async Task<Select2ReturnObject<Select2Group>> GetDocumentTypesSelect2ForSelectedFormEnumAsync(int id, string search)
        {
            var formType = (FormMask)id;

            var whereClause = DocTypeWhere(search);

            var types = await _documentRepository.GetAllDocumentTypes()
                .Where(w => ((FormMask)w.FormMaskInt & formType) == formType)
                .Where(whereClause)
                .OrderBy(o => o.Name)
                .ToListAsync();

            return await GetDocTypesByCategorySelect2Async(types);
        }

        public async Task<Select2ReturnObject<Select2Group>> GetDocumentTypesSelect2ForSelectedFormDBAsync(int id, string search)
        {
            var whereClause = DocTypeWhere(search);

            var test = await _documentRepository.GetAllDocumentTypes()
                .Where(w => (id & w.FormMaskInt) == id)
                .Where(whereClause)
                .OrderBy(o => o.Name)
                .ToListAsync();

            return await GetDocTypesByCategorySelect2Async(test);
        }

        private ExpressionStarter<DocumentType> DocTypeWhere(string search)
        {
            var predicate = PredicateBuilder.New<DocumentType>(true);

            if (!string.IsNullOrWhiteSpace(search))
            {
                predicate = predicate.Or(s => s.Name.Contains(search));
            }

            return predicate;
        }

        #endregion

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

        private async Task<Select2ReturnObject<Select2Group>> GetDocTypesByCategorySelect2Async(List<DocumentType> documentTypes)
        {
            var returnObj = new Select2ReturnObject<Select2Group>()
            {
                Results = new List<Select2Group>()
            };

            var groups = await _documentRepository.GetAllDocumentCategoriesAsync();

            foreach (var group in groups)
            {
                if (!documentTypes.Any(d => d.DocumentCategory.Name.Equals(group.Name))) continue;

                returnObj.Results.Add(new Select2Group()
                {
                    Text = group.Name,
                    Children = documentTypes.Where(w => w.DocumentCategory.Name.Equals(group.Name))
                    .Select(s => new Select2Item()
                    {
                        Id = s.DocumentTypeId.ToString(),
                        Text = s.Name
                    }).ToList()
                });
            }

            return returnObj;
        }
    }
}
