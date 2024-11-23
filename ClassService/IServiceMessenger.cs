using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClassService
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IServiceMessenger" в коде и файле конфигурации.
    [ServiceContract] /*(CallbackContract = typeof (IServerMessengerCallback))*/
    public interface IServiceMessenger
    {
        [OperationContract]
        int Autoriz(string email, string password);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMsg(string msg, int id);

    }

    //public interface IServerMessengerCallback
    //{
    //    [OperationContract(IsOneWay = true)]
    //    void MessegeCallback(string mes);
    //}

}
