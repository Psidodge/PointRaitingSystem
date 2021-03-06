﻿using System;
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
        public uint id { get; set; }
        public uint id_of_user { get; set; }
        public uint id_of_discipline { get; set; }
        public double weight { get; set; }
        public string Description { get; set; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }

        public ControlPointTemplate ConvertToTemplate()
        {
            return new ControlPointTemplate()
            {
                id_of_discipline = this.id_of_discipline,
                id_of_user = this.id_of_user,
                description = Description,
                weight = this.weight
            };
        }
    }
    public class ControlPointTemplate : DBEntity
    {
        public uint id { get; set; }
        public uint id_of_user { get; set; }
        public uint id_of_discipline { get; set; }
        public double weight { get; set; }
        public string description { get; set; }


        public string GetFormatedString { get => $"{description}; Вес: {weight}"; }
        public ControlPoint ConvertToControlPoint()
        {
            return new ControlPoint()
            {
                id_of_user = this.id_of_user,
                id_of_discipline = this.id_of_discipline,
                weight = this.weight,
                Description = this.description
            };
        }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class ControlPointsOfStudents : DBEntity
    {
        public uint id { get; set; }
        public uint id_of_student { get; set; }
        public uint id_of_controlPoint { get; set; }
        public double points { get; set; }
        public bool readOnly { get; set; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
        public StudentControlPoint ConvertToStudentControlPoint()
        {
            return new StudentControlPoint()
            {
                id = this.id,
                id_of_student = this.id_of_student,
                id_of_controlPoint = this.id_of_controlPoint,
                points = this.points
            };
        }
    }
    public class Group : DBEntity
    {
        public uint id { get; set; }
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
        public uint id { get; set; }
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
    public class Student : DBEntity
    {
        public uint id { get; set; }
        public string name { get; set; }
        public uint id_of_group { get; set; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class StudentCertification : DBEntity
    {
        public uint id { get; set; }
        public uint id_of_student { get; set; }
        public uint id_of_prev_cp { get; set; }
        public uint id_of_discipline { get; set; }
        public uint id_of_user { get; set; }
        public int grade { get; private set; }
        public DateTime date { get; set; }
        public double sum_of_points { get; set; }


        public override Type GetEntityType()
        {
            return this.GetType();
        }

        public void CountGrade(uint disciplineID, uint previousControlPoinID)
        {
            double sumOfPoints = 0,
                   sumOfWeights = 0;
            try
            {
                sumOfWeights = DataService.GetSumOfMaxWeightsToCurrentCP(this.id_of_student, disciplineID, previousControlPoinID);
                sumOfPoints = DataService.GetStudentPointsSum(this.id_of_student, previousControlPoinID, disciplineID);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            if (sumOfPoints >= (sumOfWeights * 0.85))
            {
                grade = 5;
                return;
            }
            if (sumOfPoints >= (sumOfWeights * 0.65))
            {
                grade = 4;
                return;
            }
            if (sumOfPoints >= (sumOfWeights * 0.50))
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
        public double GetMaxSumOfPointsForCurCP()
        {
            try
            {
                return DataService.GetSumOfMaxWeightsToCurrentCP(this.id_of_student, id_of_discipline, id_of_prev_cp);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void CountStudentScore()
        {
            try
            {
                sum_of_points = DataService.GetStudentPointsSum(this.id_of_student, id_of_prev_cp, id_of_discipline);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public class StudentExam : DBEntity
    {
        public uint id { get; set; }
        public uint id_of_student { get; set; }
        public uint id_of_discipline { get; set; }
        public uint id_of_user { get; set; }
        public DateTime date { get; set; }
        public int grade { get; set; }
        public double points { get; set; }
        public uint id_of_reexam{ get; set; }

        public override Type GetEntityType()
        {
            return this.GetType();
        }
        public int CountRecommendedGrade()
        {
            double maxSumOfPoint = GetMaxSumOfPoints() + 20,
                   studentScore = GetMaxStudentScore() + points;

            if (studentScore >= (maxSumOfPoint * 0.85))
            {
                return 5;
            }
            if (studentScore >= (maxSumOfPoint * 0.65))
            {
                return 4;
            }
            if (studentScore >= (maxSumOfPoint * 0.50))
            {
                return 3;
            }
            if (studentScore < (maxSumOfPoint * 0.50))
            {
                return 2;
            }
            return -1;
        }
        public int CountRecommendedGrade(double currentPoints)
        {
            double maxSumOfPoint = GetMaxSumOfPoints() + 20;
            currentPoints += points;

            if (currentPoints >= (maxSumOfPoint * 0.85))
            {
                return 5;
            }
            if (currentPoints >= (maxSumOfPoint * 0.65))
            {
                return 4;
            }
            if (currentPoints >= (maxSumOfPoint * 0.50))
            {
                return 3;
            }
            if (currentPoints < (maxSumOfPoint * 0.50))
            {
                return 2;
            }
            return -1;
        }
        public void CountExamGrade()
        {
            double sumOfWeights = 20;

            if (points >= (sumOfWeights * 0.85))
            {
                grade = 5;
                return;
            }
            if (points >= (sumOfWeights * 0.65))
            {
                grade = 4;
                return;
            }
            if (points >= (sumOfWeights * 0.50))
            {
                grade = 3;
                return;
            }
            if (points < (sumOfWeights * 0.50))
            {
                grade = 2;
                return;
            }
        }
        public int GetExamGrade()
        {
            double sumOfWeights = 20;

            if (points >= (sumOfWeights * 0.85))
            {
                return 5;
            }
            if (points >= (sumOfWeights * 0.65))
            {
                return 4;
            }
            if (points >= (sumOfWeights * 0.50))
            {
                return 3;
            }
            if (points < (sumOfWeights * 0.50))
            {
                return 2;
            }
            return -1;
        }
        public double GetMaxSumOfPoints()
        {
            try
            {
                return DataService.GetSumOfMaxWeights(this.id_of_student, id_of_discipline);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public double GetMaxStudentScore()
        {
            try
            {
                return DataService.GetMaxSumOfStudentPoints(this.id_of_student, id_of_discipline);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public class StudentReexam : DBEntity
    {
        public uint id { get; set; }
        public DateTime date { get; set; }
        public double points { get; set; }
        public int grade { get; set; }

        public override Type GetEntityType()
        {
            return this.GetType();
        }

        public int CountRecommendedGrade(uint stID, uint disID)
        {
            double maxSumOfPoint = GetMaxSumOfPoints(stID, disID) + 20,
                   studentScore = GetMaxStudentScore(stID, disID) + points;

            if (studentScore >= (maxSumOfPoint * 0.85))
            {
                return 5;
            }
            if (studentScore >= (maxSumOfPoint * 0.65))
            {
                return 4;
            }
            if (studentScore >= (maxSumOfPoint * 0.50))
            {
                return 3;
            }
            if (studentScore < (maxSumOfPoint * 0.50))
            {
                return 2;
            }
            return -1;
        }
        public double GetMaxSumOfPoints(uint stID, uint disID)
        {
            try
            {
                return DataService.GetSumOfMaxWeights(stID, disID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public double GetMaxStudentScore(uint stID, uint disID)
        {
            try
            {
                return DataService.GetMaxSumOfStudentPoints(stID, disID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


    public class StudentControlPoint : DBEntity
    {
        public uint id { get; set; }
        public uint id_of_student { get; set; }
        public uint id_of_controlPoint { get; set; }
        public double points { get; set; }
        public string description { get; set; }
        public string pseudonym { get; set; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class StudentWithExam : DBEntity
    {
        public uint studentID { get; set; }
        public string studentName { get; set; }
        public StudentExam examInfo { get; set; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class StudentWithReexam : DBEntity
    {
        public uint studentID { get; set; }
        public string studentName { get; set; }
        public StudentExam examInfo { get; set; }
        public StudentReexam reexamInfo { get; set; }

        public override Type GetEntityType()
        {
            return this.GetType();
        }

        public int CountRecommendedGrade()
        {
            double maxSumOfPoint = GetMaxSumOfPoints() + 20,
                   studentScore = GetMaxStudentScore() + reexamInfo.points;

            if (studentScore >= (maxSumOfPoint * 0.85))
            {
                return 5;
            }
            if (studentScore >= (maxSumOfPoint * 0.65))
            {
                return 4;
            }
            if (studentScore >= (maxSumOfPoint * 0.50))
            {
                return 3;
            }
            if (studentScore < (maxSumOfPoint * 0.50))
            {
                return 2;
            }
            return -1;
        }
        public int CountRecommendedGrade(double currentPoints)
        {
            double maxSumOfPoint = GetMaxSumOfPoints() + 20;
            currentPoints += reexamInfo.points;

            if (currentPoints >= (maxSumOfPoint * 0.85))
            {
                return 5;
            }
            if (currentPoints >= (maxSumOfPoint * 0.65))
            {
                return 4;
            }
            if (currentPoints >= (maxSumOfPoint * 0.50))
            {
                return 3;
            }
            if (currentPoints < (maxSumOfPoint * 0.50))
            {
                return 2;
            }
            return -1;
        }
        public void CountExamGrade()
        {
            double sumOfWeights = 20;

            if (reexamInfo.points >= (sumOfWeights * 0.85))
            {
                reexamInfo.grade = 5;
                return;
            }
            if (reexamInfo.points >= (sumOfWeights * 0.65))
            {
                reexamInfo.grade = 4;
                return;
            }
            if (reexamInfo.points >= (sumOfWeights * 0.50))
            {
                reexamInfo.grade = 3;
                return;
            }
            if (reexamInfo.points < (sumOfWeights * 0.50))
            {
                reexamInfo.grade = 2;
                return;
            }
        }
        public int GetExamGrade()
        {
            double sumOfWeights = 20;

            if (reexamInfo.points >= (sumOfWeights * 0.85))
            {
                return 5;
            }
            if (reexamInfo.points >= (sumOfWeights * 0.65))
            {
                return 4;
            }
            if (reexamInfo.points >= (sumOfWeights * 0.50))
            {
                return 3;
            }
            if (reexamInfo.points < (sumOfWeights * 0.50))
            {
                return 2;
            }
            return -1;
        }
        public double GetMaxSumOfPoints()
        {
            try
            {
                return DataService.GetSumOfMaxWeights(examInfo.id_of_student, examInfo.id_of_discipline);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public double GetMaxStudentScore()
        {
            try
            {
                return DataService.GetMaxSumOfStudentPoints(examInfo.id_of_student, examInfo.id_of_discipline);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public class StudentsWithCP : DBEntity
    {
        public uint id { get; set; }
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
        public uint id { get; set; }
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
        public uint id { get; set; }
        public string Name { get; set; }
        public bool isAdmin { get; set; }
        public uint authID { get; set; }
        //NOTE: Test getter
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class UserFullInfo : DBEntity
    {
        public uint id { get; set; }
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
        public uint id { get; }
        public string name { get; }
        public string group_name { get; }
        public uint id_of_group { get; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class GroupInfo : DBEntity
    {
        public uint id { get; }
        public string name { get; }
        public int course { get; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class DisciplineInfo : DBEntity
    {
        public uint id { get; }
        public string name { get; }
        public int semestr { get; }
        public string disciplineFullName { get => string.Concat(name, " " , semestr, " семестр"); }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }
    public class ControlPointInfo : DBEntity
    {
        public uint id { get; }
        public string name { get; }
        public string discipline_name { get; }
        public uint weight { get; }
        public string description { get; }
        public override Type GetEntityType()
        {
            return this.GetType();
        }
    }



    public class GroupDiscipline
    {
        public uint id { get; set; }
        public uint GroupId { get; set; }
        public uint DisciplineId { get; set; }
    }
    public class TeacherDiscipline
    {
        public uint id_of_group { get; set; }
        public uint id_of_discipline { get; set; }
        public uint id_of_user { get; set; }
    }
}
