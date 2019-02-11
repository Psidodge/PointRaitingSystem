using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib.DBServices;

namespace MainLib.Session
{
    public class CurrentSession
    {
        private static Session currentSession = null;
        private static object rootLock = new object();

        private CurrentSession() { }

        public static Session GetCurrentSession()
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
                currentSession = new Session(login);
        }
    }

    public class Session
    {
        private UserInfo currentSession;
        private string login;

        public Session(string _login)
        {
            login = _login;
            currentSession = DataService.SelectLoggedTeacher(login);
        }

        public int ID { get => currentSession.id; }
        public string UserLogin { get => login; }
        public string UserName { get => currentSession.Name; }
        public bool isAdmin { get => currentSession.isAdmin; }
    }
}
