using Microsoft.AspNetCore.Mvc;
using CLDV_POE_PART2_V1.Models;
using CLDV_POE_PART2_V1.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CLDV_POE_PART2_V1.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Order/History
        public IActionResult History()
        {
            // Retrieve the order history from the database
            var orderHistory = _context.Orders.Include(o => o.Product).ToList();
            return View(orderHistory);
        }

        // POST: /Order/AddToOrder
        [HttpPost]
        [Authorize]
        public IActionResult AddToOrder(int productId)
        {
            var userId = User.Identity.Name; // Assuming user name is the customer name

            var order = new Order
            {
                CustomerName = userId,
                OrderDate = DateTime.Now,
                ProductId = productId,
                Quantity = 1
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            // Redirect to the order history page
            return RedirectToAction(nameof(History));
        }

        // POST: /Order/Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(History));
        }
    }
}
