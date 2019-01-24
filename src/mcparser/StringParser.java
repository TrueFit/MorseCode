package mcparser;

/**
 * StringParser
 * 
 * Parses a string using some implemented parsing algorithm into
 * some other string representation.
 * 
 * @author Asher Bernardi asherbernardi@gmail.com
 *
 */
public interface StringParser {
	/**
	 * Parse the string
	 * @param str the given string the be parsed
	 * @return the new string after parsing
	 */
	public String parse(String str);
}