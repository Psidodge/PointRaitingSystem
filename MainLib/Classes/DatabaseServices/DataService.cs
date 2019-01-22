using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MainLib.DBServices
{
    //NOTE: Refactor this class later
    public static class DataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["cp_dbConnectionString"].ConnectionString;
        //TODO: удалить логгер
        public static List<TeacherAuthInfo> SelectAuthInfoByLogin(string _login)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            string query = "SELECT pass_hash, salt FROM authInfo WHERE [login] = @login";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    throw e;
                }

                return connection.Query<TeacherAuthInfo>(query, new { login = _login }).ToList();
            }
        }
        public static TeacherInfo SelectLoggedTeacher(string _login)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            string query = "SELECT t.id, t.[name] FROM teachers as t INNER JOIN authInfo AS ai ON t.id_of_authInfo = ai.id WHERE ai.login = @login";
            var parametrs = new DynamicParameters();
            parametrs.Add("@login", _login);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch(Exception e)
                {
                    logger.Error(e);
                    throw e;
                }

                return connection.QueryFirst<TeacherInfo>(query, parametrs);
            }
        }
        public static TeacherInfo SelectTeacherById(int id)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            string query = "SELECT id, [name] FROM teachers WHERE id = @id";
            var parametrs = new DynamicParameters();
            parametrs.Add("@id", id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    throw e;
                }

                return connection.QueryFirst<TeacherInfo>(query, parametrs);
            }
        }
        public static List<Groups> SelectGroupsByTeacherLogin(int _id)
        {
            string query = "select gr.* from dbo.groups as gr " +
                           "inner join dbo.teacher_groups as tgr on gr.id = tgr.id_of_group " +
                           "inner join dbo.teachers as t on tgr.id_of_teacher = t.id where t.id = @id";

            var parametrs = new DynamicParameters();
            parametrs.Add("@id", _id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return connection.Query<Groups>(query, parametrs).ToList();
            }
        }
        public static List<Disciplines> SelectDisciplinesByTeacherLogin(int _id, int groupId)
        {
            string query = "select d.* from dbo.disciplines as d " +
                           "inner join dbo.group_disciplines as grd on grd.id_of_discipline = d.id " +
                           "inner join dbo.teacher_disciplines as td on td.id_of_discipline = d.id " +
                           "where grd.id_of_group = @groupId AND td.id_of_teacher = @id";

            var parametrs = new DynamicParameters();
            parametrs.Add("@id", _id);
            parametrs.Add("@groupId", groupId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return connection.Query<Disciplines>(query, parametrs).ToList();
            }
        }
        public static List<Disciplines> SelectDisciplines(int _id)
        {
            string query = "select d.* from dbo.disciplines as d " +
                           "inner join dbo.teacher_disciplines as td on td.id_of_discipline = d.id " +
                           "where td.id_of_teacher = @id";

            var parametrs = new DynamicParameters();
            parametrs.Add("@id", _id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return connection.Query<Disciplines>(query, parametrs).ToList();
            }
        }
        public static List<Students> SelectStudentsByGroupId(int groupId)
        {
            string query = "SELECT * FROM students WHERE id_of_group = @groupId";
            var parametrs = new DynamicParameters();
            parametrs.Add("@groupId", groupId);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return connection.Query<Students>(query, parametrs).ToList();
            }
        }
        public static List<ControlPoints> SelectControlPoints(int _id)
        {
            string query = "Select * from controlPoints where id_of_discipline = @id";

            var parametrs = new DynamicParameters();
            parametrs.Add("@id", _id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return connection.Query<ControlPoints>(query, parametrs).ToList();
            }
        }
        public static Disciplines SelectDisciplineById(int id)
        {
            string query = "SELECT * FROM disciplines WHERE id = @id";
            var parametrs = new DynamicParameters();
            parametrs.Add("@id", id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return connection.QueryFirst<Disciplines>(query, parametrs);
            }
        }
        public static List<ControlPointsOfStudents> SelectStudentCPById(int stId, int cpId)
        {
            string query =  "SELECT scp.* FROM cp_of_student AS scp " +
                            "INNER JOIN controlPoints AS cp ON cp.id = scp.id_of_cp " +
                            "WHERE scp.id_of_student = @sid AND cp.id_of_discipline = @cid";

            var parametrs = new DynamicParameters();
            parametrs.Add("@sid", stId);
            parametrs.Add("@cid", cpId);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return connection.Query<ControlPointsOfStudents>(query, parametrs).ToList();
            }
        }

        public static int GetIndexOfLastCP()
        {
            string query = "SELECT MAX(id) FROM controlPoints";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return connection.QueryFirst<int>(query);
            }
        }

        public static int InsertIntoCP(ControlPoints cpToIns)
        {
            string query = "INSERT INTO ControlPoints(id_of_teacher, id_of_discipline, weight, date, description) VALUES (@tid, @did, @weight, @date, @desc);";
            var parametrs = new DynamicParameters();
            parametrs.Add("@tid", cpToIns.id_of_teacher);
            parametrs.Add("@did", cpToIns.id_of_discipline);
            parametrs.Add("@weight", cpToIns.weight);
            parametrs.Add("@date", cpToIns.date);
            parametrs.Add("@desc", cpToIns.Description);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return connection.Execute(query, parametrs);
            }
        }
        public static int InsertIntoStCP(ControlPointsOfStudents cpToIns)
        {
            string query = "INSERT INTO cp_of_student(id_of_student, id_of_cp, points) VALUES (@sid, @cid, @points);";
            var parametrs = new DynamicParameters();
            parametrs.Add("@sid", cpToIns.id_of_student);
            parametrs.Add("@cid", cpToIns.id_of_cp);
            parametrs.Add("@points", cpToIns.points);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return connection.Execute(query, parametrs);
            }
        }
        
        public static int UpdateStCP(int points, int cpId)
        {
            string query = "UPDATE cp_of_student SET points = @points WHERE id = @id;";
            var parametrs = new DynamicParameters();
            parametrs.Add("@points", points);
            parametrs.Add("@id", cpId);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                return connection.Execute(query, parametrs);
            }
        }
    }
}
