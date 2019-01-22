using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLib.DBServices
{
    //Method names have to be similar to db fild names
    public class ControlPoints
    {
        public int id { get; set; }
        public int id_of_teacher { get; set; }
        public int id_of_discipline { get; set; }
        public int weight { get; set; }
        public DateTime date { get; set; }
        public string Description { get; set; }
    }

    public class ControlPointsOfStudents
    {
        public int id { get; set; }
        public int id_of_student { get; set; }
        public int id_of_cp { get; set; }
        public int points { get; set; }
        public bool readOnly { get; set; }
    }

    public class Groups
    {
        public int id { get; }
        public string group_name { get; }
        public string group_type { get; } //NOTE: ?
        public int group_course { get; }
    }

    public class Disciplines
    {
        public int id { get; }
        public string discipline_name { get; }
        public string discipline_type { get; } //NOTE: ?
        public int semestr { get; }
        public int prevDisciplineId { get; }
        public string displayName { get; }
    }

    public class GroupDisciplines
    {
        public int id { get; }
        public int GroupId { get; }
        public int DisciplineId { get; }
    }
    
    public class Students
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
