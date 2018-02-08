using System;
using System.Collections.Generic;
using System.Text;

namespace MobDev.Models
{
    public class Player : Character
    {
        private Character newCharacter { get; set; }

        public int Exp { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public int ExpToLevelUp { get; set; }
        public string Image { get; set; }
        public const int BASE_LEVELUP_EXP = 5;


        public Player(string name, int speed, int HP, int Strength, int characterAttacklevel, int characterItemBonus)
            : base(name, speed, HP, Strength, characterAttacklevel, characterItemBonus)
        {
            this.Name = name;
            this.Speed = speed;
            this.HP = HP;
            this.Strength = Strength;
            this.characterAttackLevel = characterAttacklevel;
            this.characterItemBonus = characterItemBonus;

            this.ExpToLevelUp = BASE_LEVELUP_EXP;
            this.Exp = 0;
            this.Level = 1;
            this.Score = 0;
        }

        public Player()
        {
            
        }

        public void AddExpAndLevel(int exp, int level)
        {
            this.Exp = exp;
            this.Level = level;
        }
    }
}
