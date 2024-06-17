using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD_With_MongoDb.Model;

public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}
