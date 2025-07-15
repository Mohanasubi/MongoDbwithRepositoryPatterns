using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASP.MongoDb.API.Entity
{
    public class Department
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 
        [BsonElement("name")]
        public string DepartmentName { get; set; } // Name of the department
        [BsonElement("location")]
        public string DepartmentLocation { get; set;} // Description of the department
      
    }
}
