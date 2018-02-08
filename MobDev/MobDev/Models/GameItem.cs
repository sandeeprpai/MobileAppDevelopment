using SQLite;
using System.Collections.Generic;

namespace MobDev.Models
{
    public class GameItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int PowerLevel { get; set; }

        public GameItem()
        {

        }

        public GameItem(string Name, string Type, int PowerLevel)
        {
            this.Name = Name;
            this.Type = Type;
            this.PowerLevel = PowerLevel;
        }
    }

    public class ItemsFromAPI
    {

        public int randomItemOption { get; set; }
        public int superItemOption { get; set; }
        public ItemsFromAPI(int Random, int Super)
        {
            this.randomItemOption = Random;
            this.superItemOption = Super;
        }

        public ItemsFromAPI() { }
    }

    public class ItemsData
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Description { get; set; }
        public int Tier { get; set; }
        public string BodyPart { get; set; }
        public string AttribMod { get; set; }
        public string Creator { get; set; }
        public string Image { get; set; }
        public int Usage { get; set; }
        public string Name { get; set; }

        public ItemsData(string name, string description, int tier, string bodypart, string attribmod, string creator, string image, int usage)
        {
            this.Name = name;
            this.Description = description;
            this.Tier = tier;
            this.BodyPart = bodypart;
            this.AttribMod = attribmod;
            this.Creator = creator;
            this.Image = image;
            this.Usage = usage;
        }

        public ItemsData()
        {

        }
    }

    public class ItemJson
    {
        public int error_code { get; set; }
        public string msg { get; set; }
        public List<ItemsData> data { get; set; }

        public ItemJson(int error_code, string msg, List<ItemsData> data)
        {
            this.error_code = error_code;
            this.msg = msg;
            this.data = data;

        }

        public ItemJson()
        {

        }

    }
}
