using MobDev.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScoresPage : ContentPage
	{
        public int finalScore { get; set; }
        public ScoresPage ()
		{
			InitializeComponent ();
        }

        public ScoresPage(int teamScore, List<Player> party)
	    {
	        InitializeComponent();

            this.finalScore = teamScore;
            Debug.WriteLine("This is teamscore: " + teamScore);
            Team.ItemsSource = party;
            BindingContext = this;
        }

        async void OnRestartGame(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }

        void OnScoreSelect(object sender, SelectedItemChangedEventArgs args)
        {
            // Manually deselect item
            Team.SelectedItem = null;
        }
    }
}
