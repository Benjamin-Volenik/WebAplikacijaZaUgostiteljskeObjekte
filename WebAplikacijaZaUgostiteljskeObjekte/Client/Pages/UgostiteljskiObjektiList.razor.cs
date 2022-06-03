using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;
using MudBlazor;

namespace WebAplikacijaZaUgostiteljskeObjekte.Client.Pages
{
    public class UgostiteljskiObjektiListBase : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; }

        public List<UgostiteljskiObjektiModel> UgostiteljskiObjekti { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            UgostiteljskiObjekti = await Http.GetFromJsonAsync<List<UgostiteljskiObjektiModel>>("api/UgostiteljskiObjekti");
        }
    }
}
