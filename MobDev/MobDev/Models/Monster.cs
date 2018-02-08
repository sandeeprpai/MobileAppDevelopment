using System;
using System.Collections.Generic;
using System.Text;

namespace MobDev.Models
{
    public class Monster : Character
    {
        public int ScaleModifier { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }

        public Monster(string name, int speed, int HP, int Strength, int characterAttacklevel, int characterItemBonus)
            : base(name, speed, HP, Strength, characterAttacklevel, characterItemBonus)
        {
            this.Name = name;
            this.Speed = speed;
            this.HP = HP;
            this.Strength = Strength;
            this.characterAttackLevel = characterAttacklevel;
            this.characterItemBonus = characterItemBonus;
        }

        public Monster()
        {
            
        }

        public void AddScaleModifierAndType(int scaleModifier, string type)
        {
            this.Type = type;
            this.ScaleModifier = scaleModifier;
        }


    }
}
