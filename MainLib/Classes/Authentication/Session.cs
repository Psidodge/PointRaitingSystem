using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib.DBServices;

namespace MainLib.Session
{
    public class Session
    {
        private static SessionInfo currentSession = null;
        private static object rootLock = new object();

        private Session() { }

        public static SessionInfo GetCurrentSession()
        {
            lock(rootLock)
            {
                if (currentSession == null)
                    throw new NullReferenceException();

                return currentSession;
            }
        }

        public static void CreateSessionInstance(string login)
        {
            if(currentSession == null)
                currentSession = new SessionInfo(login);
        }


        public sealed class SessionInfo
        {
            private UserInfo currentSession;
            private string login;

            public SessionInfo(string _login)
            {
                login = _login;
                currentSession = DataService.SelectLoggedTeacher(login);
            }

            public UserInfo UserSession { get => currentSession; }
            public int ID { get => currentSession.id; }
            public string UserLogin { get => login; }
            public string UserName { get => currentSession.Name; }
            public bool isAdmin { get => currentSession.isAdmin; }
        }
    }
}
