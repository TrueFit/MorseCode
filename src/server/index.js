import express from 'express';
import fs, { fstatSync } from 'fs';
import MorseCode from './api/MorseCode';
import config from './config';

var app = express();

//chunking file upload
app.use(function (req, res, next) {
    var data = '';
    req.setEncoding(config.encoding);
    req.on('data', function (chunk) {
        data += chunk;
    });

    req.on('end', function () {
        req.body = data;
        next();
    });
});

//root
app.get('/', (request, response) => {
    response.send('Please see README_NEW.md');
});

//test file from FS
app.get('/test', (request, response) => {
    var data = fs.readFileSync(process.cwd() + config.testFileDir, config.encoding,
        (error, data) => {
            return data;
        });
    const morsecode = new MorseCode(data);
    response.send('<pre>' + morsecode.translate() + '</pre>');
});

//Query via GET
app.get('/translate', (request, response) => {
    if (!request.query.morsecode) return response.sendStatus(400);
    const morsecode = new MorseCode(request.query.morsecode);

    response.send({
        'result': morsecode.translate()
    });
});

//file POST
app.post('/translate', (request, response) => {
    if (!request.body) return response.sendStatus(400);
    const morsecode = new MorseCode(request.body);
    const data = morsecode.translate();

    response.send(data);
});

app.listen(3000);
console.log('Server running on port 3000');