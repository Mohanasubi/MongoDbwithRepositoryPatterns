using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASP.MongoDb.API.Entity
{
    [BsonIgnoreExtraElements]
    public class Employee
    {
        //Bson representation of objectid
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 

        //Bson element representation of name field
        [BsonElement("name")]
        public string Name { get; set; }

        //Bson elemnt representation og age field
        [BsonElement("age")]
        public int Age { get; set; } 
    }
}
