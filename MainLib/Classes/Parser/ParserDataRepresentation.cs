using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib.DBServices;

namespace MainLib.Parsing
{
    public enum DataType { None = -1, Disciplines = 0, Students = 1, Teachers = 2 };

    public abstract class ParsedData
    {
        public abstract Type GetTypeOfData();
    }

    public class ParsedDiscipline : ParsedData
    {
        public string Name { get; set; }
        public int Sem { get; set; }
        public Discipline ConvertToDataBaseRep()
        {
            return new Discipline()
            {
                name = Name,
                semestr = Sem
            };
        }
        public override Type GetTypeOfData()
        {
            return this.GetType();
        }
    }
    public class ParsedStudent : ParsedData
    {
        public string Name { get; set; }
        public string group { get; set; }
        public Student ConvertToDataBaseRep()
        {
            Func<int> func = () => { return DataService.GetIdOfGroupByGroupName(Name); };

            return new Student()
            {
                name = Name,
                id_of_group = func()
            };
        }
        public override Type GetTypeOfData()
        {
            return this.GetType();
        } 
    }
    public class ParsedTeacher : ParsedData
    {
        public string Name { get; set; }
        public UserInfo ConvertToDataBaseRep()
        {
            return new UserInfo()
            {
                Name = this.Name
            };
        }
        public override Type GetTypeOfData()
        {
            return this.GetType();
        }
    }
}
