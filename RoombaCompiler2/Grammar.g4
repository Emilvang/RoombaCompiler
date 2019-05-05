grammar Grammar;
 program
   	: (var_decl | func_stmt)* 'Program' '{' stmts? '}'
   	; 	 
 
 stmts
   	: stmt*
   	;
 
  stmt
   	: var_stmt
	| var_decl
   	| iter_stmt
   	| cond_stmt
   	| func_expr
   	| print
   	;
 
      /* Scopes to check:
     * var decl DONE
     * func expr
     * var expr
     * 
     * 
     * Variables to add to scopes:
     * for DONE
     * parameters DONE
     * func_stmt DONE
     * 
     * Add scopes:
     * Iter stmt DONE
     * if  / else /elseif
     */

 var_decl
	 : (INTDECL | FLOATDECL | BOOLDECL) IDENTIFIER '=' (expr | logic_expr)
	 | (INTDECL | FLOATDECL | BOOLDECL) LISTDECL  IDENTIFIER '=' '[' ((expr | logic_expr) (',' (expr | logic_expr))*)? ']'
	 ;
 
 cond_stmt
    	:  if_stmt elseif_stmt* else_stmt?
    	;

 if_stmt
	 :IF logic_expr '{' stmts? '}'
	 ;

 elseif_stmt
	 : ELSEIF logic_expr '{' stmts? '}'
	 ;

 else_stmt
	 : ELSE '{' stmts? '}'
	 ;

 parameter_decl 
		: (INTDECL | FLOATDECL | BOOLDECL) LISTDECL? IDENTIFIER
		;
 
 func_stmt
    	: (INTDECL | FLOATDECL | BOOLDECL) IDENTIFIER '(' (parameter_decl ( ',' parameter_decl)*)? ')' '{' stmts? return_stmt '}'
		| VOID  IDENTIFIER '(' parameter_decl ( ',' parameter_decl)* ')' '{' stmts? '}'
    	;
 
 func_expr
    	: IDENTIFIER '(' ((expr | logic_expr) (',' (expr | logic_expr))*)? ')'
    	;
 
 iter_stmt
    	: WHILE logic_expr '{' stmts? '}'
		| FOR IDENTIFIER '=' (INT | expr) 'to' (INT | expr) '{' stmts? '}'
    	;
 
 print // for testing purposes
    	: 'print' (expr | logic_expr)
    	;
 
 expr
    	: '(' expr? ')'
		| var_expr
    	| num_expr
		| func_expr
		| logic_expr
    	;
 
 var_expr
    	: IDENTIFIER
    	| IDENTIFIER '[' expr ']'
    	;
 
 num_expr
    	: num_expr op = (MUL | DIV) num_expr
		| num_expr op = (ADD | SUB) num_expr
		| var_expr
		| func_expr
		| INT
    	| FLOAT
		| 
    	;

 //arithmetic_expr
	/*    : '(' arithmetic_expr ')'
		| (var_expr | func_expr | num_expr) op = (MUL | DIV) (var_expr | func_expr | num_expr)
		| (var_expr | func_expr | num_expr) op = (ADD | SUB) (var_expr | func_expr | num_expr)
		;*/
 	
 logic_expr
	: '(' logic_expr ')'
   	| (BOOL | var_expr | func_expr)
	| logic_expr (AND | OR) logic_expr
   	| (var_expr | func_expr | num_expr )  (LT | LTEQ | GT | GTEQ) (var_expr | func_expr | num_expr)
	| (var_expr | func_expr | num_expr)  (EQ | NEQ ) (var_expr | func_expr | num_expr)
   	;

  var_stmt
   	:  IDENTIFIER '=' (expr | logic_expr)
   	|  IDENTIFIER '[' expr ']' '=' (expr | logic_expr)
	|  IDENTIFIER ADDARRAY (expr | logic_expr)
   	;

 return_stmt
   	: 'return' (expr | logic_expr)
   	;
 
compileUnit
   	:  	EOF
   	;
 
/*
 * Lexer Rules
 */

ADDARRAY : 'add';

AND : 'and' | 'AND';
OR : 'or' | 'OR';

LT : '<';
GT : '>';
GTEQ : '>=';
LTEQ : '<=';
NEQ : '!=';
EQ : '==';

INTDECL : 'int';
FLOATDECL : 'float';
BOOLDECL : 'bool';
LISTDECL : '[]';

VOID : 'void';

IF   : 'if' ;
ELSEIF : 'elseif';
ELSE : 'else';
WHILE : 'while' ;
FOR : 'for' ;

fragment DIGIT: ('0' .. '9');
fragment CHARACTER: ('a' .. 'z' | 'A' .. 'Z');
 
 MUL : '*';
 DIV : '/';
 ADD : '+';
 SUB : '-';


BOOL : 'True' | 'False';
IDENTIFIER : CHARACTER+ (CHARACTER | DIGIT)*;
INT : ('-')? DIGIT+;
FLOAT : ('-')? DIGIT+ ('.' DIGIT+)?;
COMMENT : '#' .*? '#' -> skip;
WS
   	:  	(' ' | '\r' | '\t' | '\n' | COMMENT) -> channel(HIDDEN)
   	;
