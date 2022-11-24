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

        public IActionResult Index()
        {
           var order = _context.Orders.FirstOrDefault();

            return Ok(order);
        }

        [Route("{id}")]
        public IActionResult Index(int id)
        {
            var order = _context.Orders
                .Include(o => o.Details)
                .FirstOrDefault(o => o.OrderID == id);                

            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> OrderWithmaxItems()
        {
            var order = _context.Orders
                .Select(x => new { OrderId = x.OrderID, Count = x.Details.Count }) 
                .OrderByDescending(x => x.Count)
                .ToListAsync();

            return Ok(await order);
        }

    }
}
