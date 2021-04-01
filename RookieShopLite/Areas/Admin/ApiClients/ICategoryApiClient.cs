using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiClients
{
    interface ICategoryApiClient
    {
        Task<IList<CategoryViewModel>> GetCategories();
    }
}
