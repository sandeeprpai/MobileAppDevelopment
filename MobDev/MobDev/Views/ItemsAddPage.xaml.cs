using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MobDev.Services;
using MobDev.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace MobDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsAddPage : ContentPage
	{
        ItemDBDataAccess dbDataAccess;
        public GameItem i { get; set; }
        public ItemsAddPage ()
		{
			InitializeComponent ();

            this.dbDataAccess = new ItemDBDataAccess();
            this.i = new GameItem();

            i.Name = "Default";
            i.Type = "DefaultType";
            i.PowerLevel = 1;
            Debug.WriteLine("New Item id is: " );

            dbDataAccess.AddNewItem(i);
            this.BindingContext = this.i;
        }

        
        // Save any pending changes
        private void OnSaveClick(object sender, EventArgs e)
        {
            this.dbDataAccess.SaveOrUpdateItem(this.i);
            Navigation.PopAsync();
        }
    }
}
