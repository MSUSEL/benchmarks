using Microsoft.AspNetCore.Mvc;

namespace Jellyfin.Api
{
    /// <summary>
    /// Base api controller for the API setting a default route.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BaseJellyfinApiController : ControllerBase
    {
    }
}
