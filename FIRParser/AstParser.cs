﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIRParser.Ast;

namespace FIRParser
{
    public static class AstParser
    {
        public static Ast.OpCodeAst Parse(string str)
        {
            return new Ast.OpCodeAst("output",new ValueAst[] { new ConstantIntValueAst(111) });
        }
    }
}
