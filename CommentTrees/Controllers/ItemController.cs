using System.Linq;
using System.Threading.Tasks;
using CommentTrees.Abstract;
using CommentTrees.Helpers;
using CommentTrees.Models.Database;
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
        public async Task<IActionResult> Item(int id)
        {
            var item = (await _unitOfWork.ItemRepository.GetAsync(id)).FirstOrDefault();
            if (item == null) return NotFound();

            var comments = await _unitOfWork.CommentRepository.GetAsync(id);

            var itemViewModel = new ItemViewModel
                {Id = item.Id, Name = item.Name, Comments = comments.GenerateTree(itemId: item.Id)};

            return View(itemViewModel);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Comment(int? id, int itemId, string text)
        {
            var comment = new Comment
            {
                Text = text,
                CommentId = id
            };
            if (id == null)
                comment.ItemId = itemId;

            await _unitOfWork.CommentRepository.InsertAsync(comment);
            return RedirectToAction("Item", new {id = itemId});
        }

        [HttpGet("[action]/{itemId:int}/{id:int}")]
        public async Task<IActionResult> Delete(int id, int itemId)
        {
            await _unitOfWork.CommentRepository.DeleteAsync(id);
            return RedirectToAction("Item", new { id = itemId });
        }
    }
}