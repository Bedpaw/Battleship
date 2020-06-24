using System.Collections;
using System.Collections.Generic;
using ConsoleApp7.utils;
using NUnit.Framework;
using NSubstitute;
namespace BattleShipGameUnitTests
{
    public class TestUtils
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [TestCase(new [] {8, 0}, "A9")]
        [TestCase(new [] {0, 0}, "A1")]
        [TestCase(new [] {3, 3}, "D4")]
        [TestCase(new [] {9, 9}, "J10")]
        public void ConvertAttackedPositionToXy_A9_A10_J10_J1_Returns08_09_99_90(int [] FieldPosXy, string attackedPosition)
        {
            // THIS IS FAKE TEST, SHOULD BE INVERTED 
            var result = Utils.ConvertAttackedPositionToXy(attackedPosition);
            
            Assert.AreEqual(FieldPosXy, result);
            
        }
        
    }
}