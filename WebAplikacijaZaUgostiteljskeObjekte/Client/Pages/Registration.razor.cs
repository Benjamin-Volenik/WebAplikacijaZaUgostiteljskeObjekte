using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Net.Http.Json;
using WebAplikacijaZaUgostiteljskeObjekte.Client.HttpRepository;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities.DTO;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;
using System.ComponentModel.DataAnnotations;

namespace WebAplikacijaZaUgostiteljskeObjekte.Client.Pages
{
    public partial class Registration
    {
        private UserForRegistrationDto _userForRegistration = new UserForRegistrationDto();
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public bool ShowRegistrationErrors { get; set; }
        public IEnumerable<string> Errors { get; set; }
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
            Snackbar.Add("Uspješno ste se registrirali!");
        }

        public async Task DodajNovogKorisnika()
        {
            await Http.PostAsJsonAsync<CreateUser>("api/User", NoviKorisnik);
            PokaziAlert();
            NavigationManager.NavigateTo("/");


        }

    }
}
