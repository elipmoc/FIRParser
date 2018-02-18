grammar FIRParser;


//プログラムボディ
programBody
	:(statement '\r\n')* statement
	;

//ステートメント
statement
	:variableDef|assignment|labelDef|order
	;

//変数宣言
variableDef
	:type Space Id
	;

//代入
assignment
	: variable '=' (value|order)
	;

//ラベル宣言
labelDef
	: 'label' Space Id
	;

//命令
order
	:threeArgOrder|twoArgOrder|oneArgOrder|zeroArgOrder
	;

//型
type
	:typeModifier* primitiveType starModifier* arrayModifier*
	;

//プリミティブ型
primitiveType
	:'int'|'double'|'char'|'bool'|'pointer'
	;

//配列修飾子
arrayModifier
	:'[' IntNum? ']'
	;

//型修飾子
typeModifier
	:'const'|'static'
	;

//ポインタ修飾子
starModifier
	:'*'
	;

//値
value
	:literal|variable|label
	;

//変数名
variable
	:'%' Id
	;

//ラベル名
label
	:'@'Id
	;

//識別子
Id
	:([a-z] |[A-Z]|'_') ([a-z]|[A-Z]|'_'|[0-9])*
	;

//リテラル値
literal
	: IntNum| CharLiteral|StringLiteral|sizeof
	;

//スペース
Space
	:' '
	;

/*整数*/
IntNum
	:[0-9]+
	;

//文字
CharLiteral
	:'\'' . '\''
	;

//文字列
StringLiteral
	: '"' .* '"'
	;

//sizeof
sizeof
	: 'sizeof<' '>'
	;

//0引数命令
zeroArgOrder
	:'input'
	;

//1引数命令
oneArgOrder
	:
		(
			'not'|'cast_int'|'cast_double'|
			'cast_char'|'cast_bool'|
			'ref'|'dref'|'jump'|'output'
		)Space value
	;

//2引数命令
twoArgOrder
	:
		(
			'add'| 'sub'| 'mul'|'div'|
			'equal'| 'and'|'or'|
			'xor'|'shiftr'|'shiftl'|
			'mod'|'ref_move'
		)Space value Space value
	;

//3引数命令
threeArgOrder
	:'if_jump' Space value Space value Space value
	;

//スキップ
WS
	:	' ' -> channel(HIDDEN)
	;
