Morse Code Solution

Morse Code is a language just like any other spoken, written, or programming language, albeit with a much simpler grammar.  Because of
this similarity, the usual lexical analysis methods can be used to solve the Morse code problem.  There are several approaches that could 
be taken to this.

One approach would be to use a lex generator such as Lex or one of its C# capable equivalents.  This would involve creating a grammar for 
the Morse code language and running the lex generator against this grammar to create the code capable of parsing an input stream of 
Morse code into a list of tokens.  I have been doing some work with compilers and have used CocoR successfully in this role.  These generators
typically create a Recursive Descent or LL parser that are based on Deterministic Finite Automatons. That would work in this case 
but I feel it would be a more appropriate solution when the grammar is more complicated and is likely to change as the parser
can be regenerated from the grammar easily.

Another solution would be create a similar Recursive Descent or LL parser by hand.  Once again, this would work but I felt it was overkill
for this problem as the Morse code grammar is quite simple and the implemention of these parsers can quite complicated.

The approach I ended up taking is implementing a rudimentary finite state machine to tokenize the passed in Morse code into a list of tokens.  
This list of tokens is then evaluated and cross referenced against a lookup dictionary for the English letters which is then rendered to the 
output string.

Jeremy

 