using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIRParser;
using FIRParser.Ast;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            OpCodeAst hoge=AstParser.Parse("output 111");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(new OpCodeAst("output", new ConstantIntValueAst(111)), AstParser.Parse("output 111"));
        }
    }
}
