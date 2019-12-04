using System.Linq;
using System.Threading.Tasks;
using CommentTrees.Abstract;
using CommentTrees.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace CommentTrees.Controllers
{
    public class ItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.ItemRepository.GetAsync();
            return View(items.Select(e => new ItemViewModel {Id = e.Id, Name = e.Name}));
        }

        [HttpGet("{id:int}")]
        public IActionResult Item(int id)
        {

            return View();
        }
    }
}