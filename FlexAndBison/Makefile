snazzle:	snazzle.l snazzle.y
	bison -d snazzle.y
	flex snazzle.l
	g++ snazzle.tab.c lex.yy.c -lfl -o snazzle

clean:
	rm snazzle snazzle.tab.c snazzle.tab.h lex.yy.c
