using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobDev.Models;

namespace PlayerTests
{
    [TestClass]
    public class PlayerTestsLessThanZero
    {
        [TestMethod]
        public void SpeedShouldBeLessThanZero()
        {
            Player newPlayer = new Player("bae", -23, -7, -34, -3, -3);
            newPlayer.AddExpAndLevel(-4, -4);
            Assert.IsTrue(newPlayer.Speed < 0, "Speed should be Less than 0");
        }

        [TestMethod]
        public void HPShouldBeLessThanZero()
        {
            Player newPlayer = new Player("bae", -23, -7, -34, -3, -3);
            newPlayer.AddExpAndLevel(-4, -4);
            Assert.IsTrue(newPlayer.HP < 0, "HP should be Less than 0");
        }

        [TestMethod]
        public void StrengthShouldBeLessThanZero()
        {
            Player newPlayer = new Player("bae", -23, -7, -34, -3, -3);
            newPlayer.AddExpAndLevel(-4, -4);
            Assert.IsTrue(newPlayer.Strength < 0, "Strength should be Less than 0");
        }
       
        [TestMethod]
        public void CharacterAttackLevelShouldBeLessThanZero()
        {
            Player newPlayer = new Player("bae", -23, -7, -34, -3, -3);
            newPlayer.AddExpAndLevel(-4, -4);
            Assert.IsTrue(newPlayer.characterAttackLevel < 0, "Character Attack Level should be Less than 0");
        }

        [TestMethod]
        public void CharacterItemBonusShouldBeLessThanZero()
        {
            Player newPlayer = new Player("bae", -23, -7, -34, -3, -3);
            newPlayer.AddExpAndLevel(-4, -4);
            Assert.IsTrue(newPlayer.characterItemBonus < 0, "Character Item Bonus should be Less than 0");
        }

        [TestMethod]
        public void ExpShouldBeLessThanZero()
        {
            Player newPlayer = new Player("bae", -23, -7, -34, -3, -3);
            newPlayer.AddExpAndLevel(-4, -4);
            Assert.IsTrue(newPlayer.Exp < 0, "Exp should be Less than 0");
        }

        [TestMethod]
        public void LevelShouldBeLessThanZero()
        {
            Player newPlayer = new Player("bae", -23, -7, -34, -3, -3);
            newPlayer.AddExpAndLevel(-4, -4);
            Assert.IsTrue(newPlayer.Level < 0, "Level should be Less than 0");
        }
    }
}
