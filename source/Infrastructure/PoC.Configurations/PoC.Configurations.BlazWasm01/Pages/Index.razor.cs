using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using PoC.Configurations.BlazWasm01.Model;

namespace PoC.Configurations.BlazWasm01.Pages
{
    public partial class Index
    {
        [Inject]
        private IConfiguration Configuration { get; set; }


        private SomeComplexSection SomeComplexSection { get; set; }
        public string ConfigDebugViewText { get; set; }

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
