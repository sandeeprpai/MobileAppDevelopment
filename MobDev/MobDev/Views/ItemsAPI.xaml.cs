using System;
using System.Collections.Generic;
using MobDev.Models;
using MobDev.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobDev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsAPI : ContentPage
	{
        ItemDBDataAccess dbDataAccess;
        public ItemsAPI()
        {
            
            InitializeComponent();
            

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!SettingsPage.isServerOn)
            {
                formforapi.IsVisible = false;
            }
            else
            {
                formforapi.IsVisible = true;
            }
            

            this.dbDataAccess = new ItemDBDataAccess(SettingsPage.isServerOn);
            //this.BindingContext = this.dbDataAccess;
        }

        async void Search_Button_Clicked(object sender, EventArgs e)
        {
            ItemRestClientService ItemService = new ItemRestClientService();

            
            ItemsFromAPI itemFromForm = (ItemsFromAPI)BindingContext;

            List<ItemsData> itemList = new List<ItemsData>();

            itemList = await ItemService.PostCharForPostClient(itemFromForm);

            //await rc.PostAsync(itemFromForm);
            //this.dbDataAccess = new ItemDBDataAccess(true);

            dbDataAccess.DeleteAllItems(SettingsPage.isServerOn);

            foreach (ItemsData item in itemList)
            {
                dbDataAccess.SaveOrUpdateItemData(item);
            }
            await Navigation.PushAsync(new ItemsPage(SettingsPage.isServerOn));



            //dataAccess.DeleteAllItem();
            //foreach (ItemModel item in items)
            //{
            //    dataAccess.InsertItem(item);
            //}



        }
    }
}
