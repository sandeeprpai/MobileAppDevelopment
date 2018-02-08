using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MobDev.Views;

namespace MobDev.Controller
{
    public class CharacterController
    {
        private Random rand;

        public CharacterController()
        {
            rand = new Random();
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
                myPlayer.ExpToLevelUp = (int)(1.5 * myPlayer.ExpToLevelUp);

                myPlayer.Strength += 1;
                myPlayer.HP += 5;
                myPlayer.Speed += 1;
            }
        }

        /// <summary>
        /// Calculates damage based on character's strength attribute
        /// </summary>
        /// <param name="myCharacter"></param>
        /// <returns></returns>
        public virtual int CalculateDamage(Models.Character myCharacter, 
            ObservableCollection<string> battleText, string lastDroppedItemName)
        {
            int maxPotentialDamage = myCharacter.Strength + myCharacter.characterItemBonus;
            int damageMod = CalcDamageModifiers(myCharacter, battleText, lastDroppedItemName);

            if (damageMod == 0)
                return 0;
            else if (damageMod == 1)
                return maxPotentialDamage;
            else if (damageMod == 2)
                return maxPotentialDamage * 2;


            return maxPotentialDamage;

        }

       public virtual int CalcDamageModifiers(Models.Character myCharacter, ObservableCollection<string> battleText, string lastDroppedItemName)
        {
            //generate random number between 1 and 20
            //if number is 1 -> return true
            //else return false
            int randNumber = rand.Next(1, 21);

            if (SettingsPage.isCriticalHitMissOn)
            {
                if (randNumber == 1)
                {
                    battleText.Add("Critical miss!!!");
                    if(SettingsPage.isServerOn)
                    {
                        myCharacter.characterItemBonus = myCharacter.characterItemBonus - 10;
                    }
                    else
                    {
                        myCharacter.characterItemBonus = myCharacter.characterItemBonus - 1;
                    }
                    
                    battleText.Add("Player's item " + lastDroppedItemName + " is destroyed!");
                                        
                    return 0;
                }
                else if (randNumber == 20)
                {
                    battleText.Add("Critical hit!!!");
                    return 2;
                }
                // regular miss
                else if (randNumber == 2)
                    return 0;
                // no damage modification
                else
                {
                    return 1;
                }
                
            }
            return 1;

        }
    

        public virtual bool IsDead(Models.Character myCharacter)
        {
            if (myCharacter.HP <= 0)
                return true;

            return false;
        }

    }
}
