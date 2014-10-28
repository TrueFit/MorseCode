// Define the basic app functionality
var app = app || {};	// Create a namespace for our classes
(function(app) {
	"use strict";
	
	// Define a Node "class"
	app.Node = function(data) {
		this.data = data;
		this.children = {};
	}
	app.Node.prototype.addChild = function(key, node) {
		this.children[key] = node;
	};
	
	// Define a Tree "class"
	app.Tree = function(topmostNode) {
		this.topmost = topmostNode;
		this.currentNode = this.topmost;
	}
	app.Tree.prototype.moveDown = function(key) {
		if (this.currentNode) {
			var childNode = this.currentNode.children[key];
			this.currentNode = childNode;
		}
	};
	app.Tree.prototype.moveToTop = function() {
		this.currentNode = this.topmost;
	};
	app.Tree.prototype.getCurrent = function() {
		return this.currentNode;
	};
	
	// Get the JSON data from the given url and send the parsed data to the callback given
	app.getJSON = function(url, callback) {
		$.ajax({
			dataType: "json",
			url: url,
			success: callback
		});
	};
})(app);