using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;

namespace netframework.Controllers
{
    public class CommandController : ApiController
    {
        [HttpPost]
        public async Task<string> Command([FromBody]string command)
        {
            if (command == null)
            {
                command = "127.0.0.1";
            }

            var p = new Process
            {
                StartInfo =
                {
                    FileName = "ping.exe", 
                    Arguments = "-n 3 " + command,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };
            p.Start();

            var reader = await p.StandardOutput.ReadToEndAsync();

            return reader;
        }
    }
}