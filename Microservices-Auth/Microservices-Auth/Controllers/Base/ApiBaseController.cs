
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
    }
}
