using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;
using MudBlazor;
using BrowserInterop.Extensions;
using Microsoft.JSInterop;

using BrowserInterop.Geolocation;

namespace WebAplikacijaZaUgostiteljskeObjekte.Client.Pages
{
    public class UgostiteljskiObjektiListBase : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; }

        [Parameter] public List<UgostiteljskiObjektiModel> UgostiteljskiObjekti { get; set; } = new();

        [Parameter] public UgostiteljskiObjektiModel? SelectedUO { get; set; }

        [Parameter] public int OdabranaOcjena { get; set; }

        [Parameter] public string? OdabraniTipUO { get; set; }

        [Parameter] public string? OdabraniGrad { get; set; }

        [Parameter] public int OdabraniRadijus { get; set; }

        [Inject] public IJSRuntime JSRunetime { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        private WindowNavigatorGeolocation geolocationWrapper;
        private GeolocationPosition currentPostion;

        public string? Provjera;

        protected override async Task OnInitializedAsync()
        {

            var window = await JSRunetime.Window();
            var navigator = await window.Navigator();
            geolocationWrapper = navigator.Geolocation;
            currentPostion = (await geolocationWrapper.GetCurrentPosition(new PositionOptions()
            {
                EnableHighAccuracy = false,
                MaximumAgeTimeSpan = TimeSpan.FromHours(1),
                TimeoutTimeSpan = TimeSpan.FromMinutes(1)
            })).Location;

            if (currentPostion != null)
            {
                Latitude = currentPostion.Coords.Latitude;
                Longitude = currentPostion.Coords.Longitude;

            }
        }

        public double Calculate(double lon1, double lat1, double lon2, double lat2)
        {
            double rad(double angle) => angle * 0.017453292519943295769236907684886127d; // = angle * Math.Pi / 180.0d
            double havf(double diff) => Math.Pow(Math.Sin(rad(diff) / 2d), 2); // = sin²(diff / 2)
            Console.WriteLine(12745.6 * Math.Asin(Math.Sqrt(havf(lat2 - lat1) + Math.Cos(rad(lat1)) * Math.Cos(rad(lat2)) * havf(lon2 - lon1))));
            return 12745.6 * Math.Asin(Math.Sqrt(havf(lat2 - lat1) + Math.Cos(rad(lat1)) * Math.Cos(rad(lat2)) * havf(lon2 - lon1))); // earth radius 6.372,8‬km x 2 = 12745.6
        }

        protected override void OnParametersSet()
        {
            if (!string.IsNullOrEmpty(OdabraniGrad))
            {
                OdabraniRadijus = 0;
            }
        }


    }
}
