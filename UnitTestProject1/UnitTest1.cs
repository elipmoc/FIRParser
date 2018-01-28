﻿using System;
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
            ParseResult hoge=AstParser.Parse("output 111");
        }

        [TestMethod]
        public void TestMethod2()
        {
            new OpCodeAst("output",new ValueAst[]{ new ConstantIntValueAst(111)});
        }
    }
}
