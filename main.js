// Build a morse code tree using json data
(function(document, app) {
	"use strict";
	
	if (!app) return;
	
	var morseTranslator;
	
	// Asynchronously get JSON data to create a morse code tree, and eventually our morseTranslator
	app.getJSON("morseTree.json", function(jsonData) {
		var Node = app.Node,
			jsonNodes = jsonData.nodes,
			topmostNode,
			charNodes = {};
		
		// Create node objects for each node found in the json data
		for (var key in jsonNodes) {
			var thisChar = key;
			charNodes[thisChar] = new Node(thisChar);
		}
		
		// Now, add the children
		for (var key in jsonNodes) {
			var children = jsonNodes[key].children;
			for (var childKey in children) {
				charNodes[key].addChild(childKey, charNodes[children[childKey]]);
			}
		}
		
		topmostNode = charNodes[jsonData.topmost];
		app.morseTree = new app.Tree(topmostNode);
		
		// Create a translator as a singleton
		morseTranslator = (function() {
			
			// Private
			function parseChar(morseStr) {
				if (morseStr.length == 0)
					return ' ';
				var current;
				
				// Move down the tree using each character to determine which child to use
				app.morseTree.moveToTop();
				for (var i=0, l=morseStr.length; i<l; i++) {
					app.morseTree.moveDown(morseStr.charAt(i));
				}
				
				// Return the data from the node on which we landed
				current = app.morseTree.getCurrent();
				if (current)
					return app.morseTree.getCurrent().data;
				return '';
			}
			
			// Public
			return {
				parse: function(morseStr) {
					
					// Separate into an array on the | symbol
					var unparsedArr = morseStr.split("|"),
						parsedStr = "";
					
					// Add each character after parsing it
					for (var i=0, l=unparsedArr.length; i<l; i++) {
						parsedStr = parsedStr + parseChar(unparsedArr[i]);
					}
					
					return parsedStr;
				}
			};
		})();
	});
	
	// Once the page has been fully loaded...
	$(document).ready(function() {
		
		// Add the translated text to the #result element when the form is submitted
		$("#morseForm").submit(function(e) {
			e.preventDefault();
			if (morseTranslator) {
				var morseStr = $('#morseText').val();
				$('#result').html(morseTranslator.parse(morseStr));
			}
		});
	});
})(document, app);