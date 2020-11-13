using DOHackerNews.Core.Communication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DOHackerNews.WebAPI.Core.Controllers
{
    [Route("api")]
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperationsIsValid())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }));
        }



        protected ActionResult CustomResponse(ResponseResult response)
        {
            ResponsePossuiErros(response);

            return CustomResponse();
        }

        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response == null || !response.Errors.Messages.Any()) return false;

            foreach (var messages in response.Errors.Messages)
            {
                IncludeProcessErros(messages);
            }

            return true;
        }

        protected bool OperationsIsValid()
        {
            return !Errors.Any();
        }

        protected void IncludeProcessErros(string error)
        {
            Errors.Add(error);
        }

        protected void CleanProcessErrors()
        {
            Errors.Clear();
        }
    }
}
