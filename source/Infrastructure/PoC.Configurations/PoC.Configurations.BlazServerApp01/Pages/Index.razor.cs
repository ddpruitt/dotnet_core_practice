using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using PoC.Configurations.BlazServerApp01.Data;

namespace PoC.Configurations.BlazServerApp01.Pages
{
    public partial class Index
    {
        [Inject]
        private IConfiguration Configuration { get; set; }

        public string ConfigDebugViewText { get; set; }

        private SomeComplexSection SomeComplexSection { get; set; }

        protected override Task OnInitializedAsync()
        {
            ConfigDebugViewText = (Configuration as IConfigurationRoot)
                .GetDebugView();

            SomeComplexSection = Configuration
                .GetSection("SomeComplexSection")
                .Get<SomeComplexSection>();

            return base.OnInitializedAsync();
        }
    }
}