using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
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

        public IList<IBrowserFile> files = new List<IBrowserFile>();

        public IFormFile coverphoto { get; set; }

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
            NoviUO.UgostiteljskiObjektiSlika = files.FirstOrDefault().Name;
            await Http.PostAsJsonAsync<CreateUO>("api/UgostiteljskiObjekti", NoviUO);
            PokaziAlert();
            NavigationManager.NavigateTo("/");


        }

        private void UploadFiles(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles())
            {
                files.Add(file);
            }
            //TODO upload the files to the server
        }

    }
}
