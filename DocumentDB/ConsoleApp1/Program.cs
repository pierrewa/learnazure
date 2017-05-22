using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient client = new MongoClient("mongodb://127.0.0.1:27017"); // connect to localhost            
            var database = client.GetDatabase("test"); // "test" is the name of the database
            var bankData = database.GetCollection <BsonDocument>("bank_data");            

            BsonDocument person = new BsonDocument {
                { "first_name", "John"},
                { "last_name", "Doe"},
                { "accounts", new BsonArray {
                    new BsonDocument {
                        { "account_balance", 0},
                        { "account_type", "Investment"},
                        { "currency", "USD"}
                    }
                }}
            };

            bankData.InsertOne(person);

            System.Console.WriteLine(person["_id"]);

            //increment this persons balance by 100000
            person["accounts"][0]["account_balance"] = person["accounts"][0]["account_balance"].AsInt32 + 100000;

            var filter = Builders<BsonDocument>.Filter.Eq("_id", person["_id"]);         
            ReplaceOneResult result = bankData.ReplaceOne(filter, person);

            System.Console.WriteLine("Successfully updated 1 document.");

        }
    }
}
