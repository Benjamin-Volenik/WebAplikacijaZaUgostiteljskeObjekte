using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Client.Pages
{
    public partial class RegistrationUgostiteljskiObjekti
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public HttpClient Http { get; set; }

        public List<UgostiteljskiObjektiModel> ugostiteljskiObjekti { get; set; } = new();
        public CreateUO NoviUO { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            ugostiteljskiObjekti = await Http.GetFromJsonAsync<List<UgostiteljskiObjektiModel>>("api/UgostiteljskiObjekti");
        }

        public void PokaziAlert()
        {
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            Snackbar.Add("Uspješno ste registrirali ugostiteljski objekt!");
        }

        public async Task DodajNoviUO()
        {
            NoviUO.UgostiteljskiObjektiProsjecnaOcjena = 0;
            NoviUO.UgostiteljskiObjektiSlika = "https://via.placeholder.com/350x300";
            NoviUO.UgostiteljskiObjektiStanje = "Neodobreno";
            await Http.PostAsJsonAsync<CreateUO>("api/UgostiteljskiObjekti", NoviUO);
            PokaziAlert();
            NavigationManager.NavigateTo("/");


        }
    }
}
