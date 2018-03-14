import dictionary from './dictionary';

export default class MorseCode {
    constructor(input) {
        this.input = input;
    }

    translate() {
        var result;

        try {
            const codeLines = this.input.split('\n');
            var lines = [];

            codeLines.forEach((codeLine) => {
                if (codeLine.length > 0) {
                    var words = [];
                    const codeWords = codeLine.split('||||');

                    codeWords.forEach((codeWord) => {
                        var characters = [];
                        const codeCharacters = codeWord.split('||');

                        codeCharacters.forEach((codeChar) => {
                            var character = dictionary[codeChar];

                            if (character) {
                                characters.push(dictionary[codeChar]);
                            } else if (character.length == 0) {
                                characters.push('');
                            } else {
                                throw new Error('No translation found for character "' + character + '"');
                            }
                        });

                        words.push(characters.join(''));
                    });

                    lines.push(words.join(' '));
                }
            });

            result = lines.join('\n');

        } catch (error) {
            throw new Error('Processing error:\n' + error.message);
        }

        return result;
    }
}