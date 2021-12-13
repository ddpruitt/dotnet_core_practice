using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PoC.Configurations.BlazWasm02.Shared;

namespace PoC.Configurations.BlazWasm02.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeComplexConfigurationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SomeComplexConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public SomeComplexSection Get()
        {
            return _configuration
                .GetSection("SomeComplexSection")
                .Get<SomeComplexSection>();
        }

        [HttpGet]
        [Route("GetConfigurationDump")]
        public string GetConfigurationDump()
        {
            var configDump = (_configuration as IConfigurationRoot)
                .GetDebugView();

            configDump = string.IsNullOrWhiteSpace(configDump)
                ? "{no configuration values loaded}"
                : configDump;

            return configDump;
        }
    }
}
