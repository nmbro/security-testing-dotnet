using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace netcoreapp.Controllers
{
    [Route("api/Command")]
    public class CommandController : Controller
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Command([FromBody]string command)
        {
            command ??= "127.0.0.1";

            var p = new Process
            {
                StartInfo =
                {
                    FileName = "ping.exe", 
                    Arguments = "-n 3 " + command,
                    RedirectStandardOutput = true
                }
            };
            p.Start();

            var reader = await p.StandardOutput.ReadToEndAsync();

            return new ObjectResult(reader);
        }
    }
}