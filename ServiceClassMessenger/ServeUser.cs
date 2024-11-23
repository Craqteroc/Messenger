using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TestBDMessenger;

namespace ServiceClassMessenger
{
    class ServeUser
    {

        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public OperationContext operationContext { get; set; }


        public ServeUser(users users)
        {
            ID = users.user_id;
            Email = users.email;
            Password = users.password_hash;
            Username = users.username;
        }
    }
}
