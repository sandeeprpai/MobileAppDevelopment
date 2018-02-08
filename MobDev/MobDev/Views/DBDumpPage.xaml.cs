using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobDev.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DBDumpPage : ContentPage
	{
	    
        public DBDumpPage ()
		{
			InitializeComponent ();
            
        }

	    void OnDeleteMonsterClicked(object sender, EventArgs args)
	    {
            MonsterDBDataAccess dbDataAccess = new MonsterDBDataAccess();
            dbDataAccess.DeleteAllMonsters();
	    }
        void OnDeletePlayerClicked(object sender, EventArgs args)
        {
            PlayerDBDataAccess dbDataAccess = new PlayerDBDataAccess();
            dbDataAccess.DeleteAllPlayers();
        }
        void OnDeleteItemClicked(object sender, EventArgs args)
        {
            ItemDBDataAccess dbDataAccess = new ItemDBDataAccess();
            dbDataAccess.DeleteAllItems(true);
        }
    }
}
