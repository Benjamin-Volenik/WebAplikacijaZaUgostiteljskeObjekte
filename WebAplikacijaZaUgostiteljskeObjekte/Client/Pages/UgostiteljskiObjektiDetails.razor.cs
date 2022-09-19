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

        public List<AdminModel> Admini { get; set; } = new();

        public AdminModel Admin { get; set; } = new();

        public string SelectedOption { get; set; }

        public float fSOcjene { get; set; }

        public float ProsjecnaOcjena { get; set; }

        public int UOProvjera { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UgostiteljskiObjekti = await Http.GetFromJsonAsync<List<UgostiteljskiObjektiModel>>("api/UgostiteljskiObjekti");

            ugostiteljskiObjekt = UgostiteljskiObjekti.FirstOrDefault(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));

            if(ugostiteljskiObjekt == null)
            {
                navigationManager.NavigateTo("/404");
            }

            Dishes = await Http.GetFromJsonAsync<List<DishModel>>("api/Jela");

            Drinks = await Http.GetFromJsonAsync<List<DrinksModel>>("api/Drinks");

            values = Dishes.FindAll(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));

            drinksValues = Drinks.FindAll(d => d.UgostiteljskiObjektiId == Int32.Parse(Id));

            Komentari = await Http.GetFromJsonAsync<List<CommentModel>>("api/Comment");

            Korisnici = await Http.GetFromJsonAsync<List<UserModel>>("api/User");

            Admini = await Http.GetFromJsonAsync<List<AdminModel>>("api/Admin");

            string email = localStorage.GetItemAsString("email");

            if (email != null)
            {
                string result = email.Trim('"');
                Korisnik = Korisnici.FirstOrDefault(k => k.Email == result);
                Admin = Admini.FirstOrDefault(x => x.Email == result);
                if (Korisnik == null && Admin == null)
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

             //ugostiteljskiObjekt.UgostiteljskiObjektiProsjecnaOcjena = Convert.ToSingle(ProsjecnaOcjena);

            await Http.PutAsJsonAsync("api/UgostiteljskiObjekti", ugostiteljskiObjekt);

        }

        public void OpenDialog()
        {
            DialogService.Show<UgostiteljskiObjektDetailsDialog>("Uredi informacije", new DialogParameters
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

        public void OpenDialogDrink()
        {
            DialogService.Show<UgostiteljskiObjektiDrinkDialog>("Dodaj novo piće", new DialogParameters
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
                Comment.CommentTime = DateTime.Now; 
                await Http.PostAsJsonAsync<AddComment>("api/Comment", Comment);
                Komentari = await Http.GetFromJsonAsync<List<CommentModel>>("api/Comment");
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
            fSOcjene = 0;
            Grade.UgostiteljskiObjektiId = ugostiteljskiObjekt.UgostiteljskiObjektiId;
            Grade.UserId = Korisnik.UserId;
            Grade.Ocjena = Int32.Parse(SelectedOption);
            Grade.OcjenaVrijeme = DateTime.Now;
            await Http.PostAsJsonAsync<AddGrade>("api/Ocjene", Grade);
            Ocjene = await Http.GetFromJsonAsync<List<OcjeneModel>>("api/Ocjene");
            sveOcjene = Ocjene.FindAll(o => o.UgostiteljskiObjektiId == ugostiteljskiObjekt?.UgostiteljskiObjektiId);
            OcjenaKorisnika = Ocjene.FirstOrDefault(o => o.UserId == Korisnik.UserId && o.UgostiteljskiObjektiId == ugostiteljskiObjekt.UgostiteljskiObjektiId);
            UgostiteljskiObjekti = await Http.GetFromJsonAsync<List<UgostiteljskiObjektiModel>>("api/UgostiteljskiObjekti");
            ugostiteljskiObjekt = UgostiteljskiObjekti.FirstOrDefault(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));
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
            snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            snackbar.Add("Vaša ocjena je zabilježena");
        }

        public async Task DeleteComment(CommentModel komentar)
        {
            await Http.DeleteAsync($"api/Comment/{komentar.CommentId}");
            Korisnici.FirstOrDefault(k => k.UserId == komentar.UserId).Comments.Remove(komentar);
            snackbar.Add("Obrisali ste komentar");
            Komentari = await Http.GetFromJsonAsync<List<CommentModel>>("api/Comment");
        }

        public async Task ObrisiJelo(DishModel jelo)
        {
            await Http.DeleteAsync($"api/Jela/{jelo.JelaId}");
            Dishes.Remove(jelo);
            values = Dishes.FindAll(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));
        }

        public async Task ObrisiOcjenu(OcjeneModel ocjena)
        {
            fSOcjene = 0;
            await Http.DeleteAsync($"api/Ocjene/{ocjena.OcjeneId}");
            Ocjene.Remove(ocjena);
            sveOcjene = Ocjene.FindAll(o => o.UgostiteljskiObjektiId == ugostiteljskiObjekt?.UgostiteljskiObjektiId);
            OcjenaKorisnika = Ocjene.FirstOrDefault(o => o.UserId == Korisnik.UserId && o.UgostiteljskiObjektiId == ugostiteljskiObjekt.UgostiteljskiObjektiId);
            UgostiteljskiObjekti = await Http.GetFromJsonAsync<List<UgostiteljskiObjektiModel>>("api/UgostiteljskiObjekti");
            ugostiteljskiObjekt = UgostiteljskiObjekti.FirstOrDefault(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));
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
            snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;

        }

        public async Task ObrisiPice(DrinksModel pice)
        {
            await Http.DeleteAsync($"api/Drinks/{pice.DrinksId}");
            Drinks.Remove(pice);
            drinksValues = Drinks.FindAll(d => d.UgostiteljskiObjektiId == Int32.Parse(Id));
        }

        public void UrediJelo(DishModel uredijelo)
        {
            DialogService.Show<JelaDialog>("Uredi jelo", new DialogParameters
            {
                ["JeloId"] = uredijelo.JelaId
            });
        }
        public void UrediPice(DrinksModel uredipice)
        {
            DialogService.Show<PicaDialog>("Uredi piće", new DialogParameters
            {
                ["PiceId"] = uredipice.DrinksId
            });
        }
        protected override void OnParametersSet()
        {
            if (ugostiteljskiObjekt.UgostiteljskiObjektiId != Int32.Parse(Id))
            {
                ugostiteljskiObjekt = UgostiteljskiObjekti.FirstOrDefault(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));
                values = Dishes.FindAll(u => u.UgostiteljskiObjektiId == Int32.Parse(Id));
                drinksValues = Drinks.FindAll(d => d.UgostiteljskiObjektiId == Int32.Parse(Id));
            }
        }

    }
}
