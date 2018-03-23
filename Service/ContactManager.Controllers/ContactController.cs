using ContactManager.Business;
using ContactManager.Controllers.Core.ActionFilters;
using ContactManager.Controllers.Core.Results;
using ContactManager.Domain;
using ContactManager.Dto;
using ContactManager.Mappers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    /// <summary>
    /// Controller to manipulate the Contact data
    /// </summary>
    public class ContactController : BaseController
    {
        #region Private Members
        private IContactManager _contactManager { get; set; }
        #endregion Private Members

        #region Constructor
        public ContactController(IConfigurationRoot configuration, IContactManager contactManager)
        {
            _contactManager = contactManager;
        }
        #endregion Constructor

        #region Public Action Methods
        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ContactListResponse))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(InternalServerErrorObjectResult))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [SwaggerOperation("Get: Contacts")]
        [Route("contacts/")]
        [ValidatModelState]
        public async Task<IActionResult> Get()
        {
            return Ok(await _contactManager.GetContactsAsync());
        }

        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ContactDto))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(InternalServerErrorObjectResult))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(BadRequestObjectResult))]
        [SwaggerOperation("Get: Contact by Id")]
        [Route("contacts/{contactId}")]
        [ValidatModelState]
        public async Task<IActionResult> Get(int contactId)
        {
            return Ok(await _contactManager.GetContactAsync(contactId));
        }

        [HttpPost]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(OkResult))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(InternalServerErrorObjectResult))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [SwaggerOperation("Get: Contact by Id")]
        [Route("contacts/create")]
        [ValidatModelState]
        public async Task<IActionResult> Create([FromBody]PostContactRequest postContactRequest)
        {
            ContactDomain contactDomain = DtoToDomainMapper.MapDtoToDomain(postContactRequest);

            return Ok(await _contactManager.AddContactAsync(contactDomain));
        }

        [HttpPut]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(OkResult))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(InternalServerErrorObjectResult))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [SwaggerOperation("Get: Contact by Id")]
        [Route("contacts/update/{contactId}")]
        [ValidatModelState]
        public async Task<IActionResult> Update(int contactId, [FromBody]PutContactRequest putContactRequest)
        {
            ContactDomain contactDomain = DtoToDomainMapper.MapDtoToDomain(putContactRequest, contactId);

            return Ok(await _contactManager.UpdateContactAsync(contactDomain));
        }

        [HttpDelete]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(OkResult))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(InternalServerErrorObjectResult))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [SwaggerOperation("Get: Contact by Id")]
        [Route("contacts/delete/{contactId}")]
        [ValidatModelState]
        public async Task<IActionResult> Delete(int contactId)
        {
            return Ok(await _contactManager.DeleteContactAsync(contactId));
        }
        #endregion Public Action Method
    }
}
