grammar FIRParser;

/*
 * Parser Rules
 */

compileUnit
	:	'hoge'
	;

/*
 * Lexer Rules
 */

WS
	:	' ' -> channel(HIDDEN)
	;
