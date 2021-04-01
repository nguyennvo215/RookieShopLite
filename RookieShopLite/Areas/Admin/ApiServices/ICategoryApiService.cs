using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiClients
{
    interface ICategoryApiService
    {
        Task<IList<CategoryViewModel>> GetCategories();
    }
}
