using StudentManagement.Models;

namespace StudentManagement.Services
{
    public interface IStudentServices
    {
        public List<Student> GetStudentsList();
        public  Task<string> InsertStudent(Student student);
        public Task<string> UpdateStudent(Student student);
        public Task<string> DeleteStudent(int StudentId);

    }
}
