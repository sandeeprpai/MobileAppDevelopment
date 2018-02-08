using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobDev.Models;

namespace PlayerTests
{
    [TestClass]
    public class PlayerTestsEquals
    {
        [TestMethod]
        public void NameEqualTest()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.AreEqual(newPlayer.Name, "bae", "Name mismatch");
        }

        [TestMethod]
        public void SpeedShouldBeEqualTo()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.AreEqual(newPlayer.Speed, 23, "Speed is not equal");
        }

        [TestMethod]
        public void HPShouldBeEqualTo()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.AreEqual(newPlayer.HP, 7, "HP is not equal");
        }

        [TestMethod]
        public void StrengthShouldBeEqualTo()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.AreEqual(newPlayer.Strength, 34, "Strength is not equal");
        }
        
        [TestMethod]
        public void CharacterAttackLevelShouldBeEqualTo()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.AreEqual(newPlayer.characterAttackLevel, 3, "Character Attack Level is not equal");
        }

        [TestMethod]
        public void CharacterItemBonusShouldBeEqualTo()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.AreEqual(3, newPlayer.characterItemBonus, "Character Item Bonus is not equal");
        }

        [TestMethod]
        public void ExpShouldBeEqualTo()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.AreEqual(newPlayer.Exp, 4, "Exp is not equal");
        }

        [TestMethod]
        public void LevelShouldBeEqualTo()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            Assert.AreEqual(newPlayer.Level, 4, "Level is not equal");
        }
    }
}
