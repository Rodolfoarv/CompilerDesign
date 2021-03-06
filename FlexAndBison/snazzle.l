%{
  #include <cstdio>
  #include <iostream>
  #include "snazzle.tab.h"
  using namespace std;
  #define YY_DECL extern "C" int yylex()


%}
%%
[ \t\n]         ;
sNaZZle         { return SNAZZLE; }
type            { return TYPE ; }
end             { return END; }
[0-9]+\.[0-9]+  { yylval.fval = atof(yytext); return FLOAT; }
[0-9]+          { yylval.ival = atof(yytext); return INT; }
[a-zA-Z0-9]+    { yylval.sval = strdup(yytext); return STRING; }
.               ;
%%
