using Api.Base.Web.Controllers;
using Api.Data.Access.DataTypes.DTOs;
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

        #region Create
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeDTO entity)
        {
            var result = await _service.Add(entity).ConfigureAwait(false);

            return RetrievePayload(result);
        }
        #endregion

        #region Retrieve
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var result = await _service.GetAll().ConfigureAwait(false);

            return RetrievePayload(result);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> Read(string name)
        {
            var result = await _service.GetByName(name).ConfigureAwait(false);

            return RetrievePayload(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read(long id)
        {
            var result = await _service.GetById(id).ConfigureAwait(false);

            return RetrievePayload(result);
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] EmployeeDTO entity)
        {
            var result = await _service.Update(id, entity).ConfigureAwait(false);

            return RetrievePayload(result);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var result = await _service.Delete(id).ConfigureAwait(false);

            return RetrievePayload(result);
        }
        #endregion
    }
}
