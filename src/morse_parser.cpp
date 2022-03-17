#include "morse_parser.h"
#include <iostream>

MorseParser::MorseParser() {
}
MorseParser::MorseParser(std::string morse_text) {
	set_morse_text(morse_text);
}

/**
 * @brief  Sets morse_text
 * @param  morse_text
 * @retval None
 */
void MorseParser::set_morse_text(std::string morse_text) {
	this->morse_text = morse_text;
}

/**
 * @brief  Splits the morse_text string into tokens based on the morse code break symbol (||)
 * @note   
 * @retval None
 */
void MorseParser::lex() {
	std::vector<std::string> tokens;
	std::string token;

	// Iterates through the morse_text string until we can no longer find any break (||) symbols in which case morse_text.find will return npos.
	int position = morse_text.find("||");
	while (position != std::string::npos) {
		// Find and push the morse code token onto the tokens vector
		token = morse_text.substr(0, position);
		tokens.push_back(token);
		// We add 2 to position because of the length of the break symbol
		morse_text.erase(0, position + 2);

		position = morse_text.find("||");
	}
	// At this point the only part of the string that is left is the last token so we push it to the stack
	tokens.push_back(morse_text);

	this->tokens = tokens;
}

/**
 * @brief  Translates morse code 
 * @note   MorseParser::lex() must be called before to ensure that tokens are generated for the parser to parse
 * @retval Translated morse code as string
 */
std::string MorseParser::parse() {
	std::string translated;

	for (int i = 0; i < tokens.size(); i++) {
		if (MORSEMAP.count(tokens[i]) > 0) {
			// Second option of the iterator is the character we need
			translated += MORSEMAP.find(tokens[i])->second;
	 	} else if (tokens[i] == "") {
			 // The token is "" when there are two breaks in a row. This denotes a space
			translated += " ";
		} else {
			std::cout << "Problem parsing morse code. Try checking the input file for invalid morse." << std::endl;
		}
	}
	return translated;
}