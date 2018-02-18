using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIRParser;
using FIRParser.Ast;
using Antlr4.Runtime;
namespace UnitTestProject1
{

    class errorListener<T> : IAntlrErrorListener<T>
    {
        public void SyntaxError(IRecognizer recognizer, T offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            throw new Exception("Line:" + line + " Pos:" + charPositionInLine + " Msg:" + msg);
        }
    }


    [TestClass]
    public class UnitTest1
    {
        private void TestParser(string str)
        {
            var inputStream = new AntlrInputStream(str);
            var lexer = new FIRParserLexer(inputStream);
            lexer.AddErrorListener(new errorListener<int>());
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new FIRParserParser(commonTokenStream);
            parser.AddErrorListener(new errorListener<IToken>());
            var graphContext = parser.programBody();
        } 

        [TestMethod]
        public void TestMethod1()
        {
            TestParser("input");
        }
    }
}
