var should = require('should');
var morse = require('./morse.js');


describe('Morse Code', function(){
    it('should equal dog', function(){
      var codedText = ['-..|---|--.'];
      var dog = morse(codedText);
      console.log(dog);
      dog[0].should.equal('dog');
    });
    it('should tell you when invlaid morse code is included', function(){
      var invalid = morse(['asd']);
      console.log(invalid);
      invalid[0].should.equal('Please input valid morse code');
    });
});
