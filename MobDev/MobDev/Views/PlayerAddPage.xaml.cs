using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobDev.Models;
using MobDev.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace MobDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerAddPage : ContentPage
	{
        PlayerDBDataAccess dbDataAccess;
        public Player p { get; set; }
        public PlayerAddPage ()
		{
			InitializeComponent ();

            this.dbDataAccess = new PlayerDBDataAccess();
            this.p = new Player();

            p.Name = "Default";
            p.Speed = 1;
            p.HP = 1;
            p.Strength = 1;
            p.characterAttackLevel = 1;
            p.characterItemBonus = 0;
            Debug.WriteLine("New monster id is: " + p.ID);

            dbDataAccess.AddNewPlayer(p);
            this.BindingContext = this.p;
        }
        private void OnSaveClick(object sender, EventArgs e)
        {
            this.dbDataAccess.SaveOrUpdatePlayer(this.p);
            Navigation.PopAsync();
        }
    }
}
