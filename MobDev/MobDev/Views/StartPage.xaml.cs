using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobDev.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
			InitializeComponent ();
		}

	    async void OnManualButtonClicked(object sender, EventArgs args)
	    {
	        //Button button = (Button) sender;
	        await Navigation.PushAsync(new PartySelectPage(new PartySelectViewModel()));
	    }

	    async void OnAutoButtonClicked(object sender, EventArgs args)
	    {
	        //Button button = (Button) sender;
	        await Navigation.PushAsync(new GameplayPage(new GameplayViewModel()));
	    }
	}
}
