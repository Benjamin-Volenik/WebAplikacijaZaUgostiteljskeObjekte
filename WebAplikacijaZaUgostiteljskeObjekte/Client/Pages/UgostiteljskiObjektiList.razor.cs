using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;
using MudBlazor;

namespace WebAplikacijaZaUgostiteljskeObjekte.Client.Pages
{
    public class UgostiteljskiObjektiListBase : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; }

        [Parameter] public List<UgostiteljskiObjektiModel> UgostiteljskiObjekti { get; set; } = new();

        [Parameter] public UgostiteljskiObjektiModel? SelectedUO { get; set; }



    }
}
