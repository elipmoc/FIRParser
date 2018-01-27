using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIRParser;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Parser.Parse("output 111");
        }
    }
}
