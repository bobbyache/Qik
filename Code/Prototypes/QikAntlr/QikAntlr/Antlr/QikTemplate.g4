grammar QikTemplate;

/* ***********************************************************************
Rules
*********************************************************************** */ 
template		
    //:	(ctrlDecl|exprDecl)+ 
    :	(ctrlDecl|exprDecl)+ 
    ;
	
ctrlDecl
    : optionBox
    | textBox
    | checkBox
    ;

optionBox
    : ID '=' 'options' '[' optionBoxArgs ']' optionsBody ';'
    ;

textBox
    : ID '=' 'text' '[' textBoxArgs ']' ';'
    ; 

checkBox
    : ID '=' 'check' '[' checkBoxArgs ']' ';'
    ;

exprDecl
    : ID '=' 'expression' '{' 'return' (expr|STRING|ifStat) ';'  '}' ';'
    ;

ifStat
    : ifLine (elseIfLine)* (elseLine)*
    ;

ifLine
    : 'if' '(' ID '==' STRING ')' 'return' (expr|STRING) ','
    ;

elseIfLine
    : 'elseif' '(' ID '==' STRING ')' 'return' (expr|STRING) ','
    ;

elseLine
    : 'else' 'return' (expr|STRING)
    ;

checkBoxArgs
    : titleArg  (',' defaultArg)?
    ;

textBoxArgs
    : titleArg  (',' defaultArg)?
    ;

optionBoxArgs
    : titleArg  (',' defaultArg)?
    ;

optionsBody
    : '{' (singleOption ',')* (singleOption ';') '}'
    ;

singleOption
    : CONST ':' 'option' '[' titleArg ']'
    ;

titleArg
    : 'Title' '=' STRING
    ;

defaultArg
    : 'Default' '=' (STRING | CONST)
    ;

valueArg
    : 'Value' '=' (STRING | ID)
    ;

expr
    : (func|STRING) ('+' (func|STRING))*
    ;

func
    : 'lowerCase' '(' (ID|STRING|func) ')'
    | 'upperCase' '(' (ID|STRING|func) ')'
    | 'removeSpaces' '(' (ID|STRING|func) ')'
    ;



/* ***********************************************************************
Tokens and Fragments
*********************************************************************** */ 
/*
CONTROLTYPE
    : 'options'
    | 'text'
    ;
*/
STRING 
	: '"' ('""'|~'"')* '"' 
	;

CONST
    : LETTER (LETTER|DIGIT)*
    ;

ID  
    :   '@' LETTER (LETTER|DIGIT)*
    ;
fragment
LETTER
    : [a-zA-Z\u00FF_]
    ;

fragment
NUMBER
    : '-'? ('.' DIGIT+ | DIGIT+ ('.' DIGIT*)? )
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


