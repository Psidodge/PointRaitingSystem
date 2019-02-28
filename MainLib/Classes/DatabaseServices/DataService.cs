using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Linq;
using System.Data;

namespace MainLib.DBServices
{
    //NOTE: Refactor this class later (rename method names)
    //TODO: Catch exception from caller
    public static class DataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        // SELECT
        public static AuthInfo SelectAuthInfoByLogin(string userLogin)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@login", userLogin);

                return connection.QueryFirst<AuthInfo>("SelectAuthInfoByLogin", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        public static AuthInfoAdmin SelectAuthInfoByID(int usrID)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@usrID", usrID);

                return connection.QueryFirst<AuthInfoAdmin>("SelectAuthInfoByID", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        public static UserInfo SelectLoggedTeacher(string userLogin)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@login", userLogin);

                return connection.QueryFirst<UserInfo>("SelectLoggedUser", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static UserInfo SelectTeacherById(int userId)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@id", userId);

                return connection.QueryFirst<UserInfo>("SelectUser", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static ControlPoint SelectControlPointsInfoByStIdAndCpIndex(int studentId, int disciplineId, int cpIndex)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@stID", studentId);
                parameters.Add("@dID", disciplineId);

                List<ControlPoint> cps = connection.Query<ControlPoint>("SelectControlPoint", parameters, commandType: CommandType.StoredProcedure).ToList();
                if (cps.Count == 0)
                    return null;
                return cps[cpIndex];
            }
        }
        public static Discipline SelectDisciplineById(int id)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@dID", id);

                return connection.QueryFirst<Discipline>("SelectDiscipline", commandType: CommandType.StoredProcedure);
            }
        }
        //NOTE: Test method
        public static List<UserFullInfo> SelectUsersFullInfo()
        {
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

                return connection.Query<UserFullInfo>("SelectUsersFullInfo", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<Group> SelectGroupsByTeacherId(int userId)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@id", userId);

                return connection.Query<Group>("SelectUserGroups", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<Discipline> SelectDisciplinesByTeacherIdAndGroupId(int teacherId, int groupId)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@usrID", teacherId);
                parameters.Add("@grID", groupId);

                return connection.Query<Discipline>("SelectGroupDisciplines", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<Discipline> SelectDisciplinesByTeacherID(int id)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@usrID", id);

                return connection.Query<Discipline>("SelectUserDisciplines", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<Student> SelectStudentsByGroupId(int groupId)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@grID", groupId);

                return connection.Query<Student>("SelectGroupStudents", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<ControlPoint> SelectControlPointsByDisciplineId(int id)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@dID", id);

                return connection.Query<ControlPoint>("SelectDisciplineControlPoints", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<ControlPointsOfStudents> SelectStudentControPoints(int stId, int cpId)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@stID", stId);
                parameters.Add("@dID", cpId);

                return connection.Query<ControlPointsOfStudents>("SelectStudentControlPoints", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<StudentControlPoint> SelectStudentControPointsGroupDisc(int grId, int discId)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@grId", grId);
                parameters.Add("@dId", discId);

                return connection.Query<StudentControlPoint>("SelectStudentControlPointsInfos", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static List<UserInfo> SelectAllUsers()
        {
            //NOTE: Если пользователь не админ, то не выполняем, нужно как-то это сообщить пользователю
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return null;

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

                return connection.Query<UserInfo>("SelectUsersInfo", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<StudentInfo> SelectAllStudentsInfo()
        {
            //NOTE: Если пользователь не админ, то не выполняем, нужно как-то это сообщить пользователю
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return null;

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

                return connection.Query<StudentInfo>("SelectStudentsInfo", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<DisciplineInfo> SelectAllDisciplinesInfo()
        {
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

                return connection.Query<DisciplineInfo>("SelectDisciplinesInfo", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<GroupInfo> SelectAllGroupsInfo()
        {
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

                return connection.Query<GroupInfo>("SelectGroupsInfo", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static ControlPointInfo SelectControlPointInfo(int id)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@cpID", id);

                return connection.QueryFirst<ControlPointInfo>("SelectControlPointInfo", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public static int GetIndexOfLastControlPoint()
        {
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

                return connection.QueryFirst<int>("IdOfLastCP", commandType: CommandType.StoredProcedure);
            }
        }
        public static int GetIdOfGroupByGroupName(string groupName)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@groupName", groupName);

                try
                {
                    return connection.QueryFirst<int>("IdOfGroupByGroupName", commandType: CommandType.StoredProcedure);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        public static bool isLoginExist(string login)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@login", login);

                return connection.QueryFirst<bool>("IsLoginExists", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static bool isTeacherDiscipline(int disciplineId, int teacherId)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@userID", teacherId);
                parameters.Add("@dID", disciplineId);

                return connection.QueryFirst<bool>("IsTeacherDiscipline", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static bool isGroupDiscipline(int disciplineId, int groupId)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@dID", disciplineId);
                parameters.Add("@groupID", groupId);

                return connection.QueryFirst<bool>("IsGroupDiscipline", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static bool isGroupExist(out int groupId, string groupName)
        {
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

                var parameters = new DynamicParameters();
                parameters.Add("@groupName", groupName);

                groupId = connection.QueryFirst<int>("IsGroupExists", parameters, commandType: CommandType.StoredProcedure);

                if(groupId == -1)
                    return false;
                return true;
            }
        }

        // INSERT
        public static int InsertIntoControlPointsTable(ControlPoint cpToIns)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userID", cpToIns.id_of_user);
            parameters.Add("@disID", cpToIns.id_of_discipline);
            parameters.Add("@weight", cpToIns.weight);
            parameters.Add("@desc", cpToIns.Description);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("InsertIntoControlPoints", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int InsertIntoStudentCPTable(ControlPointsOfStudents cpToIns)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@stID", cpToIns.id_of_student);
            parameters.Add("@cpID", cpToIns.id_of_controlPoint);
            parameters.Add("@points", cpToIns.points);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("InsertIntoStudentsControlPoints", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int InsertIntoTeacherDisciplines(int teacherId, int disciplineId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userID", teacherId);
            parameters.Add("@disID", disciplineId);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("InsertIntoUserDisciplines", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int InsertIntoTeacherGroups(int teacherId, int groupId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userID", teacherId);
            parameters.Add("@groupID", groupId);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("InsertIntoUserGroups", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int InsertIntoGroupDiscipline(int disciplineId, int groupId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@dID", disciplineId);
            parameters.Add("@groupID", groupId);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("InsertIntoGroupDiscipline", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }

        public static int InsertIntoAuthInfo(AuthInfoAdmin authInfo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@login", authInfo.login);
            parameters.Add("@hash", authInfo.hash);
            parameters.Add("@salt", authInfo.salt);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("InsertIntoAuthInfo", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int InsertIntoStudentsTable(Student stToIns)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            var parameters = new DynamicParameters();
            parameters.Add("@stName", stToIns.name);
            parameters.Add("@groupID", stToIns.id_of_group);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("InsertIntoStudents", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int InsertIntoTeachersTable(UserInfo teacher)
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

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@usrName", teacher.Name);
                parameters.Add("@usrPrivileges", teacher.isAdmin);
                parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                connection.Execute("InsertIntoUsers", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int InsertIntoGroupsTable(Group grToIns)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            var parameters = new DynamicParameters();
            parameters.Add("@grName", grToIns.name);
            parameters.Add("@grCourse", grToIns.course);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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
                connection.Execute("InsertIntoGroups", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int InsertIntoDisciplinesTable(Discipline disciplineToIns)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            var parameters = new DynamicParameters();
            parameters.Add("@dName", disciplineToIns.name);
            parameters.Add("@dSem", disciplineToIns.semestr);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("InsertIntoDisciplines", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }

        // UPDATE
        public static int UpdateAuthInfo(AuthInfoAdmin authInfo)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            var parameters = new DynamicParameters();
            parameters.Add("@id", authInfo.id);
            parameters.Add("@hash", authInfo.hash);
            parameters.Add("@salt", authInfo.salt);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("UpdateAuthInfo", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int UpdateStudents(Student student)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            var parameters = new DynamicParameters();
            parameters.Add("@stID", student.id);
            parameters.Add("@stName", student.name);
            parameters.Add("@stGroupID", student.id_of_group);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("UpdateStudents", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int UpdateTeachers(UserInfo teacher)
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

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@usrID", teacher.id);
                parameters.Add("@authID", teacher.authID);
                parameters.Add("@usrName", teacher.Name);
                parameters.Add("@usrPrivileges", teacher.isAdmin);
                parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                connection.Execute("UpdateUsers", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int UpdateGroups(Group group)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            var parameters = new DynamicParameters();
            parameters.Add("@grID", group.id);
            parameters.Add("@grName", group.name);
            parameters.Add("@grCourse", group.course);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("UpdateGroups", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int UpdateDisciplines(Discipline discipline)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            var parameters = new DynamicParameters();
            parameters.Add("@dID", discipline.id);
            parameters.Add("@dName", discipline.name);
            parameters.Add("@dSemestr", discipline.semestr);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("UpdateDisciplines", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
        public static int UpdateStudentCP(int points, int cpId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@points", points);
            parameters.Add("@cpID", cpId);
            parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

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

                connection.Execute("UpdateStudentControlPoints", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@returnValue");
            }
        }
    }
}
