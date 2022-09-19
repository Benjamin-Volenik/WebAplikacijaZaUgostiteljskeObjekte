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

        // slike ugostiteljskog objekta
        public IList<IBrowserFile> files = new List<IBrowserFile>();

        public IList<IBrowserFile> filesPDF = new List<IBrowserFile>();

        public IFormFile coverphoto { get; set; }

        public int provjera = 0;

        protected override async Task OnInitializedAsync()
        {
            ugostiteljskiObjekti = await Http.GetFromJsonAsync<List<UgostiteljskiObjektiModel>>("api/UgostiteljskiObjekti");
        }

        public void PokaziAlert()
        {
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            Snackbar.Add("Vaša registracija je zaprimljena!");
        }

        public async Task DodajNoviUO()
        {
            provjera = 0;
            NoviUO.UgostiteljskiObjektiProsjecnaOcjena = 0;
            NoviUO.UgostiteljskiObjektiStanje = "Neodobreno";
            NoviUO.UgostiteljskiObjektiSlika = "slike/" + files.FirstOrDefault().Name;
            NoviUO.UgostiteljskiObjektiPdfPutanja = "pdf/" + filesPDF.FirstOrDefault().Name;
            foreach(var ugostiteljskiobjekti in ugostiteljskiObjekti)
            {
                if(NoviUO.UgostiteljskiObjektiOIB == ugostiteljskiobjekti.UgostiteljskiObjektiOIB)
                {
                    provjera = 1;
                }
            }
            if(provjera == 0)
            {
                await Http.PostAsJsonAsync<CreateUO>("api/UgostiteljskiObjekti", NoviUO);
                PokaziAlert();
                NavigationManager.NavigateTo("/");
            }
            else
            {
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                Snackbar.Add("Već postoji ugostiteljski objekt s tim OIB-om!");
            }


        }

        private void UploadFiles(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles())
            {
                files.Add(file);
            }
            //TODO upload the files to the server
        }
        private void UploadFilesPDF(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles())
            {
                filesPDF.Add(file);
            }
            //TODO upload the files to the server
        }

    }
}
