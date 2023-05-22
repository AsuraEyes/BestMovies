using MongoDB.Bson;
using MongoDB.Driver;

class Program {
    static void Main (string[] args) {
        MongoClient dbClient = new MongoClient ("mongodb://bestmovies:T7kEN4N9rFiyO3NxiO2n70eibqRSXrThkxvAUpOhy9490QKnrpS58hkYKoPKwZJJkqEXfLdBxgnPACDbEJUVRg==@bestmovies.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@bestmovies@");

        var database = dbClient.GetDatabase ("sample_training");
        var collection = database.GetCollection<BsonDocument> ("grades");
        
        var document = new BsonDocument { { "student_id", 10000 }, {
                "scores",
                new BsonArray {
                    new BsonDocument { { "type", "exam" }, { "score", 88.12334193287023 } },
                    new BsonDocument { { "type", "quiz" }, { "score", 74.92381029342834 } },
                    new BsonDocument { { "type", "homework" }, { "score", 89.97929384290324 } },
                    new BsonDocument { { "type", "homework" }, { "score", 82.12931030513218 } }
                }
            }, { "class_id", 480 }
        };
        
        collection.InsertOne(document);
        
        var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
        Console.WriteLine(firstDocument.ToString());

    }
}