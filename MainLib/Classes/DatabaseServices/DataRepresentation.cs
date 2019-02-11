﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLib.DBServices
{
    //NOTE: разобраться с именами методов зачем Group и GroupInfo
    //NOTE: Rename method names
    //Method names have to be similar to db fild names
    public class ControlPoint
    {
        public int id { get; set; }
        public int id_of_teacher { get; set; }
        public int id_of_discipline { get; set; }
        public int weight { get; set; }
        public DateTime date { get; set; } //TODO: if isTemplate changing to false need to ask an user to change date and need to link this template to current students
        public string Description { get; set; }
        public bool isTemplate { get; set; } // добавлено для нормального подсчета баллов, становится истиным при окончании семестра,
    }

    public class ControlPointsOfStudents
    {
        public int id { get; set; }
        public int id_of_student { get; set; }
        public int id_of_cp { get; set; }
        public int points { get; set; }
        public bool readOnly { get; set; }
    }

    public class Group
    {
        public int id { get; set; }
        public string group_name { get; set; }
        public string group_type { get; set; } //NOTE: ?
        public int group_course { get; set; }
    }

    public class Discipline
    {
        public int id { get; set; }
        public string discipline_name { get; set; }
        public string discipline_type { get; set; } //NOTE: ?
        public int semestr { get; set; }
        public int prevDisciplineId { get; set; }
        //public string displayName { get; set; }
    }

    public class GroupDiscipline
    {
        public int id { get; }
        public int GroupId { get; }
        public int DisciplineId { get; }
    }
    
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int id_of_group { get; set; }
    }

    public class AuthInfo
    {
        public byte[] Salt { get; }
        public byte[] Pass_hash { get; }
    }

    public class AuthInfoAdmin
    {
        public string login { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Pass_hash { get; set; }
    }

    public class UserInfo
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool isAdmin { get; set; }
    }

    public class TeacherInfo
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string login { get; set; }
        public bool isAdmin { get; set; }
        public int id_of_authInfo { get; set; }
    }

    public class StudentInfo
    {
        public int id { get; }
        public string name { get; }
        public string group_name { get; }
    }

    public class GroupInfo
    {
        public int id { get; }
        public string group_name { get; }
        public int group_course { get; }
    }

    public class DisciplineInfo
    {
        public int id { get; }
        public string discipline_name { get; }
        public int semestr { get; }
        public string full_name { get => string.Concat(discipline_name, " " , semestr, " семестр"); }
    }
}
