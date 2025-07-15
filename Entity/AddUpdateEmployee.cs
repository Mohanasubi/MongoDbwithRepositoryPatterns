using MongoDB.Bson.Serialization.Attributes;

namespace ASP.MongoDb.API.Entity
{
    public class AddUpdateEmployee
    {
        //Bson element representation of name field
        [BsonElement("name")]
        public string Name { get; set; }

        //Bson elemnt representation og age field
        [BsonElement("age")]
        public int Age { get; set; }
    }
}
