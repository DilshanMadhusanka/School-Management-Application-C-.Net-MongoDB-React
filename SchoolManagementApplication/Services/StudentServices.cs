using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SchoolManagementApplication.Data;
using SchoolManagementApplication.Models;

namespace SchoolManagementApplication.Services
{
    public class StudentServices
    {
        private readonly IMongoCollection<Student> _studentCollection;

        public StudentServices(IOptions<DataBaseSetting> settings)
        {
            var mongoClient = new MongoClient(settings.Value.Connection);
            var mongoDb = mongoClient.GetDatabase(settings.Value.DataBaseName);
            _studentCollection = mongoDb.GetCollection<Student>(settings.Value.CollectionName);
        }

        // Get all student list
        public async Task <List<Student>>GetAsync() =>await _studentCollection.Find(_ =>true). ToListAsync();


        // Get student by ID 

        public async Task<Student> GetAsync(String id) =>
            await _studentCollection.Find(x => x.Id == id).FirstOrDefaultAsync() ;


        // Add new student 
        public async Task CreateAsync(Student newStudent) =>
           await _studentCollection.InsertOneAsync(newStudent);


        // Update student details
        public async Task UpdateAsync(String id, Student upateStudent) =>
            await _studentCollection.ReplaceOneAsync(x => x.Id == id, upateStudent);


        // Delete Student
        public async Task RemoveAsync(String id) =>
           await _studentCollection.DeleteOneAsync(x => x.Id == id);
    }
}
