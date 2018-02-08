using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using MobDev.Models;
using MobDev.Services;
using MobDev.Views;

namespace MobDev.Controller
{
    public interface IMonsterGen
    {
        Models.Monster Generate(string name, int speed, int HP,
            int Strength, int characterAttacklevel, int characterItemBonus);
    }

    public class MonsterGen : IMonsterGen
    {
        public Monster Generate(string name, int speed, int HP,
            int Strength, int characterAttacklevel, int characterItemBonus)
        {
            return new Monster(name, speed, HP, Strength,
                characterAttacklevel, characterItemBonus);
        }
    }

    public class BattleController
    {
        public const int PARTYSIZE = 4;
        public const int BASE_MAX_STRENGTH = 40;
        public const double STRENGTH_WEIGHT = 0.7;
        public const double LEVEL_WEIGHT = 0.6;
        public ObservableCollection<string> battleText;
        bool isNotAuto = false;

        public ObservableCollection<Monster> sampleMonsterNames;
        public ObservableCollection<Player> samplePlayerNames;
        public ObservableCollection<GameItem> sampleItemNames;
        public ObservableCollection<ItemsData> sampleItemNamesAPI;
        Random rand;
        public GameItem lastDroppedItem { get; set; }
        public ItemsData lastDroppedItemAPI { get; set; }
        public int monstersKilled { get; set; }
        List<Models.Player> Party { get; set; }
        List<Models.Monster> Monster { get; set; }
        private MonsterDBDataAccess monsterDB;
        private PlayerDBDataAccess playerDB;
        private ItemDBDataAccess gameItemDB;
        Models.Monster currentMonster = null;
        public IMonsterGen MonsterGen { get; set; }
        public CharacterController PlayerLogic = new PlayerController();
        public CharacterController MonsterLogic = new MonsterController();

        List<string> PlayersNames = new List<string>();

        public BattleController(List<Models.Player> party, IMonsterGen monsterGen)
        {
            Party = party;
            MonsterGen = monsterGen;
        }

        public BattleController(List<Models.Player> party, List<Models.Monster> monster)
        {
            Party = party;
            Monster = monster;
        }

        public BattleController(List<Player> party)
        {
            this.battleText = new ObservableCollection<string>();
            this.Party = party;

            sampleMonsterNames = new ObservableCollection<Monster>();
            sampleItemNames = new ObservableCollection<GameItem>();
            sampleItemNamesAPI = new ObservableCollection<ItemsData>();

            monsterDB = new MonsterDBDataAccess();
            sampleMonsterNames = monsterDB.Monsters;
            if (SettingsPage.isServerOn)
            {
                sampleItemNamesAPI = new ObservableCollection<ItemsData>();
                gameItemDB = new ItemDBDataAccess(SettingsPage.isServerOn);
                lastDroppedItemAPI = new ItemsData();
                lastDroppedItemAPI.BodyPart = "Nothing";
                sampleItemNamesAPI = gameItemDB.ItemsAPI;
            }
            else
            {
                sampleItemNames = new ObservableCollection<GameItem>();
                gameItemDB = new ItemDBDataAccess(SettingsPage.isServerOn);
                lastDroppedItem = new GameItem();
                lastDroppedItem.Type = "Nothing";
                sampleItemNames = gameItemDB.Items;
            }



            rand = new Random();
            monstersKilled = 0;

            MonsterGen = new MonsterGen();
            initMonster();



        }

        public BattleController()
        {
            this.battleText = new ObservableCollection<string>();
            sampleMonsterNames = new ObservableCollection<Monster>();
            samplePlayerNames = new ObservableCollection<Player>();
            if (SettingsPage.isServerOn)
            {
                sampleItemNamesAPI = new ObservableCollection<ItemsData>();
                gameItemDB = new ItemDBDataAccess(SettingsPage.isServerOn);
                lastDroppedItemAPI = new ItemsData();
                lastDroppedItemAPI.BodyPart = "Nothing";
                sampleItemNamesAPI = gameItemDB.ItemsAPI;
            }
            else
            {
                sampleItemNames = new ObservableCollection<GameItem>();
                gameItemDB = new ItemDBDataAccess(SettingsPage.isServerOn);
                lastDroppedItem = new GameItem();
                lastDroppedItem.Type = "Nothing";
                sampleItemNames = gameItemDB.Items;
            }


            monsterDB = new MonsterDBDataAccess();
            sampleMonsterNames = monsterDB.Monsters;

            playerDB = new PlayerDBDataAccess();
            samplePlayerNames = playerDB.Players;



            Party = new List<Player>(PARTYSIZE);
            rand = new Random();
            monstersKilled = 0;
            initParty();

            MonsterGen = new MonsterGen();
            initMonster();


        }

