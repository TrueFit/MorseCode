_ = require('lodash');
fs = require('fs');
var map = require('./morseMap.js');
var results = [];

var translate = function(codedText){
  results = [];
  if (codedText === undefined){
    var codedText = require('./decode.js');
  }
codedText.forEach(function(line){
  var valid = true;
  var translatedLine = [];

  //split into words
  words = line.split('||');
  
  words.forEach(function(word){
    var translatedWord = [];
    //split words into letters
    letters = word.split('|');
    letters.forEach(function(letter){
      //translate morse code for each letter
      if (map.hasOwnProperty(letter)){
        var engLetter = map[letter];
        //add translated letter to word array
        translatedWord.push(engLetter);
      }
      else{
        valid = false;
      }
    });
    
      //join letters together to form word
      translatedWord = translatedWord.join('');
      //add translated word to translated line array
      translatedLine.push(translatedWord);
  });
  if(valid){
    //join words together and add spaces to form line
    translatedLine = translatedLine.join(' ');
    //add line to results
    results.push(translatedLine);
  }
  else{
    results.push('Please input valid morse code');
  }
});

//return results
return results;
};

//run translate and show results
var showTranslate = function(){
  translate();
  results.forEach(function(line){
    console.log(line);
  });
};

//export translate for use in tests and other parts of app
exports = module.exports = translate;

//show results if node morse.js is run
showTranslate();