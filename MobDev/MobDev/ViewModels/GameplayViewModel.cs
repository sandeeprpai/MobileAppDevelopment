using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using MobDev.Controller;
using MobDev.Models;
using Xamarin.Forms;

namespace MobDev.ViewModels
{
	public class GameplayViewModel : ContentPage
	{
	    public BattleController battle;
	    public Player currentPlayer { get; set; }
        public List<Player> party { get; set; }
        public ObservableCollection<string> _BattleText { get; set; }
		public GameplayViewModel ()
		{
            IMonsterGen monster = new MonsterGen();
		    List<Player> party = new List<Player>(4);
		    _BattleText = new ObservableCollection<string>();

            battle = new BattleController();

		    battle.LaunchBattleEngine(false);
		    _BattleText = battle.battleText;
		}

        /// <summary>
        /// Constructor that accepts player-chosen party
        /// </summary>
        /// <param name="party"></param>
	    public GameplayViewModel(List<Player> party)
	    {
	        this.party = party;
            _BattleText = new ObservableCollection<string>();
            battle = new BattleController(party);
            _BattleText = battle.battleText;
	    }
    }
}
