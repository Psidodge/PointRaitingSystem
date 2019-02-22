using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLib.Parsing
{
    public abstract class ParsedData
    {
        public abstract Type GetTypeOfData();
    }

    public class ParsedDiscipline : ParsedData
    {
        public string Name { get; set; }
        public int Sem { get; set; }

        public override Type GetTypeOfData()
        {
            return this.GetType();
        }
    }
    public class ParsedGroup : ParsedData
    {
        public string Name { get; set; }
        public int Course { get; set; }

        public override Type GetTypeOfData()
        {
            return this.GetType();
        }
    }
    public class ParsedStudent : ParsedData
    {
        public string Name { get; set; }
        public ParsedGroup group { get; set; }
        public override Type GetTypeOfData()
        {
            return this.GetType();
        }
    }
    public class ParsedTeacher : ParsedData
    {
        public string Name { get; set; }
        public override Type GetTypeOfData()
        {
            return this.GetType();
        }
    }
}
