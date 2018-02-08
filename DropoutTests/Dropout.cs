using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobDev.Models;
using MobDev.Controller;
using System.Collections.Generic;

namespace DropoutTests
{
    [TestClass]
    public class Dropout
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
        public void ExperienceShouldBeGreaterThanZero()
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
        public void ExperienceShouldBeLessThanZero()
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

        [TestMethod]
        public void LevelUpMethodShouldIncreaseTheLevelOfPlayer()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(5, 4);
            int beforeUpdate = newPlayer.Level;
            CharacterController p = new CharacterController();
            p.LevelUp(newPlayer);
            Assert.IsTrue(beforeUpdate < newPlayer.Level, "Level up should increase the level");
        }

        [TestMethod]
        public void PlayerShouldBeDeadIfHPIsLessThanZero()
        {
            Player newPlayer = new Player("bae", 23, 0, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            PlayerController p = new PlayerController();
            Assert.IsTrue(p.IsDead(newPlayer), "Player should be dead if HP <= 0");
        }

        [TestMethod]
        public void PlayerShouldNotBeDeadIfHPIsGreaterThanZero()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(4, 4);
            PlayerController p = new PlayerController();
            Assert.IsFalse(p.IsDead(newPlayer), "Player should not be dead if HP > 0");
        }

        [TestMethod]
        public void AddExperianceWillIncreaseExprienceOfPlayer()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            newPlayer.AddExpAndLevel(9, 4);
            int beforeUpdate = newPlayer.Level;
            PlayerController p = new PlayerController();
            p.AddExperience(newPlayer, 2);
            Assert.IsTrue(beforeUpdate < newPlayer.Level, "AddExperiance should increase the Level");
        }

        [TestMethod]
        public void MonsterSpeedShouldBeGreaterThanZero()
        {
            Monster newMonster = new Monster("bae", 23, 7, 34, 3, 3);
            Assert.IsTrue(newMonster.Speed > 0, "Speed should be greater than 0 ");
        }

        [TestMethod]
        public void MonsterHPShouldBeGreaterThanZero()
        {
            Monster newMonster = new Monster("bae", 23, 7, 34, 3, 3);
            Assert.IsTrue(newMonster.HP > 0, "HP should be greater than 0 ");
        }

        [TestMethod]
        public void MonsterStrengthShouldBeGreaterThanZero()
        {
            Monster newMonster = new Monster("bae", 23, 7, 34, 3, 3);
            Assert.IsTrue(newMonster.Strength > 0, "Strength should be greater than 0 ");
        }

        [TestMethod]
        public void MonsterCharacterAttackLevelShouldBeGreaterThanZero()
        {
            Monster newMonster = new Monster("bae", 23, 7, 34, 3, 3);
            Assert.IsTrue(newMonster.characterAttackLevel > 0, "Character Attack Level should be greater than 0 ");
        }

        [TestMethod]
        public void MonsterCharacterItemBonusShouldBeGreaterThanZero()
        {
            Monster newMonster = new Monster("bae", 23, 7, 34, 3, 3);
            Assert.IsTrue(newMonster.characterItemBonus > 0, "Character Item Bonus should be greater than 0 ");
        }

        [TestMethod]
        public void ScaleModifierShouldBeGreaterThanZero()
        {
            Monster newMonster = new Monster("bae", 23, 7, 34, 3, 3);
            newMonster.AddScaleModifierAndType(4, "lizard");
            Assert.IsTrue(newMonster.ScaleModifier > 0, "scalemodifier should be greater than 0");
        }

        [TestMethod]
        public void IfHPOfPlayerAndMonsterIsGreaterThanZeroFightShouldHappen()
        {
            Player newPlayer = new Player("bae", 23, 7, 34, 3, 3);
            Monster newMonster = new Monster("bae", 23, 6, 34, 3, 3);
            Assert.IsTrue((newPlayer.HP > 0) && (newMonster.HP > 0), "If HP Of Player And Monster Is Greater Than Zero Fight Should Happen");
        }

        [TestMethod]
        public void IfHPOfPlayerOrMonsterIsLessThanZeroFightShouldNotHappen()
        {
            Player newPlayer = new Player("bae", 23, 0, 34, 3, 3);
            Monster newMonster = new Monster("bae", 23, 0, 34, 3, 3);
            Assert.IsFalse((newPlayer.HP < 0 || newMonster.HP < 0), "If HP Of Player Or Monster Is Less Than Zero Fight Should Not Happen");
        }

        [TestMethod]
        public void AddMonsterWithoutAnyMonsterShouldBeEmpty()
        {
            List<Monster> monstersList = new List<Monster>();
            Assert.AreEqual(monstersList.Count, 0, "AddMonster Without Any Monster Should Be Empty");
        }

        [TestMethod]
        public void AddMonsterWithMonsterShouldNotBeEmpty()
        {
            Monster newMonster = new Monster("bae", 23, 6, 34, 3, 3);
            List<Monster> monstersList = new List<Monster>();
            MonsterController b = new MonsterController();
            monstersList = b.AddMonster(newMonster);
            monstersList = b.AddMonster(newMonster);
            Assert.IsTrue(monstersList.Count > 0, "AddMonster With Monster Should Not Be Empty");
        }

        [TestMethod]
        public void AddMonsterShouldFailIfNullIsAdded()
        {
            List<Monster> monstersList = new List<Monster>();
            MonsterController m = new MonsterController();
            monstersList = m.AddMonster(null);
            Assert.IsFalse(monstersList.Count > 0, "Add Monster Should Fail If Null Is Added");
        }
    }
}
