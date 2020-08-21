using Microsoft.AspNetCore.Authorization;

namespace Api.Base.Web.Controllers
{
    [Authorize]
    public class ApiBaseController : PayloadBaseController
    {
    }
}
