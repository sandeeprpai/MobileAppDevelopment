using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobDev.Models;
using MobDev.Services;

namespace MobDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonsterPage : ContentPage
	{
	    MonsterDBDataAccess dbDataAccess;
		public MonsterPage ()
		{
            InitializeComponent();
            this.dbDataAccess = new MonsterDBDataAccess();
        }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
            this.dbDataAccess = new MonsterDBDataAccess();
            this.BindingContext = this.dbDataAccess;
        }

	    async void OnMonsterSelect(object sender, SelectedItemChangedEventArgs args)
	    {
	        var m = args.SelectedItem as Monster;

	        if (m == null)
	            return;

	        await Navigation.PushAsync(new MonsterDetailPage(m));

	        // Manually deselect item
	        MonsterList.SelectedItem = null;
	    }

	    async void OnAddClick(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new MonsterAddPage());
        }

        // Save any pending changes
        private void OnSaveClick(object sender, EventArgs e)
	    {
	        this.dbDataAccess.SaveAllMonsters();
            Navigation.PopAsync();
        }

        /*
	    async void OnButtonClicked(object sender, EventArgs args)
	    {
	        Button button = (Button)sender;
	        await Navigation.PushAsync(new MonsterAddPage());
	    }*/



    }
}
