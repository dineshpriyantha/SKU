using Microsoft.AspNetCore.Mvc;
using SKU.Model;
using SKU.Services;

namespace SKU.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IShelfManager _shelfManager;

        public ShelfController(IConfiguration configuration, IShelfManager shelfManager)
        {
            _configuration = configuration;
            _shelfManager = shelfManager;
        }
        public IActionResult Index()
        {
            ShelfManager shelf = new ShelfManager(_configuration);
            var shelfList = shelf.GetShelfCabinets().Result;

            return View(shelfList);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
