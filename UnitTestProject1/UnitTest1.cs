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
$@"int x
%x=5
int temp
%temp=1
bool flag
label loop
%temp=mul %temp %x
%x=sub %x 1
%flag=equal %x 1
if_jump %flag @end @loop
label end
output %temp");
        }

        [TestMethod]
        public void TypeTest()
        {
            TestParser("int hoge");
            TestParser("double hoge");
            TestParser("bool hoge");
            TestParser("char hoge");
            TestParser("pointer hoge");

            TestParser("const int hoge");
            TestParser("static const double hoge");
            TestParser("bool* hoge");
            TestParser("char[] hoge");
            TestParser("pointer** hoge");

            TestParser("const int**[45] hoge");
            TestParser("double[][5][3] hoge");
            TestParser("static const bool*[][] hoge");
            TestParser("char[1][2][3][4] hoge");
            TestParser("static pointer****** hoge");
        }

        [TestMethod]
        public void ErrorTest1()
        {
            try
            {
                TestParser("input 810");
            }
            catch (Exception e)
            {
                return;
            }
            throw new Exception("ここにたどり着くのはおかしい");
        }

        [TestMethod]
        public void SizeofTest()
        {
            TestParser("output sizeof<int>");
            TestParser("output sizeof<bool>");
            TestParser($@"int hoge
%hoge=sizeof<bool>
%hoge=add sizeof<bool> sizeof<int>");
        }

        [TestMethod]
        public void LiteralTest()
        {
            TestParser($@"int hoge
%hoge=""fuga""
%hoge=114514
%hoge=true
%hoge=false
%hoge='c'
%hoge=3.14");
        }

        [TestMethod]
        public void StructTest()
        {
            TestParser($@"{{int:foo,const char*[4545]:var}} Hoge
struct Hoge hoge
output %hoge.foo
%hoge.foo=810");
        }
    }
}
