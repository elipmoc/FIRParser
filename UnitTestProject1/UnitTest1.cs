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

        [TestMethod]
        public void TestMethod2()
        {
            TestParser(
                $@"
                int x
                %x=5
                int temp
                %temp=1
                bool flag
                label loop
                % temp = mul % temp % x
                % x = sub % x 1
                % flag = equal % x 1
                if_jump % flag @end @loop
                @end
                output temp");
        }
    }
}
