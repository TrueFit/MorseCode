var FileTranslator = React.createClass({
	getInitialState: function() {
		return {displayString: ""};
	},

	/*
	 * Renders view with file input that accepts .txt files, and has simple text output.
	 */
	render: function() {
		return(
        <div>
        	<input type="file" accept=".txt" ref={(ref) => this.fileInput = ref}/>
        <br />
        <div>Output: {this.state.displayString}</div>
      </div>);
	},
	
  componentDidMount: function() {
  	this.fileInput.addEventListener("change", this.uploadFile);
  },
  
  componentWillUnmount: function() {
  	this.fileInput.removeEventListener("change", this.uploadFile)
  },
  
	/*
	 * updates state to show translated output, or display error in parsing
	 */
  showTranslation: function(inputString) {
  	var output = morseToLatin(inputString);
  	if (output == undefined){
  		output = "Unable to parse morse from file.";
  	}
   	this.setState({displayString: output})

  },

  /*
   * Handles file uploading. Upon uploading file, displays translation.
   */
	uploadFile: function(){ 
		if (this.fileInput.files.length > 0){
  		var file = this.fileInput.files[0];
			var reader = new FileReader();
			reader.onload = function(event) {
    		var contents = event.target.result;
    		this.showTranslation(contents);
			}.bind(this);
			reader.onerror = function(event) {
    		console.error("Error reading file: " + event.target.error.code);
			};
			reader.readAsText(file);
		}
	}
});

ReactDOM.render(
	<FileTranslator />,
	document.getElementById('container')
);