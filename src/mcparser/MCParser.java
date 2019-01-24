package mcparser;

import java.text.StringCharacterIterator;

/**
 * MCParser
 * 
 * <P>Parses and translates a string of dot and
 * dashes into a string of letters according to
 * the international Morse code specifications.
 * <P>Since this specification includes non-english
 * characters, this file must be compiled in UTF-8.
 * 
 * @author Asher Bernardi asherbernardi@gmail.com
 *
 */
public class MCParser implements StringParser {
	/**
	 * MCNode
	 * <P> The nodes in a dichotomic search tree for Morse code.
	 * 
	 * @author Asher Bernardi
	 */
	private class MCNode {
		char translation;
		MCNode dot;
		MCNode dash;
		MCNode(char t, MCNode dot, MCNode dash) {
			translation = t;
			this.dot = dot;
			this.dash = dash;
		}
	}
	
	/**
	 * The root of the search tree
	 */
	private MCNode root = initializeMCTree();
	
	/**
	 * Builds the dichotomic search tree for international 
	 * Morse code as described at
	 * https://en.wikipedia.org/wiki/Morse_code#/media/File:Morse_code_tree3.png
	 * It creates each node in backwards depth-first order
	 * through the tree. Since there seems to be some disagreement
	 * on the proper translations of some punctuation and
	 * non-English letters, the above search tree was modified 
	 * based on the table found here:
	 * https://en.wikipedia.org/wiki/Morse_code#Letters,_numbers,_punctuation,_prosigns_for_Morse_code_and_non-English_variants
	 * Most letters are represented by variable named their
	 * respective characters.
	 * Numbers are represented by a _ followed by the number.
	 * Punctuation are represented by variables named with
	 * words refering to that punctuation.
	 * 
	 * @return root the root of the dichotomic search tree
	 */
	private MCNode initializeMCTree() {
		MCNode _0 = new MCNode('0',null,null);
		MCNode _9 = new MCNode('9',null,null);
		MCNode ĥ = new MCNode('ĥ',_9,_0);
		MCNode colon = new MCNode(':',null,null);
		MCNode _8 = new MCNode('8',colon,null);
		MCNode ö = new MCNode('ö',_8,null);
		MCNode o = new MCNode('o',ö,ĥ);
		MCNode ñ = new MCNode('ñ',null,null);
		MCNode ĝ = new MCNode('ĝ',null,null);
		MCNode q = new MCNode('q',ĝ,ñ);
		MCNode comma = new MCNode(',',null,null);
		MCNode empty2 = new MCNode((char)0,null,comma);
		MCNode _7 = new MCNode('7',null,null);
		MCNode z = new MCNode('z',_7,empty2);
		MCNode g = new MCNode('g',z,q);
		MCNode m = new MCNode('m',g,o);
		MCNode closePar = new MCNode(')',null,null);
		MCNode openPar = new MCNode('(',null,closePar);
		MCNode y = new MCNode('y',openPar,null);
		MCNode exclamation = new MCNode('!',null,null);
		MCNode semicolon = new MCNode(';',null,null);
		MCNode empty1 = new MCNode((char)0,semicolon,exclamation);
		MCNode ç = new MCNode('ç',null,null);
		MCNode c = new MCNode('c',ç,empty1);
		MCNode k = new MCNode('k',c,y);
		MCNode slash = new MCNode('/',null,null);
		MCNode x = new MCNode('x',slash,null);
		MCNode equals = new MCNode('=',null,null);
		MCNode hyphen = new MCNode('-',null,null);
		MCNode _6 = new MCNode('6',null,hyphen);
		MCNode b = new MCNode('b',_6,equals);
		MCNode d = new MCNode('d',b,x);
		MCNode n = new MCNode('n',d,k);
		MCNode t = new MCNode('t',n,m);
		MCNode apostrophe = new MCNode('\'',null,null);
		MCNode _1 = new MCNode('1',apostrophe,null);
		MCNode ĵ = new MCNode('ĵ',null,null);
		MCNode j = new MCNode('j',ĵ,_1);
		MCNode at = new MCNode('@',null,null);
		MCNode à = new MCNode('à',at,null);
		MCNode þ = new MCNode('þ',null,null);
		MCNode p = new MCNode('p',þ,à);
		MCNode w = new MCNode('w',p,j);
		MCNode period = new MCNode('.',null,null);
		MCNode plus = new MCNode('+',null,period);
		MCNode ä = new MCNode('ä',plus,null);
		MCNode doubleQuotes = new MCNode('"',null,null);
		MCNode è = new MCNode('è',doubleQuotes,null);
		MCNode l = new MCNode('l',null,è);
		MCNode r = new MCNode('r',l,ä);
		MCNode a = new MCNode('a',r,w);
		MCNode _2 = new MCNode('2',null,null);
		MCNode underscore = new MCNode('_',null,null);
		MCNode question = new MCNode('?',null,null);
		MCNode ð = new MCNode('ð',question,underscore);
		MCNode ü = new MCNode('ü',ð,_2);
		MCNode é = new MCNode('é',null,null);
		MCNode f = new MCNode('f',é,null);
		MCNode u = new MCNode('u',f,ü);
		MCNode _3 = new MCNode('3',null,null);
		MCNode ŝ = new MCNode('ŝ',null,null);
		MCNode v = new MCNode('v',ŝ,_3);
		MCNode _4 = new MCNode('4',null,null);
		MCNode _5 = new MCNode('5',null,null);
		MCNode h = new MCNode('h',_5,_4);
		MCNode s = new MCNode('s',h,v);
		MCNode i = new MCNode('i',s,u);
		MCNode e = new MCNode('e',i,a);
		MCNode root = new MCNode(' ', e, t);
		return root;
	}
	
