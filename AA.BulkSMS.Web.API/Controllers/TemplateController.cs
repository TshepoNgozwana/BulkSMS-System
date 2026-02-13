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
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _TemplateService;

        public TemplateController(ITemplateService TemplateService)
        {
            _TemplateService = TemplateService;
        }
        [HttpPost]
        [Route("SaveTemplate")]
        [SwaggerOperation(Summary = "Save Template", Description = "Saves a Template using the provided Template information.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Template saved successfully.")]
        public async Task<IActionResult> SaveTemplateAsync([FromBody] Template saveTemplate)
        {
            await _TemplateService.SaveTemplateAsync(saveTemplate);

            var response = new
            {
                ErrorMessage = (saveTemplate == null) ? "Invalid Template data." : null,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("ListTemplate")]
        [SwaggerOperation(Summary = "List Templates", Description = "Returns a list of Templates for the provided organisation ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Templates retrieved successfully.")]
        public async Task<IActionResult> ListTemplateAsync()
        {
            var result = await _TemplateService.ListTemplateAsync();

            var response = new
            {
                ErrorMessage = (result == null || !result.Any()) ? "No Templates found." : null,
                data = result,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }


        [HttpPost]
        [Route("DeleteTemplate")]
        [SwaggerOperation(Summary = "Delete Template", Description = "Deletes the specified Template.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Template deleted successfully.")]
        public async Task<IActionResult> DeleteTemplateAsync([FromBody] DeleteEntityVM deleteTemplate)
        {
            await _TemplateService.DeleteTemplateAsync(deleteTemplate);

            var response = new
            {
                ErrorMessage = (deleteTemplate == null) ? "Invalid contact data." : null,
                status = StatusCodes.Status200OK
            };

            return Ok(response);
        }
    }
}
