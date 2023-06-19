using DapperExtensions.Mapper;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Impl;
using System.Reflection;

namespace StudentManagement.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreateBy { get; set; }
        public string Response { get; set; }
    }
   
}
