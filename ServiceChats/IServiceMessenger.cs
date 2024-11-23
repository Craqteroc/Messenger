using Microsoft.SqlServer.Management.Smo.Broker;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceChats
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IServiceMessenger" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServiceMessenger
    {
        [OperationContract]
        void DoWork();
    }
}
