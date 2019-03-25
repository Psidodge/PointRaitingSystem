using System;
using System.Collections.Generic;

namespace MainLib.DBServices
{
    //NOTE: Rename method names
    public abstract class DBEntity
    {
        public abstract Type GetEntityType();
    }

    public class ControlPoint : DBEntity
    {
        public int id { get; set; }
        public int id_of_user { get; set; }
        public int id_of_discipline { get; set; }
        public double weight { get; set; }
        public string Description { get; set; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class ControlPointsOfStudents : DBEntity
    {
        public int id { get; set; }
        public int id_of_student { get; set; }
        public int id_of_controlPoint { get; set; }
        public double points { get; set; }
        public bool readOnly { get; set; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class Group : DBEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; } //NOTE: ?
        public int course { get; set; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class Discipline : DBEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; } //NOTE: ?
        public int semestr { get; set; }
        public int prevDisciplineId { get; set; }
        public string full_name { get => string.Concat(name, " ", semestr, " семестр"); }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class GroupDiscipline : DBEntity
    {
        public int id { get; }
        public int GroupId { get; }
        public int DisciplineId { get; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class Student : DBEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public int id_of_group { get; set; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class StudentCertification : DBEntity
    {
        public int id { get; private set; }
        public int id_of_student { get; set; }
        public int id_of_prev_cp { get; set; }
        public int id_of_discipline { get; set; }
        public int id_of_user { get; set; }
        public int grade { get; private set; }
        public DateTime date { get; set; }


        public override Type GetEntityType()
        {
            return this.GetType();
        }

        public void CountGrade(int disciplineID, int previousControlPoinID)
        {
            double sumOfPoints = 0,
                   sumOfWeights = 0;
            try
            {
                sumOfWeights = DataService.GetSumOfPointsToCurrentCP(this.id_of_student, disciplineID, previousControlPoinID);
                sumOfPoints = DataService.GetStudentPointsSum(this.id_of_student);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            if (sumOfPoints > (sumOfWeights * 0.85))
            {
                grade = 5;
                return;
            }
            if (sumOfPoints > (sumOfWeights * 0.65))
            {
                grade = 4;
                return;
            }
            if (sumOfPoints > (sumOfWeights * 0.50))
            {
                grade = 3;
                return;
            }
            if (sumOfPoints < (sumOfWeights * 0.50))
            {
                grade = 2;
                return;
            }
        }
        public double GetMaxSumOfPoints()
        {
            try
            {
                return DataService.GetSumOfPointsToCurrentCP(this.id_of_student, id_of_discipline, id_of_prev_cp);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public double GetStudentScore()
        {
            try
            {
                return DataService.GetStudentPointsSum(this.id_of_student);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class StudentControlPoint : DBEntity
    {
        public int id { get; set; }
        public int id_of_student { get; set; }
        public int id_of_controlPoint { get; set; }
        public double points { get; set; }
        public string description { get; set; }
        public string pseudonym { get; set; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class StudentsWithCP : DBEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<StudentControlPoint> studentCPs { get; set; } 
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class AuthInfo : DBEntity
    {
        public byte[] salt { get; }
        public byte[] hash { get; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class AuthInfoAdmin : DBEntity
    {
        public int id { get; set; }
        public string login { get; set; }
        public byte[] salt { get; set; }
        public byte[] hash { get; set; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class UserInfo : DBEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool isAdmin { get; set; }
        public int authID { get; set; }
        //NOTE: Test getter
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class UserFullInfo : DBEntity
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
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class StudentInfo : DBEntity
    {
        public int id { get; }
        public string name { get; }
        public string group_name { get; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class GroupInfo : DBEntity
    {
        public int id { get; }
        public string name { get; }
        public int course { get; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class DisciplineInfo : DBEntity
    {
        public int id { get; }
        public string name { get; }
        public int semestr { get; }
        public string disciplineFullName { get => string.Concat(name, " " , semestr, " семестр"); }
        public override Type GetEntityType()
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
