using Microsoft.AspNetCore.Components;

namespace WebAplikacijaZaUgostiteljskeObjekte.Client.Pages
{
	public partial class CustomNotFound
	{
		[Inject]
		public NavigationManager NavigationManager { get; set; }

		public void NavigateToHome()
		{
			NavigationManager.NavigateTo("/");
		}
	}
}
