using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;


namespace MainLib.DBServices
{
    //NOTE: Refactor this class later (rename method names)
    //TODO: Catch exception from caller
    public static class DataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        private static MySqlConnection OpenConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // SELECT
        public static AuthInfo SelectAuthInfoByLogin(string userLogin)
        {
            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@usrLogin", userLogin);

                return connection.QueryFirst<AuthInfo>("SelectAuthInfoByLogin", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        public static double GetSumOfPointsUsed(int groupID)
        {
            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@groupID", groupID);

                return connection.ExecuteScalar<double>("SelectSumOfGroupWeight", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        public static AuthInfoAdmin SelectAuthInfoByUserID(int usrID)
        {
            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@userID", usrID);

                return connection.QueryFirst<AuthInfoAdmin>("SelectAuthInfoByID", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        public static UserInfo SelectLoggedTeacher(string userLogin)
        {
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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

            using (MySqlConnection connection = OpenConnection())
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

            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
                    return connection.QueryFirst<int>("IdOfGroupByGroupName", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        public static bool isLoginExist(string login)
        {
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@userID", cpToIns.id_of_user);
                parameters.Add("@disID", cpToIns.id_of_discipline);
                parameters.Add("@weight", cpToIns.weight);
                parameters.Add("@description", cpToIns.Description);

                return connection.ExecuteScalar<int>("InsertIntoControlPoints", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int InsertIntoStudentCPTable(ControlPointsOfStudents cpToIns)
        {
            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@stID", cpToIns.id_of_student);
                parameters.Add("@cpID", cpToIns.id_of_controlPoint);
                parameters.Add("@points", cpToIns.points);
                //parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                return connection.ExecuteScalar<int>("InsertIntoStudentsControlPoints", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int InsertIntoTeacherDisciplines(int teacherId, int disciplineId)
        {
            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@disID", disciplineId);
                //parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                return connection.ExecuteScalar<int>("InsertIntoUserDisciplines", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int InsertIntoTeacherGroups(int teacherId, int groupId)
        {
            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@groupID", groupId);

                return connection.ExecuteScalar<int>("InsertIntoUserGroups", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int InsertIntoGroupDiscipline(int disciplineId, int groupId)
        {
            using (MySqlConnection connection = OpenConnection())
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

                return connection.ExecuteScalar<int>("InsertIntoGroupDiscipline", parameters,  commandType: CommandType.StoredProcedure);
            }
        }

        public static int InsertIntoAuthInfo(AuthInfoAdmin authInfo)
        {
            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@login", authInfo.login);
                parameters.Add("@passhash", authInfo.hash);
                parameters.Add("@salt", authInfo.salt);

                return connection.ExecuteScalar<int>("InsertIntoAuthInfo", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int InsertIntoStudentsTable(Student stToIns)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@stName", stToIns.name);
                parameters.Add("@groupID", stToIns.id_of_group);
                //parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                return connection.ExecuteScalar<int>("InsertIntoStudents", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int InsertIntoTeachersTable(UserInfo teacher)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            using (MySqlConnection connection = OpenConnection())
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

                return connection.ExecuteScalar<int>("InsertIntoUsers", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int InsertIntoGroupsTable(Group grToIns)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            
            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@grName", grToIns.name);
                parameters.Add("@grCourse", grToIns.course);

                return connection.ExecuteScalar<int>("InsertIntoGroups", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int InsertIntoDisciplinesTable(Discipline disciplineToIns)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@dName", disciplineToIns.name);
                parameters.Add("@dSem", disciplineToIns.semestr);
                //parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                return connection.ExecuteScalar<int>("InsertIntoDisciplines", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        // UPDATE
        public static int UpdateAuthInfo(AuthInfoAdmin authInfo)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@id", authInfo.id);
                parameters.Add("@hash", authInfo.hash);
                parameters.Add("@salt", authInfo.salt);

                return connection.ExecuteScalar<int>("UpdateAuthInfo", parameters,  commandType: CommandType.StoredProcedure);
            }
        }
        public static int UpdateStudents(Student student)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@stID", student.id);
                parameters.Add("@stName", student.name);
                parameters.Add("@stGroupID", student.id_of_group);

                return connection.ExecuteScalar<int>("UpdateStudents", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int UpdateTeachers(UserInfo teacher)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            using (MySqlConnection connection = OpenConnection())
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

                return connection.ExecuteScalar<int>("UpdateUsers", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int UpdateGroups(Group group)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@grID", group.id);
                parameters.Add("@grName", group.name);
                parameters.Add("@grCourse", group.course);

                return connection.ExecuteScalar<int>("UpdateGroups", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int UpdateDisciplines(Discipline discipline)
        {
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;

            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@dID", discipline.id);
                parameters.Add("@dName", discipline.name);
                parameters.Add("@dSemestr", discipline.semestr);

                return connection.ExecuteScalar<int>("UpdateDisciplines", parameters, commandType: CommandType.StoredProcedure);

            }
        }
        public static int UpdateStudentCP(int points, int cpId)
        {
            using (MySqlConnection connection = OpenConnection())
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
                parameters.Add("@points", points);
                parameters.Add("@cpID", cpId);

                return connection.ExecuteScalar<int>("UpdateStudentControlPoints", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
