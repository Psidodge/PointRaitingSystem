using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib.DBServices;

namespace MainLib.Parsing
{
    public static class FillDataBase
    {
        public static void Fill(DataType type, ParsedData obj)
        {
            try
            {
                switch(type)
                {
                    case DataType.Teachers:
                        FillTeachers(((ParsedTeacher)obj).ConvertToDataBaseRep());
                        break;
                    case DataType.Students:
                        FillStudents(((ParsedStudent)obj).ConvertToDataBaseRep(), obj);
                        break;
                    case DataType.Disciplines:
                        FillDisciplines(((ParsedDiscipline)obj).ConvertToDataBaseRep());
                        break;
                    case DataType.None:
                        return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Fill(DataType type, List<ParsedData> obj) 
        {
            try
            {
                switch (type)
                {
                    case DataType.Teachers:
                        FillTeachers(obj.ConvertAll<UserInfo>(x => ((ParsedTeacher)x).ConvertToDataBaseRep()));
                        break;
                    case DataType.Students:
                        FillStudents(obj.ConvertAll<Student>(x => ((ParsedStudent)x).ConvertToDataBaseRep()), obj);
                        break;
                    case DataType.Disciplines:
                        FillDisciplines(obj.ConvertAll<Discipline>(x => ((ParsedDiscipline)x).ConvertToDataBaseRep()));
                        break;
                    case DataType.None:
                        return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        private static void FillTeachers(UserInfo teacher)
        {
            DataService.InsertIntoTeachersTable(teacher);
        }
        private static void FillTeachers(List<UserInfo> teachers)
        {
            foreach(UserInfo teacher in teachers)
            {
                DataService.InsertIntoTeachersTable(teacher);
            }
        }

        private static void FillStudents(Student student, ParsedData obj)
        {
            if (student.id_of_group == 0)
                student.id_of_group = DataService.InsertIntoGroupsTable(new Group()
                {
                    name = ((ParsedStudent)obj).group,
                    course = int.Parse(((ParsedStudent)obj).group.Split('-')[1].Substring(0, 1))
                });

            DataService.InsertIntoStudentsTable(student);
        }
        private static void FillStudents(List<Student> students, List<ParsedData> obj)
        {
            int objIter = 0,
                groupID = 0;
            foreach(Student student in students)
            {
                if (student.id_of_group == 0)
                    if (DataService.isGroupExist(out groupID, ((ParsedStudent)obj[objIter]).group))
                    {
                        student.id_of_group = groupID;
                    }
                    else
                    {
                        student.id_of_group = DataService.InsertIntoGroupsTable(new Group()
                        {
                            name = ((ParsedStudent)obj[objIter]).group,
                            course = int.Parse(((ParsedStudent)obj[objIter]).group.Split('-')[1].Substring(0, 1))
                        });
                    }
                DataService.InsertIntoStudentsTable(student);
                objIter++;
            }
        }

        private static void FillDisciplines(Discipline discipline)
        {
            DataService.InsertIntoDisciplinesTable(discipline);
        }
        private static void FillDisciplines(List<Discipline> disciplines)
        {
            foreach(Discipline discipline in disciplines)
            {
                DataService.InsertIntoDisciplinesTable(discipline);
            }
        }

    }
}
