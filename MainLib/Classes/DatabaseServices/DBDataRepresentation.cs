using System;
using System.Collections.Generic;

namespace MainLib.DBServices
{
    //NOTE: Rename method names
    public abstract class DBTable
    {
        public abstract Type GetTableType();
    }

    public class ControlPoint : DBTable
    {
        public int id { get; set; }
        public int id_of_user { get; set; }
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
        public int id_of_controlPoint { get; set; }
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
        public string name { get; set; }
        public string type { get; set; } //NOTE: ?
        public int course { get; set; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class Discipline : DBTable
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; } //NOTE: ?
        public int semestr { get; set; }
        public int prevDisciplineId { get; set; }
        public string full_name { get => string.Concat(name, " ", semestr, " семестр"); }
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


    public class StudentControlPoint : DBTable
    {
        public int id { get; set; }
        public int id_of_student { get; set; }
        public int id_of_controlPoint { get; set; }
        public int points { get; set; }
        public string description { get; set; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class StudentsWithCP : DBTable
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<StudentControlPoint> studentCPs { get; set; } 
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class AuthInfo : DBTable
    {
        public byte[] salt { get; }
        public byte[] hash { get; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class AuthInfoAdmin : DBTable
    {
        public int id { get; }
        public string login { get; set; }
        public byte[] salt { get; set; }
        public byte[] hash { get; set; }
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
        public int authID { get; set; }
        //NOTE: Test getter
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class UserFullInfo : DBTable
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string login { get; set; }
        //NOTE: Test getter
        public string ShortName
        {
            get
            {
                try
                {
                    string shortName = string.Format("{0} {1}.{2}.", Name.Split(' ')[0], Name.Split(' ')[1].Substring(0, 1), Name.Split(' ')[2].Substring(0, 1));

                    return shortName;
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentOutOfRangeException || ex is IndexOutOfRangeException)
                        return Name;
                    else
                        return null;
                }
            }
        }
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
        public string name { get; }
        public int course { get; }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class DisciplineInfo : DBTable
    {
        public int id { get; }
        public string name { get; }
        public int semestr { get; }
        public string disciplineFullName { get => string.Concat(name, " " , semestr, " семестр"); }
        public override Type GetTableType()
        {
            return this.GetType();
        }
    }
    public class ControlPointInfo
    {
        public string name { get; }
        public string discipline_name { get; }
        public int weight { get; }
        public string description { get; }
    }
}
