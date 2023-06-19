using Dapper;
using StudentManagement.Models;
using System.Data;
using System.Data.SqlClient;


namespace StudentManagement.Services
{
    
    public class StudentServices : IStudentServices
    {
        //private readonly IConfiguration _configuration;

        //public StudentServices(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    ConnectionString = _configuration.GetConnectionString("DBConnection");
        //    ProvideName ="System.Data.SqlClient";
        //}

        //public string ConnectionString { get; }
        //public string ProvideName { get; }
        //public IDbConnection Connection
        //{
        //    get { return new SqlConnection(ConnectionString); }
        //}
        private readonly IDbConnection dbConnection;
        public StudentServices(IConfiguration configuration)
        {
            this.dbConnection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
        }
        public async Task<string> DeleteStudent(int StudentId)
        {
            string result = "";
            
               
               
                    var stud =await dbConnection.QueryAsync<Student>("DeleteStudent", 
                    new
                    {
 
                        StudentId = StudentId

                    },
                        commandType: CommandType.StoredProcedure);
                    if (stud!= null && stud.FirstOrDefault().Response=="Delete Successfully")
                    {
                        result ="Delete Successfully";
                    }
                 
                    return result;
            
        }

        public List<Student> GetStudentsList()
        {
            List<Student> students = new List<Student>();
            students = dbConnection.Query<Student>("GetStudentList", commandType: CommandType.StoredProcedure).ToList();
             return students;
             
           
        }

        public async Task<string> InsertStudent(Student student)
        {
           
            string result ="";
                   var  std = await dbConnection.QueryAsync<Student>("InsertStudent",
                       new {StudentName=student.StudentName,EmailAddress=student.EmailAddress,
                       City=student.City, CreateBy=student.CreateBy },
                       commandType: CommandType.StoredProcedure);

                     
                    if (std!=null && std.FirstOrDefault().Response=="Save Successfully")
                    {
                        return "Save Successfully";
                    }
                    return result;
        }
            
      

        public async Task<string> UpdateStudent(Student student)
        {
            string result = "";
                    var stud = await dbConnection.QueryAsync<Student>("UpdateStudent", new { StudentName = student.StudentName, EmailAddress = student.EmailAddress, 
                        City = student.City, CreateBy = student.CreateBy, StudentId=student.StudentId },
                        commandType: CommandType.StoredProcedure);
                    if (stud!= null && stud.FirstOrDefault().Response== "UPDATE Successfully")
                    {
                        result = "Save Successfully";
                    }
                   
                    return result;
           
           
        }
    }
}
