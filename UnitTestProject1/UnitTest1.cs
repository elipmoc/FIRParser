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
            Ast.OpCodeAst hoge=Parser.Parse("output 111");
        }
    }
}
