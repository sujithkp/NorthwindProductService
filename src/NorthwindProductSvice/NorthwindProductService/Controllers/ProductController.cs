using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindProductService.Model;

namespace NorthwindProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public ProductsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = _context.Products
                .Include(x => x.Category)
                .ThenInclude(x => x.Products)
                .ToListAsync();

            var productInfos = _mapper.Map<ProductInfo[]>(await products);

            return Ok(productInfos);
        }

        [HttpGet]
        [Route("{productId}/Orders")]
        public IActionResult Orders( int productId)
        {
            //var products = _context.Products.Where(x=>x.)

            return Ok();
        }
    }
}
