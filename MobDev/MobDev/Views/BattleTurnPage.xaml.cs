using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobDev.Models;
using MobDev.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobDev.Controller;
using System.Collections.ObjectModel;
using System.Collections;
using System.Diagnostics;

namespace MobDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattleTurnPage : ContentPage
	{
	    GameplayViewModel viewModel;
        int counter = 0;
	    private int teamScore = 0;
        ObservableCollection<string> battleText;
        List<Player> party { get; set; }
        public ObservableCollection<string> BattleText { get; set; }

        public BattleTurnPage(GameplayViewModel viewModel)
	    {
	        InitializeComponent();
	        BindingContext = this.viewModel = viewModel;

            BattleText = viewModel._BattleText;
            BattleList.ItemsSource = this.BattleText;

	        if (counter == 0)
	            Stats.IsEnabled = false;
	        

	    }

        async void NextButtonClicked(object sender, EventArgs args)
        {
            party = viewModel.party;

            if (Next.Text == "Final Score")
            {
                Debug.WriteLine("This is teamscore before going to final score: " + teamScore);
                await Navigation.PushAsync(new ScoresPage(teamScore, party));
            }



            if (counter < party.Count)
            {
                viewModel.battle.FightUntilDead(party.ElementAt(counter), true);
                teamScore = viewModel.battle.monstersKilled;
            }
                
            else
                Next.Text = "Final Score";
            counter++;

            if (counter != 0)
                Stats.IsEnabled = true;

            if (Next.Text.Equals("Final Score"))
                Stats.IsEnabled = false;

        }

        async void OnCharacterButtonClicked(object sender, EventArgs e)
	    {
            Player p = party.ElementAt(counter - 1);


            await Navigation.PushAsync(new PlayerDetailPage(p));

	        // Manually deselect item
	        //PlayerList.SelectedItem = null;
	    }

        
        
    }
}
