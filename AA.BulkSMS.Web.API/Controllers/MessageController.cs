using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Core.Services.ServiceInterfaces;
using AA.BulkSMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AA.BulkSMS.Web.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {

        private readonly IMessageService _MessageService;

        [HttpPost]
        [Route("SaveMessage")]
        [SwaggerOperation(Summary = "Save Message", Description = "Saves a Message using the provided Message information.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Message saved successfully.")]
        public async Task<IActionResult> SaveMessageAsync([FromBody] SaveMessageVM saveMessage)
        {
            await _MessageService.SaveMessageAsync(saveMessage);

            var response = new
            {
                ErrorMessage = (saveMessage == null) ? "Invalid Message data." : null,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("ListMessage")]
        [SwaggerOperation(Summary = "List Messages", Description = "Returns a list of Messages for the provided organisation ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Messages retrieved successfully.")]
        public async Task<IActionResult> ListMessageAsync(int? messageTypeId)
        {
            var result = await _MessageService.ListMessageAsync(messageTypeId);

            var response = new
            {
                ErrorMessage = (result == null || !result.Any()) ? "No Messages found." : null,
                data = result,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }
        
        [HttpPost]
        [Route("GetMessage")]
        [SwaggerOperation(Summary = "Get Messages", Description = "Returns a Get of Messages for the provided organisation ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Messages retrieved successfully.")]
        public async Task<IActionResult> GetMessageAsync(int MessageId)
        {
            var result = await _MessageService.GetMessageAsync(MessageId);

            var response = new
            {
                ErrorMessage =  "No Messages found." ,
                data = result,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }


        [HttpPost]
        [Route("DeleteMessage")]
        [SwaggerOperation(Summary = "Delete Message", Description = "Deletes the specified Message.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Message deleted successfully.")]
        public async Task<IActionResult> DeleteMessageAsync([FromBody] DeleteEntityVM deleteMessage)
        {
            await _MessageService.DeleteMessageAsync(deleteMessage);

            var response = new
            {
                ErrorMessage = (deleteMessage == null) ? "Invalid contact data." : null,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }
    }
}
