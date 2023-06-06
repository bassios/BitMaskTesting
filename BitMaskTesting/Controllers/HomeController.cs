using BitMaskTesting.Models;
using BitMaskTesting.Services.Interfaces;
using BitMaskTesting.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BitMaskTesting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDocumentService _documentService;

        public HomeController
            (ILogger<HomeController> logger,
            IDocumentService documentService)
        {
            _logger = logger;
            _documentService = documentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EnumTest()
        {
            return View();
        }

        public async Task<IActionResult> DBTestAsync()
        {
            var vm = new TestingViewModel()
            {
                FormTypes = await _documentService.GetFormTypesSelectListAsync()
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetDocTypesEnumAsync(int id)
        {
            if (id <= 0) return BadRequest();

            return Json(await _documentService.GetDocumentTypesForSelectedFormEnumAsync(id));
        }

        public async Task<IActionResult> GetDocTypesDBAsync(int id)
        {
            if (id <= 0) return BadRequest();

            return Json(await _documentService.GetDocumentTypesForSelectedFormDBAsync(id));
        }
    }
}
