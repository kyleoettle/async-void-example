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
            // fire and forget
            // no await so exception will be caught in TaskScheduler.UnobservedTaskException
            // demoValues will be returned
            demoService.PerformTaskAsync();
            return demoValues;
        }

        [HttpGet(Name = "GetTaskAsync")]
        public async Task<IEnumerable<string>> GetAsyncTask()
        {
            // awaits demoService.PerformTaskAsync
            // exception will be thrown and handled in ExceptionMiddleware
            // demoValues will not be returned
            await demoService.PerformTaskAsync();
            return demoValues;
        }

        [HttpGet(Name = "GetVoidAsync")]
        public async Task<IEnumerable<string>> GetAsyncVoid()
        {
            // fire and forget
            // no await so exception will be logged in AppDomain.CurrentDomain.UnhandledException and crash
            // demoValues will be returned
            demoService.PerformVoidAsync();
            return demoValues;
        }
    }
}