        private void initParty()
        {
            for (int x = 0; x < PARTYSIZE; x++)
            {
                int index = rand.Next(samplePlayerNames.Count);
                int randStr = rand.Next(25, BASE_MAX_STRENGTH);

                Player p =
                    new Player(samplePlayerNames[index].Name, 1, 100, randStr, 1, 0);
                while (PlayersNames.Contains(p.Name))
                {
                    index = rand.Next(samplePlayerNames.Count);
                    p =
                    new Player(samplePlayerNames[index].Name, 1, 100, randStr, 1, 0);
                }
                Party.Add(p);
                PlayersNames.Add(p.Name);
            }
        }

        private void initMonster()
        {
            int index = rand.Next(sampleMonsterNames.Count);
            int randStr = rand.Next(25, BASE_MAX_STRENGTH);

            currentMonster =
                MonsterGen.Generate(sampleMonsterNames[index].Name, 1, 100, randStr, 1, 0);

        }

        public void LaunchBattleEngine(bool isNotAuto)
        {
            foreach (Models.Player p in Party)
            {
                if (!SettingsPage.isServerOn)
                    lastDroppedItem.Type = "Nothing";
                FightUntilDead(p, isNotAuto);
            }

            battleText.Add("Final score: " + monstersKilled);
        }

        public ObservableCollection<string> FightUntilDead(Models.Player p, bool isNotAuto)
        {
            if (isNotAuto)
                battleText.Clear();
            while (p.HP > 0)
            {
                if (currentMonster == null || currentMonster.HP <= 0)
                {
                    int index = rand.Next(sampleMonsterNames.Count);
                    int randStr = rand.Next(25, BASE_MAX_STRENGTH);
                    int hpMonsterForFist = 100;
                    if (p.characterItemBonus == 0)
                    {
                        hpMonsterForFist = 40;
                    }

                    currentMonster =
                        MonsterGen.Generate(sampleMonsterNames[index].Name, 1, hpMonsterForFist, randStr, 1, 0);
                }

                CurrentPlayerBattle(p, currentMonster);
            }
            return battleText;
        }

