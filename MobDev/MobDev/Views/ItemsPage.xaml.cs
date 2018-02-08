using System;

using MobDev.Models;
using MobDev.Services;
using MobDev.ViewModels;

using Xamarin.Forms;
using System.Collections.Generic;

namespace MobDev.Views
{
	public partial class ItemsPage : ContentPage
	{
        bool i = false;
        ItemDBDataAccess dbDataAccess;
        public ItemsPage()
        {
            InitializeComponent();
            this.dbDataAccess = new ItemDBDataAccess();
        }

        public ItemsPage(bool i)
        {
            InitializeComponent();
            this.i = i;
            this.dbDataAccess = new ItemDBDataAccess(i);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            i = SettingsPage.isServerOn;

            if(SettingsPage.isServerOn)
            {
                callRest(SettingsPage.isRandomOn, SettingsPage.isSuperOn);

            }

            this.dbDataAccess = new ItemDBDataAccess(i);
            if(i)
            {
                ItemsList.ItemsSource = dbDataAccess.ItemsAPI;
            } else
            {
                ItemsList.ItemsSource = dbDataAccess.Items;
            }
            
            this.BindingContext = this.dbDataAccess;
        }

        private async void callRest(int random, int super)
        {
            ItemRestClientService ItemService = new ItemRestClientService();

            ItemsFromAPI itemFromForm = new ItemsFromAPI(random, super);

            // = (ItemsFromAPI)BindingContext;

            List<ItemsData> itemList = new List<ItemsData>();

            itemList = await ItemService.PostCharForPostClient(itemFromForm);
            
            dbDataAccess.DeleteAllItems(SettingsPage.isServerOn);

            foreach (ItemsData item in itemList)
            {
                dbDataAccess.SaveOrUpdateItemData(item);
            }
        }

        async void OnItemSelect(object sender, SelectedItemChangedEventArgs args)
        {
            if (i)
            {
                var i = args.SelectedItem as ItemsData;

                if (i == null)
                    return;

                await Navigation.PushAsync(new ItemDetailPage(i));
            }
            else
            {
                var i = args.SelectedItem as GameItem;

                if (i == null)
                    return;

                await Navigation.PushAsync(new ItemDetailPage(i));
            }
            // Manually deselect item
            ItemsList.SelectedItem = null;
        }

        async void OnItemSelectAPI(object sender, SelectedItemChangedEventArgs args)
        {
            var i = args.SelectedItem as ItemsData;

            if (i == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(i));

            // Manually deselect item
            ItemsList.SelectedItem = null;
        }

        async void OnAddClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsAddPage());
        }

        // Save any pending changes
        private void OnSaveClick(object sender, EventArgs e)
        {
            this.dbDataAccess.SaveAllItems();
            Navigation.PopAsync();
        }
    }
}
