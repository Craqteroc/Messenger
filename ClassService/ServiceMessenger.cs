using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TestBDMessenger;

namespace ClassService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceMessenger : IServiceMessenger
    {
        MessengerDTEntities2 db;
        public OperationContext operationContext { get; set; }
        int ID;

        public void Disconnect(int id)
        {
            using (var context = new MessengerDTEntities2())
            {
                var user = context.users.FirstOrDefault(i => i.user_id == id);

                if (user != null)
                {
                    context.users.Remove(user);
                    context.SaveChanges();

                    SendMsg(": " + user.username + " Оффлайн", 0);
                }
            }
        }

        public void SendMsg(string msg, int id)
        {
            using (var context = new MessengerDTEntities2())
            {
                var users = context.users.ToList();

                foreach (var item in users)
                {
                    string answer = DateTime.Now.ToShortTimeString();

                    var user = users.FirstOrDefault(i => i.user_id == id);
                    if (user != null)
                    {
                        answer += ": " + user.username + " ";
                    }
                    answer += msg;

                    //Разобраться с свойствами класса в базе данных пользователя!

                    //item.operationContext.GetCallbackChannel<IServerMessengerCallback>().MsgCallback(answer);
                }
            }
        }

        public int Autoriz(string email, string password)
        {
            using (var db = new MessengerDTEntities2())
            {
                var user = db.users.SingleOrDefault(u => u.email == email && u.password_hash == password);
                if (user != null)
                {
                    user.user_status = "online";
                    return user.user_id;
                }
                else
                {
                    return -1;
                }

            }
        }

    }
}