        public void CurrentPlayerBattle(Models.Player p, Monster m)
        {
            int playerDamage = 0;
            int monsterDamage = 0;
            string text = p.Name + " vs " + m.Name + "...FIGHT!";
            battleText.Add(text);

            // keep alternating turns while no one is dead
            while (!PlayerLogic.IsDead(p) && !MonsterLogic.IsDead(m))
            {
                if (SettingsPage.isServerOn)
                {
                    playerDamage = PlayerLogic.CalculateDamage(p, battleText, lastDroppedItemAPI.Name);
                }
                else
                {
                    playerDamage = PlayerLogic.CalculateDamage(p, battleText, lastDroppedItem.Name);
                }

                m.HP -= playerDamage;
                if (SettingsPage.isServerOn)
                {
                    if (SettingsPage.isMagicOn && lastDroppedItemAPI.BodyPart.Contains("MAGIC"))
                        text = "Player " + p.Name + " did " + playerDamage +
                               " magic damage on monster " + m.Name;
                    else if (lastDroppedItemAPI.BodyPart.Contains("ATTKARM"))
                        text = "Player " + p.Name + " did " + playerDamage +
                               " physical damage on monster " + m.Name;
                    else
                        text = "Player " + p.Name + " did " + playerDamage +
                            " damage on monster " + m.Name;
                }
                else
                {
                    if (lastDroppedItem.Type.Equals("Magic"))
                        text = "Player " + p.Name + " did " + playerDamage +
                               " magic damage on monster " + m.Name;
                    else if (lastDroppedItem.Type.Contains("Weapon"))
                        text = "Player " + p.Name + " did " + playerDamage +
                               " physical damage on monster " + m.Name;
                    else
                        text = "Player " + p.Name + " did " + playerDamage +
                            " damage on monster " + m.Name;
                }


                battleText.Add(text);

                // monster should not get to take its
                // turn unless it is still alive
                if (m.HP > 0)
                {
                    if (SettingsPage.isServerOn)
                    {
                        monsterDamage = MonsterLogic.CalculateDamage(m, battleText, lastDroppedItemAPI.Name);
                    }
                    else
                    {
                        monsterDamage = MonsterLogic.CalculateDamage(m, battleText, lastDroppedItem.Name);
                    }

                    if (p.characterItemBonus > 20)
                    {
                        m.characterItemBonus = 20;
                    }

                    p.HP -= monsterDamage;
                    text = "Monster " + m.Name + " did " + monsterDamage +
                           " damage on player " + p.Name;
                    battleText.Add(text);
                }

                // monster defeated player
                if (p.HP <= 0)
                {
                    text = "Player " + p.Name + " died!!!";
                    battleText.Add(text);
                }

                // player defeated monster
                if (m.HP <= 0)
                {
                    text = "Monster " + m.Name + " died!!!";
                    battleText.Add(text);

                    PostBattle(text, p, m, SettingsPage.isServerOn);

                    battleText.Add("Calculating experience...");
                    int temp = p.Level;
                    int exp = CalculateEarnedExp(p, m);
                    battleText.Add(p.Name + " earned " + exp + " experience!");

                    PlayerLogic.AddExperience(p, exp);

                    if (temp < p.Level)
                    {
                        battleText.Add(p.Name + " leveled up!");
                        battleText.Add(p.Name + " is now level " + p.Level);
                    }

                    monstersKilled++;
                    p.Score += 1;
                }
            }
            battleText.Add("");
        }

        /// <summary>
        /// Calculate experience earned based on a logistic function.
        /// Scales experience earned based on the difference in player and
        /// monster attack strength
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int CalculateEarnedExp(Player p, Monster m)
        {
            double expWeight = STRENGTH_WEIGHT * (m.Strength - p.Strength) +
                            LEVEL_WEIGHT * (m.characterAttackLevel - p.characterAttackLevel);
            double expFunc = 1 / (1 + Math.Exp(-expWeight));
            int expGained = (int)(10 * expFunc);

            return expGained;
        }

        /// <summary>
        /// Post-battle events: items, etc.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="isServerOn"></param>
        public void PostBattle(string text, Player p, Monster m, bool isServerOn)
        {
            int index;

            if (isServerOn)
            {
                index = rand.Next(sampleItemNamesAPI.Count);

                lastDroppedItemAPI = sampleItemNamesAPI[index];
                text = m.Name + " dropped " + lastDroppedItemAPI.Name;
            }
            else
            {
                index = rand.Next(sampleItemNames.Count);
                lastDroppedItem = sampleItemNames[index];
                text = m.Name + " dropped " + lastDroppedItem.Name;
            }

            battleText.Add(text);
            if (isServerOn)
            {
                if (lastDroppedItemAPI.Description.Contains("HP") && SettingsPage.isHealingOn)
                {
                    p.HP += 20;
                    battleText.Add("Healing...!!!");
                    text = "Player's HP increased to " + p.HP;
                }
                if (lastDroppedItemAPI.BodyPart.Contains("MAGIC") && SettingsPage.isMagicOn)
                {
                    text = p.Name + " picked Magic Item " + lastDroppedItemAPI.Name;
                }
                else
                {
                    text = p.Name + " picked Item " + lastDroppedItemAPI.Name;
                }
                p.characterItemBonus += 10;
                text = "Player's Item bonus increased to " + p.characterItemBonus;
            }
            else
            {
                if (sampleItemNames[index].Type == "Potion")
                {
                    p.HP += 20;
                    text = "Player's HP increased to " + p.HP;
                }
                else
                {
                    p.characterItemBonus += sampleItemNames[index].PowerLevel;
                    text = "Player's Item bonus increased to " + p.characterItemBonus;
                }
            }

            battleText.Add(text);
        }
    }
}






