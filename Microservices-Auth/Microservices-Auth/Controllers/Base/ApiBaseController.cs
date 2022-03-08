
using Microservices.Dtos.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Microservices_Auth.Controllers.Base
{
    [ApiController]
    [ApiVersion("1")]
    public abstract class ApiBaseController : ControllerBase
    {
        protected ObjectResult HandleReturn(BaseDto obj) 
        {

            return new ObjectResult(obj)
            {
                StatusCode = obj.IsValid()
                            ? (int)HttpStatusCode.OK
                            : (int)HttpStatusCode.InternalServerError,
                Value = !obj.IsValid() ? obj.Erros : obj
            };
        }
        protected ObjectResult HandleReturn(IEnumerable<BaseDto> obj)
        {
            return new ObjectResult(obj) 
            {
                StatusCode = obj.Any(x => !x.IsValid())
                             ? (int)HttpStatusCode.OK
                             : (int)HttpStatusCode.InternalServerError,
                Value = obj.Any(x => !x.IsValid())? obj.Select(x=>x.Erros) : obj
            };
        }
    }
}
