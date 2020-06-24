using System.Collections;
using ConsoleApp7.utils;
using NUnit.Framework;

namespace BattleShipGameUnitTests
{
    public class ValidationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private class ProperLetterSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return 'A';
                yield return 'J';
            }
        }
        private class InvalidLetterSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return 'Z';
                yield return '1';
            }
                
        }
        [TestCaseSource(typeof(ProperLetterSource))]
        public void IsLetterFromAToJ_ForProperLetter_ReturnTrue(char letter)
        {
            var result = Validation.IsLetterFromAToJ(letter);

            Assert.AreEqual( true, result);
        }
        
        [TestCaseSource(typeof(InvalidLetterSource))]
        public void IsLetterFromAToJ_ForInvalidLetter_ReturnFalse(char letter)
        {
            var result = Validation.IsLetterFromAToJ(letter);

            Assert.AreEqual( false, result);
        }
    }
}