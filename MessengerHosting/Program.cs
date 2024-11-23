using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MessengerHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(ServiceClassMessenger.ServiceMessenger)))
            {
                host.Open();
                Console.WriteLine("Хост начал работу");
                Console.ReadKey();
            }
        }
    }
}