	/**
	 * Given a String in Morse code, translate it into a String
	 * of characters.
	 * @param str The String given to be translated. Consisting of
	 * ".", "-" and "|" characters.
	 * @return The translated string.
	 */
	public String parse(String str) {
		String ret = "";
		StringCharacterIterator it = new StringCharacterIterator(str);
		MCNode translator = root;
		// error var denotes if the parser found an error. If so, it
		// will not add the last character after the loop has terminated
		Boolean error = false;
		// Going through the string, if we see a dot, we go down the
		// tree by way of the dot, if we see a dash, we follow the
		// tree down the dash side, and if we see a |, we use the 
		// translated character associated with the current node.
		for(char c = it.first(); c != it.DONE; c = it.next()) {
			if (c == '.') {
				if (translator.dot == null) {
					ret += "ERR: INVALID CODE AT INDEX " + it.getIndex();
					error = true;
					break;
				}
				translator = translator.dot;
			}
			else if (c == '-') {
				if (translator.dash == null) {
					ret += "ERR: INVALID CODE AT INDEX " + it.getIndex();
					error = true;
					break;
				}
				translator = translator.dash;
			}
			else if (c == '|') {
				if (translator.translation == (char)0) {
					ret += "ERR: NO SUCH CODE AT INDEX " + it.getIndex();
					error = true;
					break;
				}
				ret += translator.translation;
				translator = root;
				// A break should always be TWO verticle lines in a row.
				// This checks that there are two and also moves us
				// forward to the next vert line so it doesn't have
				// to be accounted for a second time.
				if (it.next() != '|') {
					ret += "ERR: SINGLE VERTICLE LINE AT INDEX " + (it.getIndex()-1);
					error = true;
					break;
				}
			}
			// input does not match the protocol.
			else {
				ret += "ERR: INVALID INPUT AT INDEX " + it.getIndex();
				error = true;
				break;
			}
		}
		// To account for the last character
		if (translator.translation == (char)0) {
			ret += "ERR: NO SUCH CODE AT INDEX " + (it.getIndex()-1);
			error = true;
		}
		if (!error) ret += translator.translation;
		
		return ret;
	}

}
