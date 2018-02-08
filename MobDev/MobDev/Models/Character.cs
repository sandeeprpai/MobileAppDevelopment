using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobDev.Models
{
    public class Character
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public Character(string name, int speed, int HP, int Strength, int characterAttacklevel, int characterItemBonus)
        {
            this.ID = 0;
            this.Name = name;
            this.Speed = speed;
            this.HP = HP;
            this.Strength = Strength;
            this.characterAttackLevel = characterAttacklevel;
            this.characterItemBonus = characterItemBonus;
        }

        public Character()
        {
            
        }
        
        public string Name { get; set; }
        public int Speed { get; set; }
        public int HP { get; set; }
        public int Strength { get; set; }
        public int characterAttackLevel { get; set; }
        public int characterItemBonus { get; set; }
        public int defenderItemBonus { get; set; }
    }
}
