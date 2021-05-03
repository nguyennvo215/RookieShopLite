using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.Rating
{
    public interface IRatingApiService
    {
        public Task<IList<UserRatingViewModel>> GetRatings(int id);
        public Task<UserRatingViewModel> PostRating(RatingCreateRequest request);
    }
}
