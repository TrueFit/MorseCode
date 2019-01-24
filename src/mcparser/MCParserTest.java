package mcparser;

import static org.junit.Assert.*;

import org.junit.jupiter.api.Test;

/**
 * MCParserTest
 * 
 * <P>A testing routing for <code>MCParser</code>.
 * 
 * @author Asher Bernardi asherbernardi@gmail.com
 *
 */
class MCParserTest {
	private MCParser parser = new MCParser();

	@Test
	void oneT() {
		assertEquals(parser.parse("-"), "t");
	}
	
	@Test
	void oneE() {
		assertEquals(parser.parse("."), "e");
	}
	
	@Test
	void dog() {
		assertEquals(parser.parse("-..||---||--."), "dog");
	}

	@Test
	void wordsWithSpace() {
		assertEquals(parser.parse("....||.||.-..||.-..||---||||.--||---||.-.||.-..||-.."), "hello world");
	}
	
	@Test
	void longSentence() {
		String code = "-.--||---||..-||||....||.-||...-||.||||...||..-||-.-.||-.-.||.||...||...||..-.||..-||.-..||.-..||-.--||||-..||.||-.-.||---||-..||.||-..||||-||....||..||...||||--||.||...||...||.-||--.||.||.-.-.-";
		assertEquals(parser.parse(code), "you have successfully decoded this message.");
	}
	
	@Test
	void numbers() {
		assertEquals(parser.parse(".----||----.||..---||---..||...--||--...||....-||-....||.....||-----"), "1928374650");
	}
	
	@Test
	void invalidInput() {
		assertEquals(parser.parse("----------"), "ERR: INVALID CODE AT INDEX 5");
	}
	
	@Test
	void invalidInputOneVertLine() {
		assertEquals(parser.parse("-..|---|--."), "dERR: SINGLE VERTICLE LINE AT INDEX 3");
	}
	
	@Test
	void nonEnglish() {
		assertEquals(parser.parse(".-.-||.-..-||..--"), "äèü");
	}
	
	@Test
	void emptyNode1() {
		assertEquals(parser.parse("-.-.-"), "ERR: NO SUCH CODE AT INDEX 4");
	}
	
	@Test
	void emptyNode2() {
		assertEquals(parser.parse("--..-"), "ERR: NO SUCH CODE AT INDEX 4");
	}
	
	@Test
	void wholeAlphabet() {
		String code = ".-||-...||-.-.||-..||.||..-.||--.||....||..||.---||-.-||.-..||--||-.||---||.--.||--.-||.-.||...||-||..-||...-||.--||-..-||-.--||--..||...-.||..-..||..--.||.-..-||.--..||.--.-||.---.||-.-..||--.-.||--.--||..--||.-.-||---.||----||..--..||..--.-||.-..-.||.-.-.-||.--.-.||.----.||-....-||-.-.-.||-.-.--||-.--.-||--..--||---...||.-.-.||-...-||-..-.||-.--.";
		assertEquals(parser.parse(code), "abcdefghijklmnopqrstuvwxyzŝéðèþàĵçĝñüäöĥ?_\".@'-;!),:+=/(");
	}
}
