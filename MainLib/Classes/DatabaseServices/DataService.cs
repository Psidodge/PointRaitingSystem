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
    //NOTE: Refactor this class later (rename method names)
    //TODO: Catch exception from caller
    public static class DataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["cp_dbConnectionString"].ConnectionString;


        public static List<TeacherAuthInfo> SelectAuthInfoByLogin(string userLogin)
        {
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
                    throw e;
                }

                return connection.Query<TeacherAuthInfo>(query, new { login = userLogin }).ToList();
            }
        }
        public static TeacherInfo SelectLoggedTeacher(string userLogin)
        {
            string query =  "SELECT t.id, t.[name] FROM teachers as t " +
                            "INNER JOIN authInfo AS ai ON t.id_of_authInfo = ai.id " +
                            "WHERE ai.login = @login";

            var parametrs = new DynamicParameters();
            parametrs.Add("@login", userLogin);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch(Exception e)
                {
                    throw e;
                }

                return connection.QueryFirst<TeacherInfo>(query, parametrs);
            }
        }
        public static TeacherInfo SelectTeacherById(int id)
        {
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
                    throw e;
                }

                return connection.QueryFirst<TeacherInfo>(query, parametrs);
            }
        }
        public static List<Group> SelectGroupsByTeacherId(int id)
        {
            string query = "SELECT gr.* from groups as gr " +
                           "INNER JOIN teacher_groups as tgr on gr.id = tgr.id_of_group " +
                           "INNER JOIN teachers as t on tgr.id_of_teacher = t.id " +
                           "WHERE t.id = @id";

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

                return connection.Query<Group>(query, parametrs).ToList();
            }
        }
        public static List<Discipline> SelectDisciplinesByTeacherIdAndGroupId(int teacherId, int groupId)
        {
            string query = "SELECT d.* from disciplines as d " +
                           "INNER JOIN group_disciplines as grd on grd.id_of_discipline = d.id " +
                           "INNER JOIN teacher_disciplines as td on td.id_of_discipline = d.id " +
                           "WHERE grd.id_of_group = @groupId AND td.id_of_teacher = @teacherId";

            var parametrs = new DynamicParameters();
            parametrs.Add("@teacherId", teacherId);
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

                return connection.Query<Discipline>(query, parametrs).ToList();
            }
        }
        public static List<Discipline> SelectDisciplinesByTeacherID(int id)
        {
            string query = "SELECT d.* from disciplines as d " +
                           "INNER JOIN teacher_disciplines as td on td.id_of_discipline = d.id " +
                           "WHERE td.id_of_teacher = @id";

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

                return connection.Query<Discipline>(query, parametrs).ToList();
            }
        }
        public static List<Student> SelectStudentsByGroupId(int groupId)
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

                return connection.Query<Student>(query, parametrs).ToList();
            }
        }
        public static List<ControlPoint> SelectControlPointsByDisciplineId(int id)
        {
            string query = "SELECT * FROM controlPoints WHERE id_of_discipline = @id";

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

                return connection.Query<ControlPoint>(query, parametrs).ToList();
            }
        }
        public static ControlPoint SelectControlPointsInfoByStIdAndCpIndex(int studentId, int disciplineId, int cpIndex)
        {
            string query =  "SELECT CP.* FROM dbo.controlPoints as CP " +
                            "INNER JOIN dbo.cp_of_student as CPS on cps.id_of_cp = cp.id " +
                            "WHERE cps.id_of_student = @sId AND cp.id_of_discipline = @dId";

            var parametrs = new DynamicParameters();
            parametrs.Add("@sId", studentId);
            parametrs.Add("@dId", disciplineId);

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

                List<ControlPoint> cps = connection.Query<ControlPoint>(query, parametrs).ToList();
                if(cps.Count == 0)
                    return null;
                return cps[cpIndex];
            }
        }
        public static Discipline SelectDisciplineById(int id)
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

                return connection.QueryFirst<Discipline>(query, parametrs);
            }
        }
        public static List<ControlPointsOfStudents> SelectStudentControPoints(int stId, int cpId)
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

        public static int GetIndexOfLastControlPoint()
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

        public static int InsertIntoControlPointsTable(ControlPoint cpToIns)
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
        public static int InsertIntoStudentCPTable(ControlPointsOfStudents cpToIns)
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
        
        public static int UpdateStudentCP(int points, int cpId)
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
