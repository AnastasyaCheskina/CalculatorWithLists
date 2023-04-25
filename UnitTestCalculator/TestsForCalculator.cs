using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculatorWithLists;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace UnitTestCalculator
{
    [TestClass]
    public class TestsForCalculator
    {
        string expression = "2+2*3";
        [TestMethod]
        public void TestForCheckExpressionResult8_Equal() //6 (все гуд)
        {
            Assert.AreEqual(8, Calculator.getAnswer(expression));
        }
        [TestMethod]
        public void TestForCheckExpressionResult4_NotEqual() //7 (все гуд)
        {
            Assert.AreNotEqual(4, Calculator.getAnswer(expression));
        }
        [TestMethod]
        public void TestForCheckExpressionOnRegularExpression_Matches() //5 (все гуд)
        {
            Regex patternForString = new Regex("[0-9]");
            int? result = Calculator.getAnswer(expression);
            StringAssert.Matches(result.ToString(), patternForString);
        }
        [TestMethod]
        public void TestForCheckExpressionOnRegularExpression_DoesNotMatch() //4 (не гуд, калькулятор лажа)
        {
            Regex patternForString = new Regex("[0-9]");
            int? result = Calculator.getAnswer("2+2-10");
            StringAssert.DoesNotMatch(result.ToString(), patternForString);
        }
        [TestMethod]
        public void TestForCheckExpressionOnResultNotNull_IsNotNull() //13 (все гуд)
        {
            Assert.IsNotNull(Calculator.getAnswer(expression));
        }
        [TestMethod]
        public void TestForCheckExpression_IsInstanceOfType() //10 
        {
            Assert.IsInstanceOfType(Calculator.getAnswer(expression), typeof(int));
        }
        [TestMethod]
        public void TestForCheckExpression_IsNotInstanceOfType() //11
        {
            Assert.IsNotInstanceOfType(Calculator.getAnswer(expression), typeof(string));
        }
        [TestMethod]
        public void TestForCheckExpression_ThrowsException() //16
        {
            Assert.ThrowsException<IndexOutOfRangeException> (() => Calculator.getAnswer("0-2"));
        }
        [TestMethod]
        public void TestForCheckExpression_All() //не совсем то что там нужно было, но 1
        {
            List<string> symbols = new List<string>();
            symbols=Calculator.SymbolFinder(expression,symbols);
            CollectionAssert.AllItemsAreInstancesOfType(symbols, typeof(string));
        }
        [TestMethod]
        public void TestForCheckExpression_Contains() //2
        {
            List<string> symbols = new List<string>();
            symbols = Calculator.SymbolFinder(expression, symbols);
            string someParam = symbols[0];
            StringAssert.Contains(someParam, "+");
        }
        [TestMethod]
        public void TestForCheckExpression_DoesNotContain() //3 (не работает так как нужно)
        {
            List<string> symbols = new List<string>();
            symbols = Calculator.SymbolFinder(expression, symbols);
            string someParam = symbols[0];
            StringAssert.Contains(someParam, "-"); //не нашла does not
        }
        [TestMethod]
        public void TestForCheckExpressionOnResultNotNull_IsNull() //12
        {
            Assert.IsNull(Calculator.getAnswer("0-2"));
        }
    }
}
