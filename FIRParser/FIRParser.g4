grammar FIRParser;


//�v���O�����{�f�B
programBody
	:(statement '\r\n')* statement
	;

//�X�e�[�g�����g
statement
	:variableDef|assignment|labelDef|order
	;

//�ϐ��錾
variableDef
	:type Space Id
	;

//���
assignment
	: variable '=' (value|order)
	;

//���x���錾
labelDef
	: 'label' Space Id
	;

//����
order
	:threeArgOrder|twoArgOrder|oneArgOrder|zeroArgOrder
	;

//�^
type
	:typeModifier* primitiveType starModifier* arrayModifier*
	;

//�v���~�e�B�u�^
primitiveType
	:'int'|'double'|'char'|'bool'|'pointer'
	;

//�z��C���q
arrayModifier
	:'[' IntNum? ']'
	;

//�^�C���q
typeModifier
	:'const'|'static'
	;

//�|�C���^�C���q
starModifier
	:'*'
	;

//�l
value
	:literal|variable|label
	;

//�ϐ���
variable
	:'%' Id
	;

//���x����
label
	:'@'Id
	;

//���ʎq
Id
	:([a-z] |[A-Z]|'_') ([a-z]|[A-Z]|'_'|[0-9])*
	;

//���e�����l
literal
	: IntNum| CharLiteral|StringLiteral|sizeof
	;

//�X�y�[�X
Space
	:' '
	;

/*����*/
IntNum
	:[0-9]+
	;

//����
CharLiteral
	:'\'' . '\''
	;

//������
StringLiteral
	: '"' .* '"'
	;

//sizeof
sizeof
	: 'sizeof<' '>'
	;

//0��������
zeroArgOrder
	:'input'
	;

//1��������
oneArgOrder
	:
		(
			'not'|'cast_int'|'cast_double'|
			'cast_char'|'cast_bool'|
			'ref'|'dref'|'jump'|'output'
		)Space value
	;

//2��������
twoArgOrder
	:
		(
			'add'| 'sub'| 'mul'|'div'|
			'equal'| 'and'|'or'|
			'xor'|'shiftr'|'shiftl'|
			'mod'|'ref_move'
		)Space value Space value
	;

//3��������
threeArgOrder
	:'if_jump' Space value Space value Space value
	;

//�X�L�b�v
WS
	:	' ' -> channel(HIDDEN)
	;
