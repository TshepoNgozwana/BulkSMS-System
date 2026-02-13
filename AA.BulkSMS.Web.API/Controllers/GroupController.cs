using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Core.Data.ViewModels;
using AA.BulkSMS.Core.Services.ServiceInterfaces;
using AA.BulkSMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AA.BulkSMS.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpPost]
        [Route("SaveGroup")]
        [SwaggerOperation(Summary = "Save Group", Description = "Saves a Group using the provided Group information.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Group saved successfully.")]
        public async Task<IActionResult> SaveGroupAsync([FromBody] Group saveGroup)
        {
            await _groupService.SaveGroupAsync(saveGroup);

            var response = new
            {
                ErrorMessage = (saveGroup == null) ? "Invalid Group data." : null,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }
        [HttpPost]
        [Route("SaveGroupContact")]
        [SwaggerOperation(Summary = "Save Group Contact", Description = "Saves a Group using the provided Group information.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Group saved successfully.")]
        public async Task<IActionResult> SaveGroupContact([FromBody] GroupContact saveGroup)
        {
            await _groupService.SaveGroupContact(saveGroup);

            var response = new
            {
                ErrorMessage = (saveGroup == null) ? "Invalid Group data." : null,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("ListGroup")]
        [SwaggerOperation(Summary = "List Groups", Description = "Returns a list of Groups for the provided group ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Groups retrieved successfully.")]
        public async Task<IActionResult> ListGroupAsync()
        {
            var result = await _groupService.ListGroupAsync();

            var response = new
            {
                ErrorMessage = (result == null || !result.Any()) ? "No Groups found." : null,
                data = result,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("ListGroupContact")]
        [SwaggerOperation(Summary = "List Groups Contact", Description = "Returns a list of Groups for the provided group ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Groups retrieved successfully.")]
        public async Task<IActionResult> ListGroupContact([FromBody] int organisationId)
        {
            var result = await _groupService.ListGroupContact(organisationId);

            var response = new
            {
                ErrorMessage = (result == null || !result.Any()) ? "No Groups found." : null,
                data = result,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }


        [HttpPost]
        [Route("DeleteGroup")]
        [SwaggerOperation(Summary = "Delete Group", Description = "Deletes the specified Group.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Group deleted successfully.")]
        public async Task<IActionResult> DeleteGroupAsync([FromBody] DeleteEntityVM deleteGroup)
        {
            await _groupService.DeleteGroupAsync(deleteGroup);

            var response = new
            {
                ErrorMessage = (deleteGroup == null) ? "Invalid Group data." : null,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("DeleteGroupContact")]
        [SwaggerOperation(Summary = "Delete Group Contact", Description = "Deletes the specified Group Contact.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Group Contact deleted successfully.")]
        public async Task<IActionResult> DeleteGroupContact([FromBody] DeleteEntityVM deleteGroup)
        {
            await _groupService.DeleteGroupContact(deleteGroup);

            var response = new
            {
                ErrorMessage = (deleteGroup == null) ? "Invalid Group data." : null,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }
    }
}
