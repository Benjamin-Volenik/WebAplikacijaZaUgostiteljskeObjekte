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
        [Inject] NavigationManager navigationManager { get; set; }
        [Inject] public ISnackbar snackbar { get; set; }

        public List<UgostiteljskiObjektiModel> UgostiteljskiObjekti { get; set; } = new();

        public UgostiteljskiObjektiModel ugostiteljskiObjekt { get; set; } = new();

        public UgostiteljskiObjektiModel ugostiteljskiObjektEmail { get; set; } = new();

        public List<DishModel> Dishes { get; set; } = new();

        public List<DrinksModel> Drinks { get; set; } = new();

        //tablica podatci
        public List<DishModel> values = new();

        public List<DrinksModel> drinksValues = new();

        public List<CommentModel> Komentari { get; set; } = new();

        public AddComment Comment { get; set; } = new();

        public List<UserModel> Korisnici { get; set; } = new();

        public UserModel Korisnik { get; set; } = new();

        public AddGrade Grade { get; set; } = new();

        public List<OcjeneModel> Ocjene { get; set; } = new();

        public OcjeneModel OcjenaKorisnika { get; set; } = new();

        public List<OcjeneModel> sveOcjene { get; set; } = new();

        public string SelectedOption { get; set; }

        public float fSOcjene { get; set; }

        public float ProsjecnaOcjena { get; set; }

        public int UOProvjera { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UgostiteljskiObjekti = await Http.GetFromJsonAsync<List<UgostiteljskiObjektiModel>>("api/UgostiteljskiObjekti");

            ugostiteljskiObjekt = UgostiteljskiObjekti.FirstOrDefault(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));

            Dishes = await Http.GetFromJsonAsync<List<DishModel>>("api/Jela");

            Drinks = await Http.GetFromJsonAsync<List<DrinksModel>>("api/Drinks");

            values = Dishes.FindAll(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));

            drinksValues = Drinks.FindAll(d => d.UgostiteljskiObjektiId == Int32.Parse(Id));

            Komentari = await Http.GetFromJsonAsync<List<CommentModel>>("api/Comment");

            Korisnici = await Http.GetFromJsonAsync<List<UserModel>>("api/User");

            string email = localStorage.GetItemAsString("email");

            if (email != null)
            {
                string result = email.Trim('"');
                Korisnik = Korisnici.FirstOrDefault(k => k.Email == result);
                if (Korisnik == null)
                {
                    ugostiteljskiObjektEmail = UgostiteljskiObjekti.FirstOrDefault(uo => uo.UgostiteljskiObjektiEmali == result);
                }
            }

            Ocjene = await Http.GetFromJsonAsync<List<OcjeneModel>>("api/Ocjene");

            if (Korisnik != null)
            {
                OcjenaKorisnika = Ocjene.FirstOrDefault(o => o.UserId == Korisnik.UserId && o.UgostiteljskiObjektiId == ugostiteljskiObjekt.UgostiteljskiObjektiId);
                UOProvjera = 0;

            }
            else
            {
                OcjenaKorisnika = null;
                UOProvjera = 1;
            }

            sveOcjene = Ocjene.FindAll(o => o.UgostiteljskiObjektiId == ugostiteljskiObjekt?.UgostiteljskiObjektiId);

            foreach (var ocjene in sveOcjene)
            {
                fSOcjene = fSOcjene + ocjene.Ocjena;
            }

            if (fSOcjene == 0)
            {
                ProsjecnaOcjena = 0;
            }
            else
            {
                ProsjecnaOcjena = fSOcjene / sveOcjene.Count();
            }

            ugostiteljskiObjekt.UgostiteljskiObjektiProsjecnaOcjena = Convert.ToSingle(ProsjecnaOcjena);

            await Http.PutAsJsonAsync("api/UgostiteljskiObjekti", ugostiteljskiObjekt);

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
            if (Comment.CommentText != null)
            {
                Comment.UgostiteljskiObjektId = ugostiteljskiObjekt.UgostiteljskiObjektiId;
                Comment.UserId = Korisnik.UserId;
                await Http.PostAsJsonAsync<AddComment>("api/Comment", Comment);
                Korisnici = await Http.GetFromJsonAsync<List<UserModel>>("api/User");
                Comment.CommentText = null;
                snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                snackbar.Add("Uspješno ste dodali komentar.");
            }
            else
            {
                snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                snackbar.Add("Niste upisali tekst!");
            }

        }

        public async Task DodajOcjenu()
        {
            Grade.UgostiteljskiObjektiId = ugostiteljskiObjekt.UgostiteljskiObjektiId;
            Grade.UserId = Korisnik.UserId;
            Grade.Ocjena = Int32.Parse(SelectedOption);
            await Http.PostAsJsonAsync<AddGrade>("api/Ocjene", Grade);
            navigationManager.NavigateTo("/ugostiteljskiobjekti/" + Id, true);
            snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            snackbar.Add("Vaša ocjena je zabilježena");
        }

        public async Task DeleteComment(CommentModel komentar)
        {
            await Http.DeleteAsync($"api/Comment/{komentar.CommentId}");
            Korisnici.FirstOrDefault(k => k.UserId == komentar.UserId).Comments.Remove(komentar);
        }

        public async Task ObrisiJelo(DishModel jelo)
        {
            await Http.DeleteAsync($"api/Jela/{jelo.JelaId}");
            Dishes.Remove(jelo);
            values = Dishes.FindAll(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));
        }

        public async Task ObrisiOcjenu(OcjeneModel ocjena)
        {
            await Http.DeleteAsync($"api/Ocjene/{ocjena.OcjeneId}");
            navigationManager.NavigateTo("/ugostiteljskiobjekti/" + Id, true);

        }

        public async Task ObrisiPice(DrinksModel pice)
        {
            await Http.DeleteAsync($"api/Drinks/{pice.DrinksId}");
            Drinks.Remove(pice);
            drinksValues = Drinks.FindAll(d => d.UgostiteljskiObjektiId == Int32.Parse(Id));
        }


    }
}
