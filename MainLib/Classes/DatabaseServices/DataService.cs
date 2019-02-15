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

        // SELECT
        public static List<AuthInfo> SelectAuthInfoByLogin(string userLogin)
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

                return connection.Query<AuthInfo>(query, new { login = userLogin }).ToList();
            }
        }
        public static UserInfo SelectLoggedTeacher(string userLogin)
        {
            string query = "SELECT t.id, t.[name], t.isAdmin FROM users as t " +
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

                return connection.QueryFirst<UserInfo>(query, parametrs);
            }
        }
        public static UserInfo SelectTeacherById(int userId)
        {
            string query = "SELECT id, [name], isAdmin FROM users WHERE id = @id";

            var parametrs = new DynamicParameters();
            parametrs.Add("@id", userId);

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

                return connection.QueryFirst<UserInfo>(query, parametrs);
            }
        }
        public static List<Group> SelectGroupsByTeacherId(int userId)
        {
            string query = "SELECT gr.* from groups as gr " +
                           "INNER JOIN teacher_groups as tgr on gr.id = tgr.id_of_group " +
                           "INNER JOIN users as t on tgr.id_of_teacher = t.id " +
                           "WHERE t.id = @id";

            var parametrs = new DynamicParameters();
            parametrs.Add("@id", userId);

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

        public static List<TeacherInfo> SelectAllTeachersInfo()
        {
            //NOTE: Если пользователь не админ, то не выполняем, нужно как-то это сообщить пользователю
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return null;

            string query = "SELECT usr.id, usr.name, ai.[login], usr.isAdmin, usr.id_of_authInfo FROM users AS usr " +
                           "INNER JOIN authInfo AS ai ON ai.id = usr.id_of_authInfo";

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

                return connection.Query<TeacherInfo>(query).ToList();
            }
        }
        public static List<StudentInfo> SelectAllStudentsInfo()
        {
            //NOTE: Если пользователь не админ, то не выполняем, нужно как-то это сообщить пользователю
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return null;

            string query = "SELECT st.id, st.name, gr.group_name FROM dbo.students AS st " +
                           "INNER JOIN dbo.groups AS gr ON gr.id = st.id_of_group";

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

                return connection.Query<StudentInfo>(query).ToList();
            }
        }
        public static List<DisciplineInfo> SelectAllDisciplinesInfo()
        {
            string query = "SELECT id, discipline_name, semestr FROM disciplines";

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

                return connection.Query<DisciplineInfo>(query).ToList();
            }
        }
        public static List<GroupInfo> SelectAllGroupsInfo()
        {
            string query = "SELECT id, group_name, group_course FROM groups";

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

                return connection.Query<GroupInfo>(query).ToList();
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
        public static int GetIdOfGroupByGroupName(string groupName)
        {
            string query = "SELECT id FROM groups WHERE group_name = @grName";

            var parametrs = new DynamicParameters();
            parametrs.Add("@grName", groupName);

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

                return connection.QueryFirst<int>(query, parametrs);
            }
        }
        public static bool isLoginExist(string login)
        {
            string query = "SELECT Count(*) FROM authInfo WHERE login = @login";

            var parametrs = new DynamicParameters();
            parametrs.Add("@login", login);

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

                return (connection.QueryFirst<int>(query, parametrs) > 0 ? true : false);
            }
        }
        public static bool isTeacherDiscipline(int disciplineId, int teacherId)
        {
            string query =  "SELECT d.* from disciplines as d " +
                            "INNER JOIN teacher_disciplines as td on td.id_of_discipline = d.id " +
                            "WHERE td.id_of_teacher = @tId AND d.id = @dId";

            var parametrs = new DynamicParameters();
            parametrs.Add("@tId", teacherId);
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

                return connection.Query<Discipline>(query, parametrs).Count() != 0;
            }
        }
        public static bool isGroupDiscipline(int disciplineId, int groupId)
        {
            string query =  "SELECT * FROM group_disciplines " +
                            "WHERE id_of_discipline = @dId AND id_of_group = @grId";

            var parametrs = new DynamicParameters();
            parametrs.Add("@dId", disciplineId);
            parametrs.Add("@grId", groupId);
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

                return connection.Query<Discipline>(query, parametrs).Count() != 0;
            }
        }
        public static bool isGroupExist(out int groupId, string groupName)
        {
            string query = "SELECT id FROM groups " +
                            "WHERE group_name = @grName";

            var parametrs = new DynamicParameters();
            parametrs.Add("@grName", groupName);
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
                groupId = connection.QueryFirst<int>(query, parametrs);
                if(groupId == 0)
                    return false;
                return true;
            }
        }

        // INSERT
        public static int InsertIntoControlPointsTable(ControlPoint cpToIns)
        {
            string query = "INSERT INTO ControlPoints(id_of_teacher, id_of_discipline, weight, description) VALUES (@tid, @did, @weight, @desc);";

            var parametrs = new DynamicParameters();
            parametrs.Add("@tid", cpToIns.id_of_teacher);
            parametrs.Add("@did", cpToIns.id_of_discipline);
            parametrs.Add("@weight", cpToIns.weight);
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
        public static int InsertIntoTeacherDisciplines(int teacherId, int disciplineId)
        {
            string query = "INSERT INTO teacher_disciplines(id_of_teacher, id_of_discipline) VALUES (@tID, @disID)";
            var parametrs = new DynamicParameters();
            parametrs.Add("@tID", teacherId);
            parametrs.Add("@disID", disciplineId);

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
        public static int InsertIntoTeacherGroups(int teacherId, int groupId)
        {
            string query = "INSERT INTO teacher_groups(id_of_teacher, id_of_group) VALUES (@tID, @grID)";
            var parametrs = new DynamicParameters();
            parametrs.Add("@tID", teacherId);
            parametrs.Add("@grID", groupId);

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
        public static int InsertIntoGroupDiscipline(int disciplineId, int groupId)
        {
            string query = "INSERT INTO group_disciplines(id_of_discipline, id_of_group) VALUES (@dID, @grID)";
            var parametrs = new DynamicParameters();
            parametrs.Add("@dID", disciplineId);
            parametrs.Add("@grID", groupId);

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

        public static int InsertIntoStudentsTable(Student stToIns)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            string query = "INSERT INTO students(name, id_of_group) VALUES (@sName, @grId);";
            var parametrs = new DynamicParameters();
            parametrs.Add("@sName", stToIns.name);
            parametrs.Add("@grId", stToIns.id_of_group);

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
        //NOTE: To remake, possibly works wrong
        public static int InsertIntoTeachersTable(TeacherInfo userToInsert, AuthInfoAdmin authInfo)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

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
                string query =  "INSERT INTO authInfo(login, pass_hash, salt) VALUES (@login, @hash, @salt)";
                var parametrs = new DynamicParameters();
                parametrs.Add("@login", authInfo.login);
                parametrs.Add("@hash", authInfo.Pass_hash);
                parametrs.Add("@salt", authInfo.Salt);

                connection.Execute(query, parametrs);

                int authInfoId = connection.QueryFirst<int>("SELECT MAX(id) FROM authInfo");

                query = "INSERT INTO users(name, id_of_authInfo, isAdmin) VALUES (@tName, @aiId, @isAdm);";
                parametrs = new DynamicParameters();
                parametrs.Add("@tName", userToInsert.Name);
                parametrs.Add("@aiId", authInfoId);
                parametrs.Add("@isAdm", userToInsert.isAdmin);


                return connection.Execute(query, parametrs);
            }
        }
        public static int InsertIntoGroupsTable(Group grToIns)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            string query = "INSERT INTO groups(group_name, group_course) VALUES (@grName, @grCourse);";
            var parametrs = new DynamicParameters();
            parametrs.Add("@grName", grToIns.group_name);
            parametrs.Add("@grCourse", grToIns.group_course);

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
        public static int InsertIntoDisciplinesTable(Discipline disciplineToIns)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            string query = "INSERT INTO disciplines(discipline_name, semestr) VALUES (@dName, @dSem);";
            var parametrs = new DynamicParameters();
            parametrs.Add("@dName", disciplineToIns.discipline_name);
            parametrs.Add("@dSem", disciplineToIns.semestr);

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

        // UPDATE
        public static int UpdateStudents(Student stToUpd)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            string query = "UPDATE students SET name = @sName, id_of_group = @grId WHERE id = @id;";
            var parametrs = new DynamicParameters();
            parametrs.Add("@id", stToUpd.id);
            parametrs.Add("@sName", stToUpd.name);
            parametrs.Add("@grId", stToUpd.id_of_group);

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
        //NOTE: возможность изменять аут. данные есть, но она не используется
        public static int UpdateTeachers(TeacherInfo usrToUpdate, AuthInfoAdmin authInfo = null)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

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

                string query;
                var parametrs = new DynamicParameters();

                if (authInfo != null && usrToUpdate.id_of_authInfo != 0)
                {
                    query = "UPDATE authInfo SET login = @login, pass_hash = @hash, salt = @salt WHERE id = @id;";
                    parametrs.Add("@login", authInfo.login);
                    parametrs.Add("@hash", authInfo.Pass_hash);
                    parametrs.Add("@salt", authInfo.Salt);
                    parametrs.Add("@id", usrToUpdate.id_of_authInfo);
                    connection.Execute(query, parametrs);
                }

                query = "UPDATE users SET name = @tName, isAdmin = @isAdm, id_of_authInfo = @authId WHERE id = @id";
                parametrs = new DynamicParameters();
                parametrs.Add("@id", usrToUpdate.id);
                parametrs.Add("@tName", usrToUpdate.Name);
                parametrs.Add("@isAdm", usrToUpdate.isAdmin);
                parametrs.Add("@authId", usrToUpdate.id_of_authInfo);

                return connection.Execute(query, parametrs);
            }
        }
        public static int UpdateGroups(Group grToUpd)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            string query = "UPDATE groups SET group_name = @grName, group_course = @grCourse WHERE id = @id;";
            var parametrs = new DynamicParameters();
            parametrs.Add("@id", grToUpd.id);
            parametrs.Add("@grName", grToUpd.group_name);
            parametrs.Add("@grCourse", grToUpd.group_course);

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
        public static int UpdateDisciplines(Discipline disciplineToUpd)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            string query = "UPDATE disciplines SET discipline_name = @dName, semestr = @dSemestr WHERE id = @id;";
            var parametrs = new DynamicParameters();
            parametrs.Add("@id", disciplineToUpd.id);
            parametrs.Add("@dName", disciplineToUpd.discipline_name);
            parametrs.Add("@dSemestr", disciplineToUpd.semestr);

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
