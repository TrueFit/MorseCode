Morse Code API
==============

Technologies
------------
- Node.js & Express
- Babel & Nodemon

Getting Started
---------------
- install node.js
- install npm
- ./MorseCode/npm -i

Starting the server
-------------------
- npm start

Configuration
=============
- URL: http://localhost
- PORT: 3000
- encoding: UTF-8

Supported Methods
=================
GET
---
/test
Reads directly from FS test file

GET
---
/translate?morsecode={your morse code here}

POST
----
/translate