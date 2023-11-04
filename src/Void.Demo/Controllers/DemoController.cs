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

        [HttpGet(Name = "GetTask")]
        public async Task<IEnumerable<string>> GetTask()
        {
            demoService.PerformTaskAsync();
            return demoValues;
        }

        [HttpGet(Name = "GetTaskAsync")]
        public async Task<IEnumerable<string>> GetAsyncTask()
        {
            await demoService.PerformTaskAsync();
            return demoValues;
        }

        [HttpGet(Name = "GetVoidAsync")]
        public async Task<IEnumerable<string>> GetAsyncVoid()
        {
            demoService.PerformVoidAsync();
            return demoValues;
        }
    }
}

