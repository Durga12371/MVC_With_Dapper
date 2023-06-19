using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        // private readonly IConfiguration _configuration;
        private readonly IStudentServices _studentServices;
        

        public StudentController(IStudentServices studentServices)
        {
           // _configuration = configuration;
            _studentServices = studentServices;
        }


        public IActionResult Index()
        {
            StudentVM model = new StudentVM()
            {
                StudentsList = _studentServices.GetStudentsList().ToList(),
                CollgeDetails = new()
                {
                    University_Name = "Sails University",
                    Address="BakanaPalem , 80feet Road, Maduravada"
                    
                }

            };
            
            return View(model);
        }
        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<ActionResult> AddUpdateStudent(Student student)
        {
            StudentVM model = new StudentVM();
            student.CreateBy = 1;
            string url = Request.Headers["Referer"].ToString();
            string result=string.Empty;
            if(student.StudentId>0)
            {
                result=await _studentServices.UpdateStudent(student);
            }
            else
            {
                result = await _studentServices.InsertStudent(student);


            }
            if(result=="Save Successfully")
            {
                TempData["SuccessMsg"] = "Save Successfully";
                return Redirect(url);
            }
            else
            {
                TempData["ErrorMsg"]=result;
                return Redirect(url);
            }
            
        }
        public async Task<ActionResult> DeleteStudent(int StudentId)
        {
            string url = Request.Headers["Referer"].ToString();
            string result=await _studentServices.DeleteStudent(StudentId);
            if(result== "Delete Successfully")
            {
                return Json(new { message = "Delete Successfully" });
            }
            else
            {
                return Json(new { message = "Error Occured" });
            }
        }
    }
}
