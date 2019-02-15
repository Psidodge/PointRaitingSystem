using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MainLib.DBServices;
using ExcelDataReader;

namespace MainLib.Parsing
{
    public static class ExcelParser
    {
        public static void ParseDisciplines(out List<DBTable> outData, string filePath)
        {
            outData = new List<DBTable>();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while(reader.Read())
                    {
                        outData.Add(new Discipline()
                        {
                            discipline_name = reader.GetValue(0).ToString(),
                            semestr = Convert.ToInt32(reader.GetValue(1))
                        });
                    }
                }
            }
        }
        public static void ParseGroups(out List<DBTable> outData, string filePath)
        {
            outData = new List<DBTable>();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        outData.Add(new Group()
                        {
                            group_name = reader.GetValue(0).ToString(),
                            group_course = Convert.ToInt32(reader.GetValue(1))
                        });
                    }
                }
            }
        }
        public static void ParseStudents(out List<DBTable> outData, string filePath)
        {
            outData = new List<DBTable>();
            int grId;
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (!DataService.isGroupExist(out grId, reader.GetValue(1).ToString()))
                            //NOTE: Здесь, в теории, не должно создаваться записей
                            grId = DataService.InsertIntoGroupsTable(new Group()
                            {
                                group_name = reader.GetValue(1).ToString(),
                                group_course = Convert.ToInt32(reader.GetValue(1).ToString().ElementAt(reader.GetValue(1).ToString().IndexOf('-') + 1))
                            });

                        outData.Add(new Student()
                        {
                            name = reader.GetValue(0).ToString(),
                            id_of_group = grId
                        });
                    }
                }
            }

        }
        public static void ParseTeachers(out List<DBTable> outData, string filePath)
        {
            outData = new List<DBTable>();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        outData.Add(new Discipline()
                        {
                            discipline_name = reader.GetValue(0).ToString(),
                            semestr = Convert.ToInt32(reader.GetValue(1))
                        });
                    }
                }
            }
        }
    }
}
