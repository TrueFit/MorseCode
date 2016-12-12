# A morse code converter for TrueFit application process

# Program Name - morsecode.py
# Written by - Tim Gallo (tim.gallo@gmail.com)
# 10/7/2014, version 1.0.0.0

# The program takes a text file consisting of dots (.) and dashes(-)
# and converts them into letters according to Morse code.

# Morse code to letter dictionary
def morse_to_letter(morse):
	letters = {'.-' : 'a',
			   '.---' : 'b',
			   '-.-.' : 'c',
			   '-..' : 'd',
			   '.' : 'e',
			   '..-.' : 'f',
			   '--.' : 'g',
			   '....' : 'h',
			   '..' : 'i',
			   '.---' : 'j',
			   '-.-' : 'k',
			   '.-..' : 'l',
			   '--' : 'm',
			   '-.' : 'n',
			   '---' : 'o',
			   '.--.' : 'p',
			   '--.-' : 'q',
			   '.-.' : 'r',
			   '...' : 's',
			   '-' : 't',
			   '..-' : 'u',
			   '...-' : 'v',
			   '.--' : 'w',
			   '-..-' : 'x',
			   '-.--' : 'y',
			   '--..' : 'z'}
	try:	
		return letters[morse]
	except:
		return 'X' # In case of missing/erroneous letters 

# Get each line of the file and return as list
def load_lines(filename):
	with open(filename) as f:
		lines=f.readlines()
	return lines

# Accepts filename from user and converts contents to words
def main():
	filename = raw_input("What file do you want to convert from Morse code? ")
	lines = load_lines(filename)
	for line in lines:	
		print morse_to_words(line)

# Parse each line down to the individual morse signals
def morse_to_words(line):
	words=""	
	letter=line.split('|')
	for morse in letter:
		morse=morse.strip()
		if len(morse):
			words+=morse_to_letter(morse)
		else:
			words+=" "
	return words

if __name__ == '__main__':
	main()
