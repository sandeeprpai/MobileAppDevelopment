using System;
using System.Collections.Generic;
using System.Text;

namespace MobDev.Controller
{
    public class PlayerController : CharacterController
    {
        public PlayerController()
        {
            
        }

       public void AddExperience(Models.Player myPlayer, int expEarned)
        {
            myPlayer.Exp += expEarned;

            if (myPlayer.Exp >= myPlayer.ExpToLevelUp)
                LevelUp(myPlayer);
        }

        /// <summary>
        /// checks experience earned and calculates
        /// level ups if there is enough experience
        /// </summary>
        /// <param name="myPlayer"></param>
        public void LevelUp(Models.Player myPlayer)
        {
            while (myPlayer.Exp >= myPlayer.ExpToLevelUp)
            {
                myPlayer.Level++;
                myPlayer.ExpToLevelUp = (int) (1.2 * myPlayer.ExpToLevelUp);
            }
        }

        public Models.Item Takeitem()
        {
            //check to make sure the items stack is not full
            //generate new item
            //if the new item is better than previous, 
            // call giveAway(currentItem) and take the item
            return new Models.Item();
        }

        public bool UseItem(Models.Player myPlayer)
        {
            myPlayer.HP++;

            return true;
        }

        public bool GiveAwayItem()
        {
            //remove from the items list
            return true;
        }
    }
}