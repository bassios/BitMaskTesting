﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitMaskTesting.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<List<SelectListItem>> GetDocumentTypesAsSelectListAsync();
    }
}
