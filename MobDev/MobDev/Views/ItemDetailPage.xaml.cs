using MobDev.Models;
using MobDev.Services;
using MobDev.ViewModels;
using System;
using Xamarin.Forms;

namespace MobDev.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public GameItem i { get; set; }
        public ItemsData it { get; set; }
        ItemDBDataAccess dbDataAccess;
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(GameItem i)
        {
            InitializeComponent();

            this.dbDataAccess = new ItemDBDataAccess();
            this.i = i;
            this.BindingContext = this.i;
        }

        public ItemDetailPage(ItemsData i)
        {
            InitializeComponent();

            this.dbDataAccess = new ItemDBDataAccess();
            this.it = i;
            this.BindingContext = this.it;
        }

        // Save any pending changes
        private void OnSaveClick(object sender, EventArgs e)
        {
            this.dbDataAccess.SaveOrUpdateItem(this.i);
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            dbDataAccess.DeleteItem(this.i);
            Navigation.PopAsync();
        }
    }
}