using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TestBDMessenger;

namespace ServiceClassMessenger
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceMessenger : IServiceMessenger
    {
        List<ServeUser> _users = new List<ServeUser>();
        public int Autoriz(string email, string password)
        {
            using (MessengerDTEntities2 db = new MessengerDTEntities2())
            {
                var userFromDb = db.users.FirstOrDefault(u => u.email == email && u.password_hash == password);

                if (userFromDb != null)
                {

                    ServeUser serveUser = new ServeUser(userFromDb)
                    {
                        operationContext = OperationContext.Current
                    };
                    return serveUser.ID;
                }
                else
                {
                    return -1;
                }
            }
        }

        public void Disconnect(int id)
        {
            using (MessengerDTEntities2 db = new MessengerDTEntities2())
            {
                users userFromDb = db.users.FirstOrDefault(u => u.user_id == id);
                if (userFromDb != null)
                {
                    SendMsg(": " + userFromDb.username + " покинул чат!", 0);
                }
            }
        }

        public void SendMsg(string msg, int id)
        {
            using (MessengerDTEntities2 db = new MessengerDTEntities2())
            {

                users userFromDb = db.users.FirstOrDefault(u => u.user_id == id);

                foreach (var item in _users)
                {
                    string answer = DateTime.Now.ToShortTimeString();

                   
                    if(userFromDb != null)
                    {
                        answer += ": " + userFromDb.username + " ";
                    }
                    
                    answer += msg;
                    item.operationContext.GetCallbackChannel<IServerMessengerCallback>().MsgCallback(answer);
                }
            }
        }
    }
}
