using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MobDev.Models;
using Xamarin.Forms;

namespace MobDev.Services
{
    class MonsterDBDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Monster> Monsters { get; set; }

        public MonsterDBDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().
                DbConnection();
            database.CreateTable<Monster>();
            this.Monsters = new ObservableCollection<Monster>(database.Table<Monster>());

            if (!database.Table<Monster>().Any())
            {
                AddNewMonster();
            }
        }

        public void AddNewMonster(Monster m)
        {
            this.Monsters.Add(new Monster
            {
                Name = m.Name,
                Speed = m.Speed,
                HP = m.HP,
                Strength = m.Strength,
                characterAttackLevel = m.characterAttackLevel,
                characterItemBonus = m.characterItemBonus,
            });
        }

        // pre-generated list of monsters
        public void AddNewMonster()
        {
            this.Monsters.Add(new Monster
            {
                Name = "Ifrit",
                Image = "ifritMobileDev.png",
                Speed = 1,
                HP = 40,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,

            });
            this.Monsters.Add(new Monster
            {
                Name = "Titan",
                Image = "titanMobileDev.png",
                Speed = 1,
                HP = 40,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
            });
            this.Monsters.Add(new Monster
            {
                Name = "Garuda",
                Image = "garudaMobileDev.png",
                Speed = 1,
                HP = 40,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
            });
            this.Monsters.Add(new Monster
            {
                Name = "Leviathan",
                Image = "leviathanMobileDev.jpg",
                Speed = 1,
                HP = 40,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
            });
            this.Monsters.Add(new Monster
            {
                Name = "Ramuh",
                Image = "ramuhMobileDev.png",
                Speed = 1,
                HP = 40,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
            });
            this.Monsters.Add(new Monster
            {
                Name = "Bismark",
                Image = "bismarkMobileDev.png",
                Speed = 1,
                HP = 40,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
            });
            this.Monsters.Add(new Monster
            {
                Name = "Thordan",
                Image = "ThordanMobileDev.png",
                Speed = 1,
                HP = 40,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
            });
            this.Monsters.Add(new Monster
            {
                Name = "Sophia",
                Image = "sophiaMobileDev.png",
                Speed = 1,
                HP = 40,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
            });
            this.Monsters.Add(new Monster
            {
                Name = "Ultima",
                Image = "ultimaMobileDev.png",
                Speed = 1,
                HP = 40,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
            });
            this.Monsters.Add(new Monster
            {
                Name = "Odin",
                Image = "OdinMobileDev.png",
                Speed = 1,
                HP = 40,
                Strength = 20,
                characterAttackLevel = 20,
                characterItemBonus = 0,
            });
        }

        public IEnumerable<Monster> GetAllMonster()
        {
            lock (collisionLock)
            {
                return database.Query<Monster>("SELECT * FROM Monsters ").
                    AsEnumerable();
            }
        }

        public Monster GetMonster(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Monster>().
                    FirstOrDefault(Monster
                        => Monster.ID == id);
            }
        }

        public int SaveOrUpdateMonster(Monster m)
        {
            lock (collisionLock)
            {
                if (m.ID != 0)
                {
                    database.Update(m);
                    return m.ID;
                }
                else
                {
                    database.Insert(m);
                    return m.ID;
                }
            }
        }

        public void SaveAllMonsters()
        {
            lock (collisionLock)
            {
                foreach (var m in this.Monsters)
                {
                    if (m.ID != 0)
                    {
                        database.Update(m);
                    }
                    else
                    {
                        database.Insert(m);
                    }
                }
            }
        }


        public int DeleteMonster(Monster m)
        {
            var id = m.ID;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Monster>(id);
                }
            }
            this.Monsters.Remove(m);
            return id;
        }

        public void DeleteAllMonsters()
        {
            lock (collisionLock)
            {
                database.DropTable<Monster>();
                database.CreateTable<Monster>();
            }
            this.Monsters = null;
            this.Monsters = new ObservableCollection<Monster>
                (database.Table<Monster>());
        }
    }
}
