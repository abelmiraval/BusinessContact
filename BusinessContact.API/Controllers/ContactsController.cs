using BusinessContact.Dto.Response;
using BusinessContact.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Dto.Request;

namespace BusinessContact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseResponseGeneric<ICollection<ContactResponse>>), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetListContact());
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseGeneric<int>), 201)]
        [ProducesResponseType(typeof(BaseResponseGeneric<int>), 400)]
        public async Task<IActionResult> Post(ContactRequest request)
        {
            var response = await _service.CreateAsync(request);

            return Created($"api/contacts/{response.Result}", response);
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(BaseResponse), 200)]
        [ProducesResponseType(typeof(BaseResponse), 400)]
        public async Task<IActionResult> Put(int id, ContactRequest request)
        {
            var response = await _service.UpdateAsync(id, request);

            if (response.Success)
                return Ok(response);

            return NotFound(response);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(BaseResponse), 200)]
        [ProducesResponseType(typeof(BaseResponse), 400)]
        public async Task<IActionResult> Delete(int id)
        {
            var response =await _service.DeleteAsync(id);

            if (response.Success)
                return Ok(response);

            return NotFound(response);
        }
    }
}