using BitMaskTesting.Models;
using BitMaskTesting.Models.Enums;
using BitMaskTesting.Services.Interfaces;
using BitMaskTesting.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BitMaskTesting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHtmlHelper _htmlHelper;
        private readonly IDocumentService _documentService;

        public HomeController
            (ILogger<HomeController> logger,
            IHtmlHelper htmlHelper,
            IDocumentService documentService)
        {
            _logger = logger;
            _htmlHelper = htmlHelper;
            _documentService = documentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EnumTest()
        {
            var vm = new TestingViewModel(_htmlHelper.GetEnumSelectList<FormType>().ToList());
            return View(vm);
        }

        public async Task<IActionResult> DBTestAsync()
        {
            var vm = new TestingViewModel(await _documentService.GetFormTypesSelectListAsync());
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


        public async Task<IActionResult> GetDocTypesSelect2EnumAsync(int id, string search)
        {
            var test = await _documentService.GetDocumentTypesSelect2ForSelectedFormEnumAsync(id, search);

            return Json(test);
        }

        public async Task<IActionResult> GetDocTypesSelect2DBAsync(int id, string search)
        {
            return Json(await _documentService.GetDocumentTypesSelect2ForSelectedFormDBAsync(id, search));
        }
    }
}
