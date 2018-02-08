using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	public partial class MonsterAddPage : ContentPage
	{
	    MonsterDBDataAccess dbDataAccess;
        public Monster m { get; set; }
        public MonsterAddPage ()
		{
			InitializeComponent ();

		    this.dbDataAccess = new MonsterDBDataAccess();
            this.m = new Monster();

		    m.Name = "Default";
		    m.Speed = 1;
		    m.HP = 1;
		    m.Strength = 1;
		    m.characterAttackLevel = 1;
		    m.characterItemBonus = 0;
		    Debug.WriteLine("New monster id is: " + m.ID);

		    dbDataAccess.AddNewMonster(m);
            this.BindingContext = this.m;
        }

        /*
	    public MonsterAddPage(Monster m)
	    {
	        InitializeComponent();

	        this.dbDataAccess = new MonsterDBDataAccess();
	        m = new Monster();
	        this.m = m;
	        this.BindingContext = this.m;
	    }*/

        // Save any pending changes
        private void OnSaveClick(object sender, EventArgs e)
	    {
	        this.dbDataAccess.SaveOrUpdateMonster(this.m);
            Navigation.PopAsync();
        }
    }
}
