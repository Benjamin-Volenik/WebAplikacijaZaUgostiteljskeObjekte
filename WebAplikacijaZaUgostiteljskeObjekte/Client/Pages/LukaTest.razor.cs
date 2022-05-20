using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Client.Pages
{
    public class LukaTestBase : ComponentBase
    {
        
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public HttpClient Http { get; set; }

        public List<UserModel> Users { get; set; } = new();
        public CreateUser NoviKorisnik { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Users = await Http.GetFromJsonAsync<List<UserModel>>("api/User");
        }

        public void PokaziAlert()
        {
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            Snackbar.Add("Luka je sef");
        }

        public async Task DodajNovogKorisnika()
        {
            await Http.PostAsJsonAsync<CreateUser>("api/User", NoviKorisnik);
        }
    }
}
