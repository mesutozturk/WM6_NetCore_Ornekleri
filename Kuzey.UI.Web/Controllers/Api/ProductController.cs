using Kuzey.BLL.Repository.Abstracts;
using Kuzey.Models.Entities;
using Kuzey.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Kuzey.UI.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product, string> _productRepo;
        private readonly IRepository<Category, int> _categoryRepo;

        public ProductController(IRepository<Product, string> productRepo, IRepository<Category, int> categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }
        [HttpGet]
        [Route("products")]
        public IActionResult Get()
        {
            var data = _productRepo.GetAll().Include(x => x.Category)
                .Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    CategoryName = x.Category.CategoryName,
                    CategoryId = x.CategoryId,
                    CreatedDate = x.CreatedDate,
                    CreatedUserId = x.CreatedUserId,
                    UnitPrice = x.UnitPrice,
                    ProductName = x.ProductName,
                    UpdatedDate = x.UpdatedDate,
                    UpdatedUserId = x.UpdatedUserId
                })
                .ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("find/{id}")]
        public IActionResult GetById(string id)
        {
            var data = _productRepo.GetById(id);
            if (data == null)
                return NotFound();

            var model = new ProductViewModel()
            {
                Id = data.Id,
                CategoryName = _categoryRepo.GetById(data.CategoryId).CategoryName,
                CategoryId = data.CategoryId,
                CreatedDate = data.CreatedDate,
                CreatedUserId = data.CreatedUserId,
                UnitPrice = data.UnitPrice,
                ProductName = data.ProductName,
                UpdatedDate = data.UpdatedDate,
                UpdatedUserId = data.UpdatedUserId
            };
            return Ok(model);
        }
        [HttpPost]
        [Route("add")]
        [Authorize]
        public IActionResult Add(Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var data = new Product()
            {
                CategoryId = model.CategoryId,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice
            };
            _productRepo.Insert(data);
            return Ok(new
            {
                success = true,
                message = "Ürün ekleme işlemi başarılı",
                data = data
            });
        }
    }
}