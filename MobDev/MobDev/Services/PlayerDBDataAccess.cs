using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MobDev.Models;
using Xamarin.Forms;

namespace MobDev.Services
{
    class PlayerDBDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Player> Players { get; set; }

        public PlayerDBDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().
                DbConnection();
            database.CreateTable<Player>();
            this.Players = new ObservableCollection<Player>(database.Table<Player>());

            if (!database.Table<Player>().Any())
            {
                AddNewPlayer();
            }
        }

        public int DeletePlayer(Player p)
        {
            var id = p.ID;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Player>(id);
                }
            }
            this.Players.Remove(p);
            return id;
        }

        public void AddNewPlayer(Player p)
        {
            this.Players.Add(new Player
            {
                Name = p.Name,
                Speed = p.Speed,
                HP = p.HP,
                Strength = p.Strength,
                characterAttackLevel = p.characterAttackLevel,
                characterItemBonus = p.characterItemBonus,
            });
        }

        public void AddNewPlayer()
        {
            this.Players.Add(new Player
            {
                Name = "Lisa",
                Description = "A trained markswoman that can only " +
                              "hit her targets with her eyes closed",
                Image = "character1MobileDev.png",
                Speed = 1,
                HP = 100,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
                Level = 1,
                Exp = 1,
                ExpToLevelUp = 5,
                Score = 0,

            });
            this.Players.Add(new Player
            {
                Name = "Tom",
                Description = "Gave up his scholarship to Yale to open " +
                              "up a boba shop, but failed and ended up bankrupt " +
                              "and living in his parents' basement",
                Image = "character2MobileDev.png",
                Speed = 1,
                HP = 100,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
                Level = 1,
                Exp = 1,
                ExpToLevelUp = 5,
                Score = 0,
            });
            this.Players.Add(new Player
            {
                Name = "Sally",
                Description = "She shops at Gap",
                Image = "character3MobileDev.png",
                Speed = 1,
                HP = 100,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
                Level = 1,
                Exp = 1,
                ExpToLevelUp = 5,
                Score = 0,
            });
            this.Players.Add(new Player
            {
                Name = "Harry",
                Description = "A strapping young lad who's " +
                              "never stepped foot outside his house",
                Image = "character4MobileDev.png",
                Speed = 1,
                HP = 100,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
                Level = 1,
                Exp = 1,
                ExpToLevelUp = 5,
                Score = 0,
            });
            this.Players.Add(new Player
            {
                Name = "Elizabeth",
                Description = "World's largest stuffed cat collection",
                Image = "character5MobileDev.jpg",
                Speed = 1,
                HP = 100,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
                Level = 1,
                Exp = 1,
                ExpToLevelUp = 5,
                Score = 0,
            });
            this.Players.Add(new Player
            {
                Name = "Michael",
                Description = "Likes toast",
                Image = "character6MobileDev.png",
                Speed = 1,
                HP = 100,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
                Level = 1,
                Exp = 1,
                ExpToLevelUp = 5,
                Score = 0,
            });
            this.Players.Add(new Player
            {
                Name = "Stephanie",
                Description = "High profile litigation attorney who " +
                              "hides a cocaine addition from her family",
                Image = "character7MobileDev.png",
                Speed = 1,
                HP = 100,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
                Level = 1,
                Exp = 1,
                ExpToLevelUp = 5,
                Score = 0,
            });
            this.Players.Add(new Player
            {
                Name = "Richard",
                Description = "His K/D ratio is through the roof",
                Image = "character8MobileDev.jpg",
                Speed = 1,
                HP = 100,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
                Level = 1,
                Exp = 1,
                ExpToLevelUp = 5,
                Score = 0,
            });
            this.Players.Add(new Player
            {
                Name = "Nicole",
                Description = "Genious scientist but has big beakers, " +
                              "so she's never taken seriously by her cohorts",
                Image = "character9MobileDev.png",
                Speed = 1,
                HP = 100,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
                Level = 1,
                Exp = 1,
                ExpToLevelUp = 5,
                Score = 0,
            });
            this.Players.Add(new Player
            {
                Name = "William",
                Description = "Had a short-lived career as a singer " +
                              "and now works for the LA Sheriff's office",
                Image = "character10MobileDev.png",
                Speed = 1,
                HP = 100,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
                Level = 1,
                Exp = 1,
                ExpToLevelUp = 5,
                Score = 0,
            });
        }

        public void DeleteAllPlayers()
        {
            lock (collisionLock)
            {
                database.DropTable<Player>();
                database.CreateTable<Player>();
            }
            this.Players = null;
            this.Players = new ObservableCollection<Player>
                (database.Table<Player>());
        }

        public IEnumerable<Player> GetAllPlayer()
        {
            lock (collisionLock)
            {
                return database.Query<Player>("SELECT * FROM Players ").
                    AsEnumerable();
            }
        }

        public Player GetPlayer(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Player>().
                    FirstOrDefault(Player
                        => Player.ID == id);
            }
        }

        public int SaveOrUpdatePlayer(Player p)
        {
            lock (collisionLock)
            {
                if (p.ID != 0)
                {
                    database.Update(p);
                    return p.ID;
                }
                else
                {
                    database.Insert(p);
                    return p.ID;
                }
            }
        }

        public void SaveAllPlayers()
        {
            lock (collisionLock)
            {
                foreach (var p in this.Players)
                {
                    if (p.ID != 0)
                    {
                        database.Update(p);
                    }
                    else
                    {
                        database.Insert(p);
                    }
                }
            }
        }
    }
}
