using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;


namespace BlazorWebAssemblyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetTime()
        {
            return DateTime.Now.ToShortTimeString();
        }
    }
   
}
