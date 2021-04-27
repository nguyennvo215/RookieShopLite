using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.User
{
    public interface IUserApiService
    {
        public Task<IEnumerable<IdentityUser>> GetUsers();
    }
}
