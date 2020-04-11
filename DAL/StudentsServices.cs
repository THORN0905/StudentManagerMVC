using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Models;
using Models.Ext;

namespace DAL
{
    public class StudentsServices
    {
        /// <summary>
        /// 通过班级名查询学生
        /// </summary>
        /// <param name="ClassName"></param>
        /// <returns>学生列表</returns>
        public List<StudentsExt> queryStudentsbyClassName(string ClassName)
        {
            string sql = "Select Students.StudentId,StudentName,Gender,Birthday,StudentIdNo,CardNo,PhoneNumber,StudentAddress,Students.ClassId,ClassName,SQLServerDB,CSharp"
                + " from Students join StudentClass on Students.ClassId=StudentClass.ClassId "
                +"join ScoreList on ScoreList.StudentId=Students.StudentId "
                + " where ClassName like '%' + @ClassName + '%' ";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ClassName",ClassName)
            };            
            List<StudentsExt> stus = new List<StudentsExt>();
            try
            {
                SqlDataReader result = new Helper.SQLHelper().QueryAll(sql, param, false);
                while (result.Read())
                {
                    stus.Add(new StudentsExt{
                        StudentId = Convert.ToInt32(result["StudentId"]),
                        StudentName = result["StudentName"].ToString(),
                        Gender = result["Gender"].ToString(),
                        Birthday = Convert.ToDateTime(result["Birthday"]),
                        StudentIdNo = result["StudentIdNo"].ToString(),
                        CardNo = result["CardNo"].ToString(),
                        PhoneNumber = result["PhoneNumber"].ToString(),
                        StudentAddress = result["StudentAddress"].ToString(),
                        ClassId = Convert.ToInt32(result["ClassId"]),
                        ClassName = result["ClassName"].ToString(),
                        SQLServerDB = Convert.ToInt32(result["SQLServerDB"]),
                        CSharp = Convert.ToInt32(result["CSharp"])
                    });
                }
                result.Close();
                return stus;
            }catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        /// <summary>
        /// 通过学号查找学生
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns>学生信息</returns>
        public StudentsExt queryStudentByStudentId(int StudentId)
        {
            string sql = "Select Students.StudentId,StudentName,Gender,Birthday,StudentIdNo,CardNo,PhoneNumber,StudentAddress,Students.ClassId,ClassName,SQLServerDB,CSharp"
                + " from Students join StudentClass on Students.ClassId=StudentClass.ClassId "
                +"join ScoreList on ScoreList.StudentId=Students.StudentId "
                + " where Students.StudentId=@StudentId";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@StudentId",StudentId)
            };
            StudentsExt stu = null;
            SqlDataReader result = new Helper.SQLHelper().QueryAll(sql,param,false);
            while (result.Read())
            {
                stu = new StudentsExt()
                {
                    StudentId = Convert.ToInt32(result["StudentId"]),
                    StudentName = result["StudentName"].ToString(),
                    Gender = result["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(result["Birthday"]),
                    StudentIdNo = result["StudentIdNo"].ToString(),
                    CardNo = result["CardNo"].ToString(),
                    PhoneNumber = result["PhoneNumber"].ToString(),
                    StudentAddress = result["StudentAddress"].ToString(),
                    ClassId = Convert.ToInt32(result["ClassId"]),
                    ClassName = result["ClassName"].ToString(),
                    SQLServerDB = Convert.ToInt32(result["SQLServerDB"]),
                    CSharp = Convert.ToInt32(result["CSharp"])
                };
            }
            result.Close();
            return stu;
        }

        public int UpdateStudent(Students stu)
        {
            string sql = "update Students set StudentName=@StudentName,Gender=@Gender,StudentIdNo=@StudentIdNo,PhoneNumber=@PhoneNumber,StudentAddress=@StudentAddress"
                        + " where StudentId=@StudentId";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@StudentId",stu.StudentId),
                new SqlParameter("@StudentName",stu.StudentName),
                new SqlParameter("@Gender",stu.Gender),
                new SqlParameter("@StudentIdNo",stu.StudentIdNo),
                new SqlParameter("@PhoneNumber",stu.PhoneNumber),
                new SqlParameter("@StudentAddress",stu.StudentAddress)
            };
            return new Helper.SQLHelper().update(sql,param,false);
            
        }
    }
}
