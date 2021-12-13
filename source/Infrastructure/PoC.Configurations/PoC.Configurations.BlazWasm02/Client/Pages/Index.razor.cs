using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using PoC.Configurations.BlazWasm02.Shared;

namespace PoC.Configurations.BlazWasm02.Client.Pages
{
    public partial class Index
    {
        [Inject]
        private IConfiguration Configuration { get; set; }

        [Inject]
        private HttpClient Http { get; set; }

        private SomeComplexSection Remote { get; set; }
        private SomeComplexSection Local { get; set; }

        public string LocalConfigDebugViewText { get; set; }
        public string RemoteConfigDebugViewText { get; set; }

        protected override async Task OnInitializedAsync()
        {
            LocalConfigDebugViewText = (Configuration as IConfigurationRoot)
                .GetDebugView();

            LocalConfigDebugViewText = string.IsNullOrWhiteSpace(LocalConfigDebugViewText)
                ? "{no configuration values loaded}"
                : LocalConfigDebugViewText;

            Local = Configuration
                .GetSection("SomeComplexSection")
                .Get<SomeComplexSection>();

            Remote = await Http
                .GetFromJsonAsync<SomeComplexSection>("api/SomeComplexConfiguration");

            RemoteConfigDebugViewText = await Http
                .GetStringAsync("api/SomeComplexConfiguration/GetConfigurationDump");
        }
    }
}