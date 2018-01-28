using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIRParser.Ast
{

    public interface BaseAst
    {

    }

    //一行を意味する抽象構文木
    public interface OneLineAst
    {

    }

    public class OpCodeAst:OneLineAst
    {
        public OpCodeAst(string opName,ValueAst[] valueAstArray)
        {

        }
    }

    public interface ValueAst
    {

    }

    public class ConstantIntValueAst: ValueAst
    {
        public ConstantIntValueAst(int value)
        {

        }
    }
}
