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
	public partial class MonsterDetailPage : ContentPage
	{
        public Monster m { get; set; }
	    MonsterDBDataAccess dbDataAccess;
        public MonsterDetailPage ()
		{
			InitializeComponent ();
		}

	    public MonsterDetailPage(Monster m)
	    {
            InitializeComponent();

	        this.dbDataAccess = new MonsterDBDataAccess();
            this.m = m;
	        this.BindingContext = this.m;
	    }

        // Save any pending changes
        private void OnSaveClick(object sender, EventArgs e)
	    {
	        this.dbDataAccess.SaveOrUpdateMonster(this.m);
            Navigation.PopAsync();
        }

	    async void OnButtonClicked(object sender, EventArgs args)
	    {
	        Button button = (Button)sender;
	        dbDataAccess.DeleteMonster(this.m);
            await Navigation.PopAsync();
        }
    }
}
