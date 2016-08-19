/*
 * morseToLatin function is left out from the react component,
 * as it is not specific to that component.
 */

function morseToLatin(input) {
	var output = "";
	input..replace(/(\r\n|\n|\r)/gm,"");
	var letters = input.split(token);
	for (var i in letters) {
		if (letterMapping[letters[i]] == undefined) {
			console.error("Bad input: " + letters[i] + " is not valid morse code.");
			return undefined;
		}
		output += letterMapping[letters[i]];
	}
	return output;
}

var token = "||";

var letterMapping = {
	".-": "a",
	"-...": "b",
	"-.-.": "c",
	"-..": "d",
	".": "e",
	"..-.": "f",
	"--.": "g",
	"....": "h",
	"..": "i",
	".---": "j",
	"-.-": "k",
	".-..": "l",
	"--": "m",
	"-.": "n",
	"---": "o",
	".--.": "p",
	"--.-": "q",
	".-.": "r",
	"...": "s",
	"-": "t",
	"..-": "u",
	"...-": "v",
	".--": "w",
	"-..-": "x", 
	"-.--": "y",
	"--..": "z",
  "" : " "
};