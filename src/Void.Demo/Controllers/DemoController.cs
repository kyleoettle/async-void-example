using Microsoft.AspNetCore.Mvc;

namespace Void.Demo.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IDemoService demoService;
        private static readonly string[] demoValues = new[]
        {
            "A", "B", "C"
        };

        public DemoController(IDemoService demoService)
        {
            this.demoService = demoService;
        }

        [HttpGet(Name = "GetTaskAsync")]
        public async Task<IEnumerable<string>> GetTaskAsync()
        {
            await demoService.PerformTaskAsync();
            return demoValues;
        }

        [HttpGet(Name = "GetVoidAsync")]
        public async Task<IEnumerable<string>> GetVoidAsync()
        {
            demoService.PerformVoidAsync();
            return demoValues;
        }
    }
}

