﻿using Amazon.Runtime.Internal;
using CRUD_With_MongoDb.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CRUD_With_MongoDb.Repositories;

public class StudentRepository : IStudentRerpository
{
    private readonly IMongoCollection<Student> _students;

    public StudentRepository(IMongoClient client)
    {
        var database = client.GetDatabase("StudentDB");
        var collection = database.GetCollection<Student>(nameof(Student));

        _students = collection;
    }

    public async Task<ObjectId> Create(Student student)
    {
        await _students.InsertOneAsync(student);

        return student.Id;
    }

    public async Task<bool> Delete(ObjectId objectId)
    {
        var filter = Builders<Student>.Filter.Eq(x => x.Id, objectId);
        var result = await _students.DeleteOneAsync(filter);

        return result.DeletedCount == 1;
    }

    public Task<Student> Get(ObjectId objectId)
    {
        var filter = Builders<Student>.Filter.Eq(x => x.Id, objectId);
        var student = _students.Find(filter).FirstOrDefaultAsync();

        return student;
    }

    public async Task<IEnumerable<Student>> GetAll()
    {
        var students = await _students.Find(_ => true).ToListAsync();

        return students;
    }

    public async Task<IEnumerable<Student>> GetByName(string name)
    {
        var filter = Builders<Student>.Filter.Eq(x => x.Name, name);
        var students = await _students.Find(filter).ToListAsync();

        return students;
    }

    public async Task<bool> Update(ObjectId objectId, Student student)
    {
        var filter = Builders<Student>.Filter.Eq(x => x.Id, objectId);
        var update = Builders<Student>.Update
            .Set(x => x.Name, student.Name)
            .Set(x => x.Phone, student.Phone)
            .Set(x => x.Address, student.Address);
        var result = await _students.UpdateManyAsync(filter, update);

        return result.ModifiedCount == 1;
    }
}
