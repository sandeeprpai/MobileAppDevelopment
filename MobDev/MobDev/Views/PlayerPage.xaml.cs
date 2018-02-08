using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobDev.Models;
using MobDev.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerPage : ContentPage
	{
	    private Player p;
	    PlayerDBDataAccess dbDataAccess;
        public PlayerPage ()
		{
			InitializeComponent ();
		    this.dbDataAccess = new PlayerDBDataAccess();
        }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
            this.dbDataAccess = new PlayerDBDataAccess();
            this.BindingContext = this.dbDataAccess;
	    }

	    async void OnPlayerSelect(object sender, SelectedItemChangedEventArgs args)
	    {
	        var p = args.SelectedItem as Player;

	        if (p == null)
	            return;

	        await Navigation.PushAsync(new PlayerDetailPage(p));

	        // Manually deselect item
	        PlayerList.SelectedItem = null;
	    }

        async void OnAddClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayerAddPage());
        }

        // Save any pending changes
        private void OnSaveClick(object sender, EventArgs e)
        {
            this.dbDataAccess.SaveAllPlayers();
            Navigation.PopAsync();
        }
    }
}
