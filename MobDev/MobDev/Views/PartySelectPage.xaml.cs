using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobDev.Models;
using MobDev.Services;
using MobDev.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PartySelectPage : ContentPage
	{
	    private Player p;
        PlayerDBDataAccess dbDataAccess;
	    public List<Player> party;
        public List<string> partyNames = new List<string>();
        public PartySelectPage ()
		{
			InitializeComponent ();
		    this.dbDataAccess = new PlayerDBDataAccess();
            party = new List<Player>();
        }

	    public PartySelectPage(PartySelectViewModel view)
	    {
	        InitializeComponent();
	        this.dbDataAccess = new PlayerDBDataAccess();
            party = new List<Player>();
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

            //await Navigation.PushAsync(new PlayerDetailPage(p));
	        var result =
	            await DisplayAlert("Confirmation",
	                "Add this player to party?",
	                "OK", "Cancel");

            if (result == true) {
                if(!partyNames.Contains(p.Name)){
                    party.Add(p);
                    partyNames.Add(p.Name);
                } else
                {
                    await DisplayAlert("Alert",
                    "Already exists, select other player",
                    "OK");
                }
                
            }
	            

            // Manually deselect item
            PlayerList.SelectedItem = null;

            foreach (Player x in party)
                Debug.WriteLine(x.Name);
	    }

	    async void OnStartClicked(object sender, EventArgs args)
	    {
	        //Button button = (Button)sender;
	        await Navigation.PushAsync(new BattleTurnPage(new GameplayViewModel(party)));
        }
    }
}
