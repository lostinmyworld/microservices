using Api.Base.Web.Controllers;
using Api.Data.Access.DataTypes.Requests;
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

        #region Retrieve All
        [HttpGet("retrieve")]
        public IActionResult RetrieveAll()
        {
            var result = _service.GetAll();

            return RetrievePayload(result);
        }

        [HttpGet("retrieveAsync")]
        public async Task<IActionResult> RetrieveAllAsync()
        {
            var result = await _service.GetAllAsync().ConfigureAwait(false);

            return RetrievePayload(result);
        }
        #endregion

        #region Retrieve By Name
        [HttpGet("retrieveByName/name/{name}")]
        public IActionResult RetrieveByName([FromRoute]NameRequest request)
        {
            var result = _service.GetByName(request);

            return RetrievePayload(result);
        }

        [HttpGet("retrieveByNameAsync/name/{name}")]
        public async Task<IActionResult> RetrieveByNameAsync([FromRoute] NameRequest request)
        {
            var result = await _service.GetByNameAsync(request).ConfigureAwait(false);

            return RetrievePayload(result);
        }
        #endregion
    }
}
