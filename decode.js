var code = [];

fs.readFileSync('codeText').toString().split('\n').forEach(function (line) {
    if (line !== "") {
      code.push(line);
      }
});

module.exports = code;