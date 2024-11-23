using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBDMessenger.DbClass;

namespace TestBDMessenger.ViewModel
{
    

    public class ViewModel : INotifyPropertyChanged
    {

        private MessengerDTEntities2 db;
        public ObservableCollection<ClassChats> Chats { get; set; }

        public ObservableCollection<ClassUser> Users { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;



        public ViewModel()
        {
            LoadChats();
            LoadMessengePeople();
            db = new MessengerDTEntities2();
        }

        void LoadChats()
        {
            db = new MessengerDTEntities2();
            var userList = db.users.ToList();
            var chatList = db.messages_mes.ToList();

            var chat = db.chats.ToList();


            //Messnges_Content = new ObservableCollection<ClassChats>(
            //    chatList.Select(c => new ClassChats
            //    {

            //        chat_name = c.content
            //    }).ToList());


            Users = new ObservableCollection<ClassUser>(
                userList.Select(u => new ClassUser
                {
                    username = u.username
                }).ToList());
        }

        void LoadMessengePeople()
        {
            using (var context = new MessengerDTEntities2())
                ;
        }

        
    }
}
