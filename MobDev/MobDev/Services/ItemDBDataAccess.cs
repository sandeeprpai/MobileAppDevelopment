using SQLite;
using System.Collections.ObjectModel;
using System.Linq;
using MobDev.Models;
using Xamarin.Forms;
using System.Collections.Generic;

namespace MobDev.Services
{
    class ItemDBDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<GameItem> Items { get; set; }
        public ObservableCollection<ItemsData> ItemsAPI { get; set; }

        public ItemDBDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().
                DbConnection();
            database.CreateTable<GameItem>();
            this.Items = new ObservableCollection<GameItem>(database.Table<GameItem>());

            if (!database.Table<GameItem>().Any())
            {
                AddNewItem();
            }
        }

        public ItemDBDataAccess(bool isAPI)
        {
            if (isAPI)
            {
                database = DependencyService.Get<IDatabaseConnection>().
                    DbConnection();
                database.CreateTable<ItemsData>();
                this.ItemsAPI = new ObservableCollection<ItemsData>(database.Table<ItemsData>());
            }
            else
            {
                database = DependencyService.Get<IDatabaseConnection>().
                DbConnection();
                database.CreateTable<GameItem>();
                this.Items = new ObservableCollection<GameItem>(database.Table<GameItem>());

                if (!database.Table<GameItem>().Any())
                {
                    AddNewItem();
                }
            }

            
        }
        public void AddNewItem(int i)
        {
            this.ItemsAPI.Add(new ItemsData
            {
              Name= "silver arrow",
              Description= "SPEED +8",
              Tier= 8,
              BodyPart= "ATTKARM",
              AttribMod= "SPEED",
              Creator= "tyler",
              Image= "http://assets.suredone.com/1084/media-pics/a8ny0088-iarornu-silver-arrow-tie-clip.jpg",
              Usage= 20
            });
        }

        public void AddNewItem(ItemsData i)
        {
            this.ItemsAPI.Add(new ItemsData
            {
                Image = i.Image,
                Name = i.Name,
                Description = i.Description,
                Tier = i.Tier,
                BodyPart = i.BodyPart,
                AttribMod = i.AttribMod,
                Creator = i.Creator,
                Usage = i.Usage,
            });
        }

        public void AddNewItem(GameItem i)
        {
            this.Items.Add(new GameItem
            {
                Name = i.Name,
                Type = i.Type,
                PowerLevel = i.PowerLevel,
            });
        }

        public void AddNewItem()
        {
            this.Items.Add(new GameItem
            {
                Name = "Sword",
                Type = "Primary Weapon",
                PowerLevel = 3,
            });
            this.Items.Add(new GameItem
            {
                Name = "Knife",
                Type = "Secondary Weapon",
                PowerLevel = 2,
            });
            this.Items.Add(new GameItem
            {
                Name = "Jacket",
                Type = "Extra",
                PowerLevel = 1,
            });
            this.Items.Add(new GameItem
            {
                Name = "Flamming Oil",
                Type = "Addition",
                PowerLevel = 3,
            });
            this.Items.Add(new GameItem
            {
                Name = "Food",
                Type = "Potion",
                PowerLevel = 2,
            });
            this.Items.Add(new GameItem
            {
                Name = "Water Tome",
                Type = "Magic",
                PowerLevel = 5,
            });
        }

        public IEnumerable<GameItem> GetAllItem()
        {
            lock (collisionLock)
            {
                return database.Query<GameItem>("SELECT * FROM Items ").
                    AsEnumerable();
            }
        }

        public GameItem GetItem(int id)
        {
            lock (collisionLock)
            {
                return database.Table<GameItem>().
                    FirstOrDefault(GameItem
                        => GameItem.ID == id);
            }
        }

        public int SaveOrUpdateItem(GameItem i)
        {
            lock (collisionLock)
            {
                if (i.ID != 0)
                {
                    database.Update(i);
                    return i.ID;
                }
                else
                {
                    database.Insert(i);
                    return i.ID;
                }
            }
        }

        public int SaveOrUpdateItemData(ItemsData i)
        {
            lock (collisionLock)
            {
                if (i.id != 0)
                {
                    database.Update(i);
                    return i.id;
                }
                else
                {
                    database.Insert(i);
                    return i.id;
                }
            }
        }

        public void SaveAllItems()
        {
            lock (collisionLock)
            {
                foreach (var i in this.Items)
                {
                    if (i.ID != 0)
                    {
                        database.Update(i);
                    }
                    else
                    {
                        database.Insert(i);
                    }
                }
            }
        }
        
        public int DeleteItem(GameItem i)
        {
            var id = i.ID;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<GameItem>(id);
                }
            }
            this.Items.Remove(i);
            return id;
        }

        public void DeleteAllItems(bool i)
        {
            if (i)
            {
                lock (collisionLock)
                {
                    database.DropTable<ItemsData>();
                    database.CreateTable<ItemsData>();
                }
                this.ItemsAPI = null;
                this.ItemsAPI = new ObservableCollection<ItemsData>
                    (database.Table<ItemsData>());
                
            } else
            {
                lock (collisionLock)
                {
                    database.DropTable<GameItem>();
                    database.CreateTable<GameItem>();
                }
                this.Items = null;
                this.Items = new ObservableCollection<GameItem>
                    (database.Table<GameItem>());
            }
        }
    }
}
