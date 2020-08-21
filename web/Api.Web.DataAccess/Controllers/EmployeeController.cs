using Api.Base.Web.Controllers;
using Api.Data.Access.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Web.DataAccess.Controllers
{
    [AllowAnonymous]
    public class EmployeeController : ApiBaseController
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> RetrieveAllAsync()
        {
            var result = await _service.GetAllAsync().ConfigureAwait(false);

            return RetrievePayload(result);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> RetrieveByNameAsync(string name)
        {
            var result = await _service.GetByNameAsync(name).ConfigureAwait(false);

            return RetrievePayload(result);
        }
    }
}
