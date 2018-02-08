using MobDev.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace MobDev.Controller
{
    public class MonsterController : CharacterController
    {
        public MonsterController()
        {

        }

        public Models.Item DropItem()
        {
            //at the end of the battle a monster
            // will drop an item for the player
            // to pick up

            return new Models.Item();
        }

        public List<Monster> AddMonster(Monster monster)
        {
            List<Monster> monsterList = new List<Models.Monster>();
            if (monster != null)
            {
                monsterList.Add(monster);
            }
            return monsterList;
        }
    }
}
