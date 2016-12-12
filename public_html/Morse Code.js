/* 
 * Ian Waldschmidt: ian.waldschmidt12@gmail.com
 * Program used to translate a file written in morse code into English text
 * Input must be in "public_html" directory and must have following properties:
 *   -Characters in morse are represented by dots (.) and dashes (-)
 *   -Characters are separated by a vertical bar (|)
 *   -Words are separated by two vertical bars (||)
 *   -Only characters valid are English characters A-Z
 * Displays the output to the file "index.html" (also inside "public_html"
 * directory)
 */

/**CHANGE LOG
 * 2/11: Started project. Refreshed myself on Javascript and determined the best
 *       way to break down and attack the problem. I broke the task into 3 parts:
 *       1) Read the input file and break it into usable parts
 *       2) Convert a single character from morse to English
 *       3) String together characters into words and sentences
 * 2/12: Numbers (2) and (3) have been created and tested. However, I encountered
 *       new problems along the way. The new checklist is:
 *       1) Read the input file and break it into usable parts
 *       2) Figure out how to display/return the result of the method
 *       3) Add error checking to handle misuse of code, such as invalid file
 *          names, characters not in morse code, etc.
 * 2/14: (2) and (3) from above are complete and implemented. (1) has been the
 *       subject of much research, and I am down to one error in loading the file.
 *       After this is resolved, the project should be nearly done, with only
 *       minimal debugging and finalization afterwards.
 * 2/16: Project Finished! File is now able to be loaded successfully (it needs
 *       to be in a particular directory) and all other errors were taken care of.
 *       Final cleanup and documentation completed, sent out.
 */


/**
 * An array containing arrays of characters. The arrays are organized such that
 * characters requiring the same number of dots or dashes are grouped together
 * (i.e. e and t are together because they require one character). 
 * This is used to efficiently call a letter based on its code and length
 * Question marks are used as placeholders if no English letter has the given code
 */
var characters = [
    ['e','t'], 
    ['i','a','n','m'], 
    ['s','u','r','w','d','k','g','o'], 
    ['h','v','f','?','l','?','p','j','b','x','c','y','z','q','?','?']
];

/**
 * CHANGE THIS VARIABLE TO THE PATH OF THE INPUT FILE DESIRED
 * String saving the file path of the input file. If this were a part of a larger
 * system, this would likely be specified by another part of the system.
 */
var filePath = "input.txt";

/**
 * Reads the file and saves it into an array of strings to be translated later.
 * THIS METHOD MUST BE OVERRIDDEN IF IT IS TO BE USED AS PART OF A LARGER SYSTEM
 * Currently it retrieves the file from the input tag in "index.html" but in a
 * larger system, it would be retrieved by an earlier part of the system.
 * @returns {String} The file represented as a string. New lines are separated
 *                   by spaces in the string.
 */
function readFile(){
    var request = new XMLHttpRequest();
    request.onreadystatechange = function(){
        if(request.readyState === 4){
            string = request.responseText;
            finish();
        }
    };
    request.open("GET",filePath, true);
    request.send();
}

/**
 * Takes the string from the readFile() method and converts it to morse and
 * displays it to the "index.html" file
 * This method assumes the input string is identical to the content of the input
 * file, ie the characters follow the rules at the top of the document, and each
 * line is separated by the escape sequences \n\r. Therefore, if the readFile()
 * method above is overriden but maintains a similar string structure, this
 * method does not need to be overwritten.
 * @return {String} The string of English derived from the string of morse. Note
 *                  that the newline character used is <br>, not \r\n, so using
 *                  this in a context outside HTML may create unwanted results.
 */
function finish(){
    var tempString = "";
    var result = "";
    for(var i = 0; i < string.length; i++){
        if(string.charAt(i) === '\r'){
            result += (makeSentence(tempString) + "<br>");
            tempString = "";
            i++;  //Since there is a space between lines, we need to increment further to omit it.
        }
        else{
            tempString += string.charAt(i);
        }
    }
    result += makeSentence(tempString);
    document.getElementById("result").innerHTML = result;
    return result;
}

/**
 * Takes a character in morse code and converts it to from binary (assuming '.'
 * is 0 and '-' is 1) to decimal. It then uses the length of the string (to
 * determine the number of morse signals it takes to make the number) and the
 * resulting decimal to pinpoint the character using the "characters" variable
 * @param {string} string The character in morse code
 * @returns {char} The corresponding English character
 * 
 */
function getChar(string){
    var sum = 0;
    for(var i = 0; i < string.length; i++){
        if(string.charAt(i) === '-'){
            sum = sum + Math.pow(2, string.length - i - 1);
        }
    }
    return characters[string.length - 1][sum];
}

/**
 * Uses the getChar() method in iteration to convert whole words and sentences
 * from morse to English
 * @param {String} string The sentence or word in morse code
 * @return {String} The sentence or word in English
 * 
 */
function makeSentence(string){
    var character = "";         //Saves the letters of the morse code string
    var englishText = "";       //The product string that gets pieced together
    
    //Loop through the entire string
    for(var i = 0; i < string.length; i++){
        //Check to see if this is the end of the character
        if(string.charAt(i) === '|'){
            englishText += getChar(character);
            //Checks to see if the next character will be a space
            if(string.charAt(i + 1) === '|'){
                englishText += ' ';
                i++;
            }
            //Reset the substring variable
            character = "";
        }
        else{
            character += string.charAt(i);
        }
    }
    
    return englishText + getChar(character);
}