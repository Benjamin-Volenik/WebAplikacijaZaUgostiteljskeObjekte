using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;
using MudBlazor;
using Blazored.LocalStorage;

namespace WebAplikacijaZaUgostiteljskeObjekte.Client.Pages
{
    public class UgostiteljskiObjektiDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject] public HttpClient Http { get; set; }
        [Inject] IDialogService DialogService { get; set; }
        [Inject] ISyncLocalStorageService localStorage { get; set; }

        public List<UgostiteljskiObjektiModel> UgostiteljskiObjekti { get; set; } = new();

        public UgostiteljskiObjektiModel ugostiteljskiObjekt { get; set; } = new();

        public List<DishModel> Dishes { get; set; } = new();

        public List<DishModel> values = new();

        public List<CommentModel> Komentari { get; set; } = new();

        public AddComment Comment { get; set; } = new();

        public List<UserModel> Korisnici { get; set; } = new();

        public UserModel Korisnik { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            UgostiteljskiObjekti = await Http.GetFromJsonAsync<List<UgostiteljskiObjektiModel>>("api/UgostiteljskiObjekti");

            ugostiteljskiObjekt = UgostiteljskiObjekti.FirstOrDefault(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));

            Dishes = await Http.GetFromJsonAsync<List<DishModel>>("api/Jela");

            values = Dishes.FindAll(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));

            Komentari = await Http.GetFromJsonAsync<List<CommentModel>>("api/Comment");

            Korisnici = await Http.GetFromJsonAsync<List<UserModel>>("api/User");

            string email = localStorage.GetItemAsString("email").Trim('"');

            Korisnik = Korisnici.FirstOrDefault(k => k.Email == email);


        }

        public void OpenDialog()
        {
            DialogService.Show<UgostiteljskiObjektDetailsDialog>("Uredi broj telefona", new DialogParameters
            {
                ["Brojtelefona"] = ugostiteljskiObjekt.UgostiteljskiObjektiKontakt,
                ["UOId"] = Id
            });
        }

        public void OpenDialogDish()
        {
            DialogService.Show<UgostiteljskiObjektiJela>("Dodaj novo jelo", new DialogParameters
            {
                ["UOId"] = ugostiteljskiObjekt.UgostiteljskiObjektiId
            });
        }

        public async Task DodajKomentar()
        {
            Comment.UgostiteljskiObjektId = ugostiteljskiObjekt.UgostiteljskiObjektiId;
            Comment.UserId = Korisnik.UserId;
            await Http.PostAsJsonAsync<AddComment>("api/Comment", Comment);
        }


    }
}
