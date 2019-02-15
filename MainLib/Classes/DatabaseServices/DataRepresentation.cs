using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLib.DBServices
{
    //NOTE: разобраться с именами методов зачем Group и GroupInfo
    //NOTE: Rename method names
    //Method names have to be similar to db fild names
    public abstract class DBTable
    {
        public abstract Type GetTableType();
    }

    public class ControlPoint : DBTable
    {
        public int id { get; set; }
        public int id_of_teacher { get; set; }
        public int id_of_discipline { get; set; }
        public int weight { get; set; }
        public string Description { get; set; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class ControlPointsOfStudents : DBTable
    {
        public int id { get; set; }
        public int id_of_student { get; set; }
        public int id_of_cp { get; set; }
        public int points { get; set; }
        public bool readOnly { get; set; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class Group : DBTable
    {
        public int id { get; set; }
        public string group_name { get; set; }
        public string group_type { get; set; } //NOTE: ?
        public int group_course { get; set; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class Discipline : DBTable
    {
        public int id { get; set; }
        public string discipline_name { get; set; }
        public string discipline_type { get; set; } //NOTE: ?
        public int semestr { get; set; }
        public int prevDisciplineId { get; set; }
        public string full_name { get => string.Concat(discipline_name, " ", semestr, " семестр"); }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class GroupDiscipline : DBTable
    {
        public int id { get; }
        public int GroupId { get; }
        public int DisciplineId { get; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class Student : DBTable
    {
        public int id { get; set; }
        public string name { get; set; }
        public int id_of_group { get; set; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class AuthInfo : DBTable
    {
        public byte[] Salt { get; }
        public byte[] Pass_hash { get; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }

    public class AuthInfoAdmin : DBTable
    {
        public string login { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Pass_hash { get; set; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class UserInfo : DBTable
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool isAdmin { get; set; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class TeacherInfo : DBTable
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string login { get; set; }
        public bool isAdmin { get; set; }
        public int id_of_authInfo { get; set; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class StudentInfo : DBTable
    {
        public int id { get; }
        public string name { get; }
        public string group_name { get; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class GroupInfo : DBTable
    {
        public int id { get; }
        public string group_name { get; }
        public int group_course { get; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class DisciplineInfo : DBTable
    {
        public int id { get; }
        public string discipline_name { get; }
        public int semestr { get; }
        public string full_name { get => string.Concat(discipline_name, " " , semestr, " семестр"); }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
}
