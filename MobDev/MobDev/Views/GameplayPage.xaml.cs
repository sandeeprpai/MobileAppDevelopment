using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobDev.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GameplayPage : ContentPage
	{
	    GameplayViewModel viewModel;
	    public struct Text
	    {
	        public string Description { get; set; }
	    }

        public ObservableCollection<string> BattleText { get; set; }


		public GameplayPage ()
		{
			InitializeComponent ();
		}

	    public GameplayPage(GameplayViewModel viewModel)
	    {
	        InitializeComponent();

	        BindingContext = this.viewModel = viewModel;
	        BattleText = viewModel._BattleText;
	        BattleList.ItemsSource = this.BattleText;

            /*
             * for debugging
	        for (int x = 0; x < BattleText.Count; x++)
	            System.Diagnostics.Debug.WriteLine(BattleText[x]);
                */

	    }
        async void OnRestartGame(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
