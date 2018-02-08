using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobDev.Models;
using MobDev.Controller;

namespace TestPlayer
{
    [TestClass]
    public class PlayerTestsMethods
    {
        [TestMethod]
        public void PlayerTestLevelUpShouldIncreaseTheValue()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            int beforeUpdate = newPlayer.Level;
            PlayerController p = new PlayerController();
            p.LevelUp(newPlayer);
            Assert.IsTrue(beforeUpdate < newPlayer.Level, "Level up should increase the level");
        }

        [TestMethod]
        public void PlayerTestIsDead()
        {
            Player newPlayer = new Player("bae", 23, 0, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            PlayerController p = new PlayerController();
            Assert.IsTrue(p.IsDead(newPlayer), "Player should be dead if HP <= 0");
        }

        [TestMethod]
        public void PlayerTestIsNotDead()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            PlayerController p = new PlayerController();
            Assert.IsFalse(p.IsDead(newPlayer), "Player should not be dead if HP > 0");
        }

        [TestMethod]
        public void PlayerTestAddExperiance()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(9, 4);
            int beforeUpdate = newPlayer.Level;
            PlayerController p = new PlayerController();
            p.AddExperiance(newPlayer);
            Assert.IsTrue(beforeUpdate < newPlayer.Level, "AddExperiance should increase the Level");
        }
    }
}
