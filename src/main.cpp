#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include "morse_parser.h"

int main(int argc, char *argv[]) {
	// We attempt to open the first argument as a file
	std::ifstream input(argv[1]);

	// Checks if the file was able to open and if not returns with a failure exist status
	if (!input) {
		if (argc == 1) {
			std::cout << "No file provided as input" << std::endl;
			return 1;
		} else {
        	std::cout << "File failed to open" << std::endl;
			return 1;
		}
	}

	std::vector<std::string> result_lines;
	MorseParser parser;

	// Iterates through lines of the input file
	for (std::string line; std::getline(input, line);) {
		parser.set_morse_text(line);
		parser.lex();
		result_lines.push_back(parser.parse());
	}

	// Output translated morse
	for (std::string result : result_lines) {
		std::cout << result << std::endl;
	}
	return 0;
}