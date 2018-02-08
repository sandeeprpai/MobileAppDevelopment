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
	public partial class PlayerDetailPage : ContentPage
	{
	    public Player p { get; set; }
        PlayerDBDataAccess dbDataAccess;
        public PlayerDetailPage ()
		{
			InitializeComponent ();
		}

	    public PlayerDetailPage(Player p)
	    {
	        InitializeComponent();
            this.dbDataAccess = new PlayerDBDataAccess();
            this.p = p;
	        this.BindingContext = this.p;
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            dbDataAccess.DeletePlayer(this.p);
            await Navigation.PopAsync();
        }
    }
}
