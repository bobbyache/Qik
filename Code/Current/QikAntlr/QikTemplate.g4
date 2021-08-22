grammar QikTemplate;

/* ***********************************************************************
Complete Template
    - Control Placeholders (user input)
    - Derived Input (expression input derived from user input or system)
*********************************************************************** */ 
template		
    :	(inputDecl|funcDecl)+ 
    ;

/* -----------------------------------------------------------------------
Control Declarations
----------------------------------------------------------------------- */ 
inputDecl
    : VARIABLE '=>' STRING ';'
    ;

funcDecl
    : VARIABLE '=>' (expr|concatExpr|iffExpr|switchExpr) ';'
    ;

/* -----------------------------------------------------------------------
Expressions and Functions
----------------------------------------------------------------------- */ 
expr
    : func
    |STRING
    |VARIABLE
    |INT
    |FLOAT
    |CONST
    ;

compExpr
    : expr ('=='|'!=') expr
    ;

concatExpr
    : expr ('+' expr)+
    ;

iffExpr
    : compExpr iffTrueStat iffFalseStat
    ;

iffTrueStat
    : '?' (expr|iffExpr|concatExpr)
    ;

iffFalseStat
    : ':' (expr|iffExpr|concatExpr)
    ;

switchExpr
    : switchStat ((caseStat)+ elseStat)
    ;

switchStat
    : 'switch' expr
    ;

caseStat
    : 'case' STRING ':' (expr|iffExpr|concatExpr)
    ;

elseStat
    : 'else' (expr|iffExpr|concatExpr)
    ;

func
    : IDENTIFIER ('()'|'(' funcArg (',' funcArg)* ')')
    ;
    

funcArg
    : expr | concatExpr
    ;

/* ***********************************************************************
Tokens and Fragments
*********************************************************************** */ 


CONST
    : 'TAB'
    | 'SPACE'
    | 'NEWLINE'
    ;

STRING 
	: '"' ('""'|~'"')* '"' 
	;

IDENTIFIER
    : LETTER (LETTER|DIGIT)*
    ;

VARIABLE  
    :   '@' LETTER (LETTER|DIGIT)*
    ;

FLOAT 
    : INT '.' DIGIT*
    | '.' INT
    ;

INT 
    : DIGIT+
    ;

fragment
LETTER
    : [a-zA-Z\u00FF_]
    ;

fragment
DIGIT
    : [0-9]
    ;

/* ***********************************************************************
Hidden channels (Comments and White Space)
*********************************************************************** */ 

WS  :   [ \r\t\u000C\n]+ -> channel(HIDDEN)
    ;

COMMENT
    :   '/*' .*? '*/'    -> channel(HIDDEN) // match anything between /* and */
    ;
LINE_COMMENT
    : '//' ~[\r\n]* '\r'? '\n' -> channel(HIDDEN)
    ;


