
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolManagementApplication.Models

{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public String Id { get; set; }  = String.Empty;

        [BsonElement("firstName")]
        public string FirstName { get; set; } = "Student First Name";

        [BsonElement("lirstName")]
        public string LirstName { get; set; } = "Student Lirst Name";

        [BsonElement("department")]
        public string Department { get; set; } = "Department";

        [BsonElement("class")]
        public string Class { get; set; } = "Class";

        [BsonElement("gender")]
        public byte Gender { get; set; } = 1;

        [BsonElement("birthday")]
        public DateTime  DateOfBirth { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("graduated")]
        public Boolean IsGraduated { get; set; }


    }
}
