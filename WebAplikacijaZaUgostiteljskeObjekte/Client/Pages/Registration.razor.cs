﻿using Microsoft.AspNetCore.Components;
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
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public HttpClient Http { get; set; }

        public List<UserModel> Users { get; set; } = new();
        public CreateUser NoviKorisnik { get; set; } = new();

        public int provjera = 0;

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
            provjera = 0;

            foreach(var user in Users)
            {
                if(NoviKorisnik.Email == user.Email)
                {
                    provjera = 1;
                }
            }

            if(provjera == 0)
            {
                await Http.PostAsJsonAsync<CreateUser>("api/User", NoviKorisnik);
                PokaziAlert();
                NavigationManager.NavigateTo("/");

            }
            else
            {
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                Snackbar.Add("Već postoji korisnik sa tom Email adresom!");
            }


        }

    }
}
