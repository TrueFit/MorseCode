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

Building the project
--------------
I decided to write my solution using c++14 and cmake. Building should be as simple as creating a build directory and running 
```shell
cmake ../
make 
```
in it.