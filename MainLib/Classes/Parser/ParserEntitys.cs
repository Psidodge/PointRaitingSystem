using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib.DBServices;

namespace MainLib.Parsing
{
    public enum DataType { None = -1, Disciplines = 0, Students = 1, Teachers = 2 };

    public abstract class ParserEntity
    {
        public abstract Type GetTypeOfData();
        public abstract void ChangeObject(params object[] listOfParams);
    }

    public class ParsedDiscipline : ParserEntity
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
        public override void ChangeObject(params object[] listOfParams)
        {
            if (listOfParams.Length > 2)
                throw new InvailidParamsAmountException(string.Format("Calling object '{0}' with invailid amount of paramaters. Needed {1}", this.GetType(), 2));

            try
            {
                Name = (string)listOfParams[0];
                Sem = (int)listOfParams[1];
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
    public class ParsedStudent : ParserEntity
    {
        public string Name { get; set; }
        public string group { get; set; }
        public Student ConvertToDataBaseRep()
        {
            Func<uint> func = () => { return DataService.GetIdOfGroupByGroupName(group); };

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
        public override void ChangeObject(params object[] listOfParams)
        {
            if (listOfParams.Length > 2)
                throw new InvailidParamsAmountException(string.Format("Calling object '{0}' with invailid amount of paramaters. Needed {1}", this.GetType(), 2));

            try
            {
                Name = (string)listOfParams[0];
                group = (string)listOfParams[1];
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public class ParsedTeacher : ParserEntity
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
        public override void ChangeObject(params object[] listOfParams)
        {
            if (listOfParams.Length > 1)
                throw new InvailidParamsAmountException(string.Format("Calling object '{0}' with invailid amount of paramaters. Needed {1}", this.GetType(), 1));

            try
            {
                Name = (string)listOfParams[0];
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


    [Serializable]
    public class InvailidParamsAmountException : Exception
    {
        public InvailidParamsAmountException() { }
        public InvailidParamsAmountException(string message) : base(message) { }
        public InvailidParamsAmountException(string message, Exception inner) : base(message, inner) { }
        protected InvailidParamsAmountException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
