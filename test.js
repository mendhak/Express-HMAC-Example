const crypto = require('crypto');

const hmac = crypto.createHmac('sha256', 'secret');
const time = Date.now().toString();

hmac.update(time);
hmac.update('POST');
hmac.update('/protected');


// Only needed if you're doing a POST/PUT with a body.
// If doing a GET, comment this block out.  
const contentHash = crypto.createHash('md5');
contentHash.update(JSON.stringify({"a": "b"}));
//contentHash.update("aaaa");
let ch = contentHash.digest('hex');
//console.log(ch);
hmac.update(ch);
//hmac.update(contentHash.digest('hex'));

console.log(`HMAC ${time}:${hmac.digest('hex')}`);
