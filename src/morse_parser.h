#pragma once
#include <vector>
#include <string>
#include <map>

class MorseParser {
public:
	MorseParser();
	MorseParser(std::string morse_text);

	void lex();
	void set_morse_text(std::string morse_text);
	std::string parse();

private:
	std::vector<std::string> tokens;
	std::string morse_text;

	const std::map<std::string, char> MORSEMAP = {
		{ ".-",    'a', },
		{ "-...",  'b', },
		{ "-.-.",  'c', },
		{ "-..",   'd', },
		{ ".",     'e', },
		{ "..-.",  'f', },
		{ "--.",   'g', },
		{ "....",  'h', },
		{ "..",    'i', },
		{ ".---",  'j', },
		{ "-.-",   'k', },
		{ ".-..",  'l', },
		{ "--",    'm', },
		{ "-.",    'n', },
		{ "---",   'o', },
		{ ".--.",  'p', },
		{ "--.-",  'q', },
		{ ".-.",   'r', },
		{ "...",   's', },
		{ "-",     't', },
		{ "..--",  'u', },
		{ "...-",  'v', },
		{ ".--",   'w', },
		{ "-..-",  'x', },
		{ "-.--",  'y', },
		{ "--..",  'z', },

		{ "-----",  '0', },
		{ ".----",  '1', },
		{ "..---",  '2', },
		{ "...--",  '3', },
		{ "....-",  '4', },
		{ ".....",  '5', },
		{ "----.",  '6', },
		{ "---..",  '7', },
		{ "--...",  '8', },
		{ "-....",  '9', },
	};
};