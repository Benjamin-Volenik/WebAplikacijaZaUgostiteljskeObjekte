using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;
using MudBlazor;
using BrowserInterop.Extensions;
using BrowserInterop.Geolocation;
using Microsoft.JSInterop;

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

        public double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));

        }

        public double DistanceTo(double lon1, double lat1, double lon2, double lat2)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            return dist * 1.609344;
        }

        public double Calculate(double lon1, double lat1, double lon2, double lat2)
        {
            double rad(double angle) => angle * 0.017453292519943295769236907684886127d; // = angle * Math.Pi / 180.0d
            double havf(double diff) => Math.Pow(Math.Sin(rad(diff) / 2d), 2); // = sin²(diff / 2)
            Console.WriteLine(12745.6 * Math.Asin(Math.Sqrt(havf(lat2 - lat1) + Math.Cos(rad(lat1)) * Math.Cos(rad(lat2)) * havf(lon2 - lon1))));
            return 12745.6 * Math.Asin(Math.Sqrt(havf(lat2 - lat1) + Math.Cos(rad(lat1)) * Math.Cos(rad(lat2)) * havf(lon2 - lon1))); // earth radius 6.372,8‬km x 2 = 12745.6
        }



    }
}
