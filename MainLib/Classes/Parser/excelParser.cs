using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;

namespace MainLib.Parsing
{
    public static class ExcelParser
    {
        public static void ParseDisciplines(out List<ParsedData> outData, string filePath)
        {
            outData = new List<ParsedData>();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while(reader.Read())
                    {
                        outData.Add(new ParsedDiscipline()
                        {
                            Name = reader.GetValue(0).ToString(),
                            Sem = Convert.ToInt32(reader.GetValue(1))
                        });
                    }
                }
            }
        }
        public static void ParseStudents(out List<ParsedData> outData, string filePath)
        {
            outData = new List<ParsedData>();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        outData.Add(new ParsedStudent()
                        {
                            Name = reader.GetValue(0).ToString(),
                            group = reader.GetValue(1).ToString()
                        });
                    }
                }
            }

        }
        public static void ParseTeachers(out List<ParsedData> outData, string filePath)
        {
            outData = new List<ParsedData>();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        outData.Add(new ParsedTeacher()
                        {
                            Name = reader.GetValue(0).ToString()
                        });
                    }
                }
            }
        }
    }
}
