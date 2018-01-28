using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace FIRParser
{
    public class Hello
    {
        public Hello()
        {
            var stream = new AntlrInputStream("1+1");
            var lex=new FIRParserLexer(stream);
            var commonLex = new CommonTokenStream(lex);
            var parse = new FIRParserParser(commonLex);
            Console.WriteLine("hello!2");
        }
    }
}
