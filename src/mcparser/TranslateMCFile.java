package mcparser;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.util.Scanner;

/**
 * TranslateMCFile
 * 
 * <P> takes an argument for a file name that has Morse code on each line
 * and translates it into characters that are printed to the console.
 * 
 * @author Asher Bernardi asherbernardi@gmail.com
 *
 */
public class TranslateMCFile {

	public static void main(String[] args) throws FileNotFoundException {
		// When an argument is not provided in the run of this program
		if (args.length != 1) {
			System.out.println("Use: TranslateMCFile <filename>");
			System.exit(0);
		}
		
		// set up the file stream and the parser
		Scanner file = new Scanner(new FileInputStream(args[0]));
		StringParser parser = new MCParser();
		
		// print out the translations one line at a time
		String ln = file.nextLine();
		for (; file.hasNextLine(); ln = file.nextLine()) {
			System.out.println(parser.parse(ln));
		}
		// finish off the last line
		System.out.println(parser.parse(ln));
		
		file.close();
		
	}

}
