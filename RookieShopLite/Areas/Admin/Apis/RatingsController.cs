using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.Data;
using RookieShopLite.Model;
using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<UserRatingViewModel>>> GetRatings(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null || product.isDeleted == true)
            {
                return NotFound();
            }

            return await _context.UserRatings
                .Include("User")
                .Where(x => x.ProductId == product.Id && x.isRated == true)
                .Select(x => new UserRatingViewModel { 
                    UserId = x.UserId,
                    UserName = x.User.UserName,
                    Rating = x.RatingNumber
                })
                .ToListAsync();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserRatingViewModel>> PostRating(RatingCreateRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var rating = new UserRating
            {
                ProductId = request.ProductId,
                UserId = userId,
                RatingNumber = request.RatingNumber,
                isRated = true
            };

            _context.UserRatings.Add(rating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRatings", new { id = rating.Id }, new UserRatingViewModel {
                UserId = rating.UserId,
                UserName = rating.User.UserName,
                Rating = rating.RatingNumber
            });
        }
    }
}
