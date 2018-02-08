using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobDev.Models;

namespace PlayerTests
{
    [TestClass]
    public class PlayerTestsGreaterThanZero
    {
        [TestMethod]
        public void SpeedShouldBeGreaterThanZero()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.IsTrue(newPlayer.Speed > 0, "Speed should be greater than 0 ");
        }

        [TestMethod]
        public void HPShouldBeGreaterThanZero()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.IsTrue(newPlayer.HP > 0, "HP should be greater than 0 ");
        }

        [TestMethod]
        public void StrengthShouldBeGreaterThanZero()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.IsTrue(newPlayer.Strength > 0, "Strength should be greater than 0 ");
        }
        
        [TestMethod]
        public void CharacterAttackLevelShouldBeGreaterThanZero()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.IsTrue(newPlayer.characterAttackLevel > 0, "Character Attack Level should be greater than 0 ");
        }

        [TestMethod]
        public void CharacterItemBonusShouldBeGreaterThanZero()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.IsTrue(newPlayer.characterItemBonus > 0, "Character Item Bonus should be greater than 0 ");
        }

        [TestMethod]
        public void ExpShouldBeGreaterThanZero()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.IsTrue(newPlayer.Exp > 0, "Exp should be greater than 0 ");
        }

        [TestMethod]
        public void LevelShouldBeGreaterThanZero()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.IsTrue(newPlayer.Level > 0, "Level should be greater than 0 ");
        }
    }
}
