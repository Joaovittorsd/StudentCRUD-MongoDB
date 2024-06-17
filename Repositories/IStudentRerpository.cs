using CRUD_With_MongoDb.Model;
using MongoDB.Bson;

namespace CRUD_With_MongoDb.Repositories;

public interface IStudentRerpository
{
    Task<ObjectId> Create(Student student);
    Task<Student> Get(ObjectId objectId);
    Task<IEnumerable<Student>> GetAll();
    Task<IEnumerable<Student>> GetByName(string name);

    Task<bool> Update(ObjectId objectId, Student student);
    Task<bool> Delete(ObjectId objectId);
}
