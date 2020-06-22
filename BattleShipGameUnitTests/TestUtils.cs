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
            var attackedPositions = new List<string>
            {
                "A9", "A10", "J10", "J1"
            };
            var exceptedResults = new List<int[]>
            {
                new[] {8, 0}, new[] {9, 0}, new[] {9, 9}, new[] {0, 9}
            };
            
            var results = new List<int []>();
            
            results.AddRange(attackedPositions.Select(Utils.ConvertAttackedPositionToXy));
            
            Assert.AreEqual(exceptedResults, results);
            
        }
        
    }
}