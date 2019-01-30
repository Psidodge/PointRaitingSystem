using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLib.DBServices
{
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
        public int id { get; }
        public string group_name { get; }
        public string group_type { get; } //NOTE: ?
        public int group_course { get; }
    }

    public class Discipline
    {
        public int id { get; }
        public string discipline_name { get; }
        public string discipline_type { get; } //NOTE: ?
        public int semestr { get; }
        public int prevDisciplineId { get; }
        public string displayName { get; }
    }

    public class GroupDiscipline
    {
        public int id { get; }
        public int GroupId { get; }
        public int DisciplineId { get; }
    }
    
    public class Student
    {
        public int id { get; }
        public string name { get; }
        public int id_of_group { get; }
    }

    public class TeacherAuthInfo
    {
        public byte[] Salt { get; }
        public byte[] Pass_hash { get; }
    }

    public class TeacherInfo
    {
        public int id { get; }
        public string Name { get; }
    }
}
