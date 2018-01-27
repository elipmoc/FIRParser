using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIRParser.Ast
{
    public class OpCodeAst
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
