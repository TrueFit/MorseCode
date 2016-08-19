Morse Code
==========

The Problem
-----------
Morse code is a way to encode messages in a series of long and short sounds or visual signals. During transmission, operators use pauses to split letters and words.

Please write a program which will translate lines of Morse code into readable English text. The program should:

1. Accept a flat file as input.
2. Each new line will contain a string of Morse code. The characters used will be:
	1.	. = dot
	2.	\- = dash
	3.	|| = break
3. Output the English text for each line

Sample Input
------------
-..||---||--.

….||.||.-..||.-..||---||||.--||---||.-.||.-..||-..

Sample Output
-------------
dog

hello world

The Fine Print
--------------
Please use whatever technology and techniques you feel are applicable to solve the problem. We suggest that you approach this exercise as if this code was part of a larger system. The end result should be representative of your abilities and style.

Please fork this repository. When you have completed your solution, please issue a pull request to notify us that you are ready.

Have fun.

Implementation Writeup
----------------------
Most of the time working on this was spent learning how react.js works, as well as trying to debug it without an IDE. I ended up using JSBin and JSFiddle to do my initial coding, then switched to running and tweaking it using github pages, which is why I have so many commits.

React.js enables easy integration with a larger system, but on top of that, I left the morseToLatin() function in its own file. It can be used for any morse string to human readable string conversion, not just from files, and so it makes sense to have it accessible outside of the React component.

