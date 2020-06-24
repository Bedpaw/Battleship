using System.Collections.Generic;
using System.Linq;
using ConsoleApp7.utils;
using NUnit.Framework;

namespace BattleShipGameUnitTests
{
    public class TestUtils
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsConvertAttackedPositionToXyReturnsValidArray()
        {
            // THIS IS FAKE TEST, SHOULD BE INVERTED 
            var exceptedResults = new List<int[]>
            {
                new[] {8, 0}, new[] {9, 0}, new[] {9, 9}, new[] {0, 9}
            };
            var attackedPositions = new List<string>
            {
                "A9", "A10", "J10", "J1"
            };
            
            var result = new List<int []>();
            
            result.AddRange(attackedPositions.Select(Utils.ConvertAttackedPositionToXy));
            
            Assert.AreEqual(exceptedResults, result);
            
        }
        
    }
}