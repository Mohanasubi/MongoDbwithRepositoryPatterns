using MongoDB.Bson.Serialization.Attributes;

namespace ASP.MongoDb.API.Entity
{
    public class AddUpdateDepartment
    {
        [BsonElement("name")]
        public string DepartmentName { get; set; } // Name of the department

        [BsonElement("location")]
        public string DepartmentLocation { get; set; } // Description of the department
    }
}
