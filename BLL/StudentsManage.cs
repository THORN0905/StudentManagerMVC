using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using Models.Ext;

namespace BLL
{
    public class StudentsManage
    {
        public List<StudentsExt> queryStudentsbyClassName(string ClassName){
            try
            {
                List<StudentsExt> stulist = new StudentsServices().queryStudentsbyClassName(ClassName);
                return stulist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentsExt queryStudentByStudentId(int StudentId)
        {
            return new StudentsServices().queryStudentByStudentId(StudentId);
        }

        public int UpdateStudent(Students stu)
        {
            return new StudentsServices().UpdateStudent(stu);
        }
        
    }
}
