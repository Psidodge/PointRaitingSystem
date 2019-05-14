//#undef DEBUG
using System;
using System.Collections.Generic;
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
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private static MySqlConnection GetConnectionInstance()
        {
            return new MySqlConnection(connectionString);
        }
        
        // SELECT 
        public static AuthInfo SelectAuthInfoByLogin(string userLogin)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static double GetSumOfPointsUsed(uint groupID, uint disID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@usrID", Session.Session.GetCurrentSession().ID);
                parameters.Add("@disID", disID);

                return connection.ExecuteScalar<double>("SelectSumOfGroupWeight", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        public static double GetSumOfMaxWeightsToCurrentCP(uint studentID, uint disciplineID, uint prevCPID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@stID", studentID);
                parameters.Add("@dID", disciplineID);
                parameters.Add("@endPointID", prevCPID);

                return connection.ExecuteScalar<double>("SelectWeightsOfStudentControlPoints", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        public static double GetStudentPointsSum(uint studentID, uint prevCPID, uint disciplineID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@studentID", studentID);
                parameters.Add("@endCPID", prevCPID);
                parameters.Add("@disciplineID", disciplineID);
                parameters.Add("@usrID", Session.Session.GetCurrentSession().ID);

                return connection.ExecuteScalar<double>("SelectSumOfStudentPoints", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        public static double GetMaxSumOfStudentPoints(uint studentID, uint disciplineID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@studentID", studentID);
                parameters.Add("@disID", disciplineID);

                return connection.ExecuteScalar<double>("SelectSumOfAllStudentPoints", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        public static double GetSumOfMaxWeights(uint studentID, uint disciplineID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@stID", studentID);
                parameters.Add("@dID", disciplineID);

                return connection.ExecuteScalar<double>("SelectMaxSumOfDisciplineCPWheights", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        public static AuthInfoAdmin SelectAuthInfoByUserID(uint usrID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static UserInfo SelectTeacherById(uint userId)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static ControlPoint SelectControlPointsInfoByStIdAndCpIndex(uint studentId, uint disciplineId, int cpIndex)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static Discipline SelectDisciplineById(uint id)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.QueryFirst<Discipline>("SelectDiscipline", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static ControlPointInfo SelectControlPointInfo(uint id)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static Group SelectGroupByID (uint groupID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.QueryFirst<Group>("SelectGroupByID", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        
        public static StudentReexam SelectReexamsByID(uint reexamID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@reexamID", reexamID);

                return connection.QueryFirst<StudentReexam>("SelectReexams", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static List<ControlPointTemplate> SelectUserControlPointsTemplate(uint disciplineID, uint userID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@userID", userID);
                parameters.Add("@disciplineID", disciplineID);

                return connection.Query<ControlPointTemplate>("SelectCPTemplates", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<StudentCertification> SelectStudentCertifications(uint groupID, uint disciplineID, uint studentID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@disciplineID", disciplineID);
                
                var results = connection.Query<StudentCertification>("SelectStudentsCertifications", parameters, commandType: CommandType.StoredProcedure).ToList();

                return (from result in results
                        where result.id_of_student == studentID
                        select result).ToList();
            }
        }
        public static List<StudentCertification> SelectStudentsCertifications(uint groupID, uint disciplineID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@disciplineID", disciplineID);

                return connection.Query<StudentCertification>("SelectStudentsCertifications", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<StudentCertification> SelectStudentsCertificationsByDate(uint groupID, uint disciplineID, DateTime date)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@disciplineID", disciplineID);

                var results = connection.Query<StudentCertification>("SelectStudentsCertifications", parameters, commandType: CommandType.StoredProcedure).ToList();

                return (from result in results
                        where result.date == date
                        select result).ToList();
            }
        }
        public static List<UserFullInfo> SelectUsersFullInfo()
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static List<Group> SelectGroupsByTeacherId(uint userId)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static List<Discipline> SelectDisciplinesByTeacherIdAndGroupId(uint teacherId, uint groupId)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static List<Discipline> SelectDisciplinesByTeacherID(uint id)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static List<Student> SelectStudentsByGroupId(uint groupId)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static List<StudentExam> SelectStudentsExams(uint groupID, uint disciplineID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("groupID", groupID);
                parameters.Add("@disID", disciplineID);

                return connection.Query<StudentExam>("SelectAllExams", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public static List<ControlPoint> SelectControlPointsByDisciplineId(uint id)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        //public static List<ControlPointsOfStudents> SelectStudentControPoints(int stId, int cpId)
        //{
        //    using (MySqlConnection connection = GetConnectionInstance())
        //    {
        //        try
        //        {
        //            if (connection.State != ConnectionState.Open)
        //                connection.Open();
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }

        //        var parameters = new DynamicParameters();
        //        parameters.Add("@stID", stId);
        //        parameters.Add("@dID", cpId);

        //        return connection.Query<ControlPointsOfStudents>("SelectStudentControlPoints", parameters, commandType: CommandType.StoredProcedure).ToList();
        //    }
        //}
        public static List<StudentControlPoint> SelectStudentControPointsGroupDisc(uint grId, uint discId, uint teacherID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@usrID", teacherID);

                return connection.Query<StudentControlPoint>("SelectStudentControlPointsInfos", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static List<UserInfo> SelectAllUsers()
        {
#if !DEBUG
            //NOTE: Если пользователь не админ, то не выполняем, нужно как-то это сообщить пользователю
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return null;
#endif
            using (MySqlConnection connection = GetConnectionInstance())
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
#if !DEBUG
            //NOTE: Если пользователь не админ, то не выполняем, нужно как-то это сообщить пользователю
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return null;
#endif
            using (MySqlConnection connection = GetConnectionInstance())
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
            using (MySqlConnection connection = GetConnectionInstance())
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
            using (MySqlConnection connection = GetConnectionInstance())
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

        public static int GetIndexOfLastControlPoint()
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static uint GetIdOfGroupByGroupName(string groupName)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                    return connection.QueryFirst<uint>("IdOfGroupByGroupName", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        public static bool isLoginExist(string login)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static bool isTeacherDiscipline(uint disciplineId, uint teacherId, uint groupID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@groupID", groupID);

                return connection.QueryFirst<bool>("IsTeacherDiscipline", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static bool isGroupDiscipline(uint disciplineId, uint groupId)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static bool isGroupExist(out uint groupId, string groupName)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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

                groupId = connection.QueryFirst<uint>("IsGroupExists", parameters, commandType: CommandType.StoredProcedure);

                if(groupId == 0)
                    return false;
                return true;
            }
        }

        // INSERT
        public static uint InsertIntoControlPointTemplateTable(ControlPointTemplate template)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@userID", template.id_of_user);
                parameters.Add("@disciplineID", template.id_of_discipline);
                parameters.Add("@weight", template.weight);
                parameters.Add("@description", template.description);

                return connection.ExecuteScalar<uint>("InsertIntoCPTemplates", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static uint InsertIntoControlPointsTable(ControlPoint cpToIns)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.ExecuteScalar<uint>("InsertIntoControlPoints", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static uint InsertIntoStudentCPTable(ControlPointsOfStudents cpToIns)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.ExecuteScalar<uint>("InsertIntoStudentsControlPoints", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static bool InsertIntoCPnStCPFromCPTemplateTransact(ref List<ControlPoint> points, List<Student> students)
        {
            using (MySqlConnection connection = GetConnectionInstance())
            {
                DynamicParameters parameters;
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (ControlPoint point in points)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add("@userID", point.id_of_user);
                            parameters.Add("@disID", point.id_of_discipline);
                            parameters.Add("@weight", point.weight);
                            parameters.Add("@description", point.Description);

                            point.id = connection.ExecuteScalar<uint>("InsertIntoControlPoints", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        logger.Error(ex);
                        return false;
                    }
                }

                try
                {
                    foreach (ControlPoint point in points)
                    {
                        foreach (Student student in students)
                        {
                            InsertIntoStudentCPTable(new ControlPointsOfStudents
                            {
                                id_of_controlPoint = point.id,
                                id_of_student = student.id,
                                points = 0
                            });
                        }
                    }
                }
                catch(Exception ex)
                {
                    logger.Error(ex);
                    return false;
                }
                return true;
            }
        }
        public static uint InsertIntoStudentCertification(StudentCertification certificationToIns)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@studentID", certificationToIns.id_of_student);
                parameters.Add("@stGrade", certificationToIns.grade);
                parameters.Add("@certDate", certificationToIns.date);
                parameters.Add("@prevCPID", certificationToIns.id_of_prev_cp);
                parameters.Add("@disciplineID", certificationToIns.id_of_discipline);
                parameters.Add("@userID", certificationToIns.id_of_user);
                parameters.Add("@studentScore", certificationToIns.sum_of_points);

                return connection.ExecuteScalar<uint>("InsertIntoStudentCertification", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static uint InsertIntoTeacherDisciplines(uint teacherId, uint disciplineId, uint groupID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@groupID", groupID);
                //parameters.Add(name: "@returnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                return connection.ExecuteScalar<uint>("InsertIntoUserDisciplines", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static uint InsertIntoTeacherGroups(uint teacherId, uint groupId)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.ExecuteScalar<uint>("InsertIntoUserGroups", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static uint InsertIntoGroupDiscipline(uint disciplineId, uint groupId)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.ExecuteScalar<uint>("InsertIntoGroupDiscipline", parameters,  commandType: CommandType.StoredProcedure);
            }
        }
        public static bool InsertIntoStudentExam(List<StudentExam> exams)
        {
            using (MySqlConnection connection = GetConnectionInstance())
            {
                DynamicParameters parameters;
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }
                uint tempReexamsID = 0;
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (StudentExam exam in exams)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add("@studentID", exam.id_of_student);
                            parameters.Add("@disciplineID", exam.id_of_discipline);
                            parameters.Add("@userID", exam.id_of_user);
                            parameters.Add("@examDate", exam.date);
                            parameters.Add("@examPoints", exam.points);
                            parameters.Add("@examGrade", exam.grade);
                            if (exam.points == 0)
                            {
                                tempReexamsID = CreateNewReexamRow(connection, transaction);
                                parameters.Add("@reexamID", tempReexamsID);
                            }
                            else
                                parameters.Add("@reexamID", null);
                            connection.ExecuteScalar<uint>("InsertIntoExams", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        logger.Error(ex);
                        return false;
                    }
                }
                return true;
            }
        }

        public static uint CreateNewReexamRow(MySqlConnection connection, MySqlTransaction transaction)
        {
            return connection.ExecuteScalar<uint>("InsertIntoReexam", commandType: CommandType.StoredProcedure, transaction: transaction);
        }
        public static uint InsertIntoAuthInfo(AuthInfoAdmin authInfo)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.ExecuteScalar<uint>("InsertIntoAuthInfo", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static uint InsertIntoStudentsTable(Student stToIns)
        {
#if !DEBUG
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;
#endif
            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.ExecuteScalar<uint>("InsertIntoStudents", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static uint InsertIntoTeachersTable(UserInfo teacher)
        {
#if !DEBUG
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;
#endif
            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.ExecuteScalar<uint>("InsertIntoUsers", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static uint InsertIntoGroupsTable(Group grToIns)
        {
#if !DEBUG
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;
#endif

            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.ExecuteScalar<uint>("InsertIntoGroups", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static uint InsertIntoDisciplinesTable(Discipline disciplineToIns)
        {
#if !DEBUG
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;
#endif

            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.ExecuteScalar<uint>("InsertIntoDisciplines", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        // UPDATE 
        public static int UpdateAuthInfo(AuthInfoAdmin authInfo)
        {
#if !DEBUG
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;
#endif
            using (MySqlConnection connection = GetConnectionInstance())
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

                return connection.ExecuteScalar<int>("UpdateAuthInfo", authInfo,  commandType: CommandType.StoredProcedure);
            }
        }
        public static int UpdateStudents(Student student)
        {
#if !DEBUG
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;
#endif
            using (MySqlConnection connection = GetConnectionInstance())
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
#if !DEBUG
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;
#endif
            using (MySqlConnection connection = GetConnectionInstance())
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
#if !DEBUG
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;
#endif
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static int UpdateCPDescription(string description, uint cpID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@descriptionText", description);
                parameters.Add("@cpID", cpID);

                return connection.ExecuteScalar<int>("UpdateCPDescription", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int UpdateDisciplines(Discipline discipline)
        {
#if !DEBUG
            if (!SelectTeacherById(Session.Session.GetCurrentSession().ID).isAdmin)
                return -1;
#endif
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static int UpdateStudentCP(double points, uint cpId)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
        public static bool UpdateStudentReexamTransact(List<StudentReexam> reexams)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                DynamicParameters parameters = null;

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var reexam in reexams)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add("@reexamID", reexam.id);
                            parameters.Add("@reexamPoints", reexam.points);
                            parameters.Add("@reexamGrade", reexam.grade);
                            parameters.Add("@reexamDate", reexam.date);

                            if (connection.ExecuteScalar<int>("UpdateStudentReexam", parameters, commandType: CommandType.StoredProcedure, transaction: transaction) == 0)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        logger.Error(ex);
                    }
                }
            }
            return true;
        }
        //public static int UpdateStudentExamsResults(StudentExam exam)
        //{
        //    using (MySqlConnection connection = GetConnectionInstance())
        //    {
        //        try
        //        {
        //            if (connection.State != ConnectionState.Open)
        //                connection.Open();
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }

        //        var parameters = new DynamicParameters();
        //        parameters.Add("@examID", exam.id);
        //        parameters.Add("@examPoints", exam.points);
        //        parameters.Add("@examGrade", exam.grade);
        //        parameters.Add("@reexamID", exam.id_of_reexam);

        //        return connection.ExecuteScalar<int>("UpdateExamStudentPoints", parameters, commandType: CommandType.StoredProcedure);
        //    }
        //}

        // DELETE
        public static bool DeleteCPTemplate(uint templateID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@templateID", templateID);
                return connection.Execute("DeleteCPTemplate", parameters, commandType: CommandType.StoredProcedure) > 0 ? true : false;
            }
        }
        public static bool DeleteDisciplineBinding(uint disciplineID, uint userID, uint groupID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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
                parameters.Add("@disciplineID", disciplineID);
                parameters.Add("@userID", userID);
                parameters.Add("@groupID", groupID);

                return connection.Execute("DeletFromUserDisciplines", parameters, commandType: CommandType.StoredProcedure) > 0 ? true : false;
            }
        }
        public static bool DeleteGroupBindingsTransact(List<Discipline> disciplines, uint userID, uint groupID)
        {
            using (MySqlConnection connection = GetConnectionInstance())
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

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        foreach (Discipline discipline in disciplines)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add("@disciplineID", discipline.id);
                            parameters.Add("@userID", userID);
                            parameters.Add("@groupID", groupID);

                            connection.Execute("DeleteFromUserDisciplines", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);
                        }

                        parameters = new DynamicParameters();
                        parameters.Add("@groupID", groupID);
                        parameters.Add("@userID", userID);

                        connection.Execute("DeleteFromUserGroups", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        logger.Error(ex);
                        return false;
                    }
                }
            }
        }
    }
}
