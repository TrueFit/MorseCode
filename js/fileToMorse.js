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
        	<label for="file-upload" style={styles.buttonStyle}>
        	Upload File
        		<input id="file-upload" 
        			type="file" 
        			style={styles.hiddenStyle} 
        			accept=".txt" 
        			onChange={this.uploadFile}/>
        	</label>
        <br />
        <br />
        <br />
        <div><b>Translation:</b> {this.state.displayString}</div>
      </div>);
	},
  
	/*
	 * updates state to show translated output, or alerts user of error in parsing
	 */
  showTranslation: function(inputString) {
  	var output = morseToLatin(inputString);
  	if (output == undefined){
  		window.alert("Unable to parse morse from file.");
  		output = "";
  	}
   	this.setState({displayString: output})

  },

  /*
   * Handles file uploading. Upon uploading file, displays translation.
   */
	uploadFile: function(event){ 
		if (event.target.files.length > 0){
  		var file = event.target.files[0];
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

var styles ={
	buttonStyle: {
		display: 'inline-block',
		padding: 6,
		cursor: 'pointer',
		border: '1px solid #ccc'
	},
	hiddenStyle: {
		display: 'none'
	}
}

ReactDOM.render(
	<FileTranslator />,
	document.getElementById('container')
);