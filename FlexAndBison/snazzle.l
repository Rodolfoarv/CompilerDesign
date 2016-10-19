%{
  #include <iostream>
  using namespace std;
  #define YY_DECL extern "C" int yylex()
  int lines = 0;
%}

%%
[ \t]         ;
[0-9]+\.[0-9]+  { cout << "Found a floating point number: " << yytext << endl;}
[0-9]+          { cout << "Found an integer: " << yytext << endl; }
[a-zA-Z0-9]+    { cout << "Found a string: " << yytext << endl; }
\n              { lines++; }  // increment line count, but don't return a token
.               { cout << "This is a not found token: " << yytext << endl; }
%%
int main(int, char**) {
	// lex through the input:
	yylex();
}
