using Microsoft.AspNetCore.Mvc;

namespace EM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly string IpAddress = "127.0.0.1";
        // Status code
        // 100 - 199 Information
        // 200 - 299 Success
        // 300 - 399 Redirection
        // 400 - 499 Client side
        // 500 - 599 Server side

        // http request 8 types
        // get, put, post, delete, fetchs
    }
}
