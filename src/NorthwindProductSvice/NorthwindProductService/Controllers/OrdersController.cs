using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NorthwindProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var order = _context.Orders.FirstOrDefault();

            return Ok(order);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Index(int id)
        {
            var order = _context.Orders
                .Include(o => o.Details)
                .FirstOrDefault(o => o.OrderID == id);

            return Ok(order);
        }

        [HttpGet]
        [Route("OrderWithmaxItems")]
        public async Task<IActionResult> OrderWithmaxItems()
        {
            var order = _context.Orders
                .Select(x => new { OrderId = x.OrderID, Count = x.Details.Count })
                .OrderByDescending(x => x.Count)
                .Take(3)
                .ToListAsync();

            return Ok(await order);
        }

        [HttpGet]
        [Route("MostOrderedProducts")]
        public async Task<IActionResult> MostOrderedProducts()
        {
            var order = _context.OrderDetails.GroupBy(x => x.ProductID)
                .OrderByDescending(x => x.Count())
                .Select(x => new { ProductId = x.Key, count = x.Count() })
                .Join(_context.Products,
                x => x.ProductId,
                x => x.ProductID,
                (x, y) => new
                {
                    ProductId = x.ProductId,
                    Name = y.ProductName,
                    Count = x.count
                })
                .ToListAsync();

            return Ok(await order);
        }

    }
}
