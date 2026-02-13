using AA.BulkSMS.Core.Data.ViewModels;
using AA.BulkSMS.Core.Services.ServiceInterfaces;
using AA.BulkSMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AA.BulkSMS.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }
        [HttpPost]
        [Route("SaveContact")]
        [SwaggerOperation(Summary = "Save Contact", Description = "Saves a contact using the provided contact information.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Contact saved successfully.")]
        public async Task<IActionResult> SaveContactAsync([FromBody] SaveContactVM saveContact)
        {
            await _ContactService.SaveContactAsync(saveContact);

            var response = new
            {
                ErrorMessage = (saveContact == null) ? "Invalid contact data." : null,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("ListContact")]
        [SwaggerOperation(Summary = "List Contacts", Description = "Returns a list of contacts for the provided organisation ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Contacts retrieved successfully.")]
        public async Task<IActionResult> ListContactAsync([FromBody] int organisationId)
        {
            var result = await _ContactService.ListContactAsync(organisationId);

            var response = new
            {
                ErrorMessage = (result == null || !result.Any()) ? "No contacts found." : null,
                data = result,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }


        [HttpPost]
        [Route("DeleteContact")]
        [SwaggerOperation(Summary = "Delete Contact", Description = "Deletes the specified contact.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Contact deleted successfully.")]
        public async Task<IActionResult> DeleteContactAsync([FromBody] DeleteContactVM deleteContact)
        {
            await _ContactService.DeleteContactAsync(deleteContact);

            var response = new
            {
                ErrorMessage = (deleteContact == null) ? "Invalid contact data." : null,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }
    }
}
