using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiClients
{
    public interface IBrandApiClient
    {
        Task<IList<BrandViewModel>> GetBrands();
    }
}
