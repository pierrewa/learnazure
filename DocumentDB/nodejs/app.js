// import the language driver
var MongoClient = require('mongodb').MongoClient
  , assert = require('assert');
 var ObjectID = require('mongodb').ObjectID;
  // Connection URL
var url = 'mongodb://127.0.0.1:27017/test';

// Use connect method to connect to the Server
MongoClient.connect(url, function(err, db) {
  
  //ensure we've connected
  assert.equal(null, err);
  

  console.log("Connected correctly to server");


  var bankData = db.collection('bank_data');

  bankData.insert({
  	first_name: "Martha",
  	last_name: "Jaramillo",
  	accounts: [
  	{
  		account_balance: "50000000",
  		account_type: "Investment",
  		currency: "USD"
  	}]
  }, function(err, result){
  	if(err){
      db.close();
  		return console.error(err);
  	}

  	console.log('inserted: ');
  	console.log(result);
  	console.log('inserted ' + result.length + ' docs');
    //close the database connection
    return db.close();

  }
  ) 



  
});