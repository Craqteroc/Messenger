using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MessengerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(ClassService.ServiceMessenger)))
            {
                host.Open();
                Console.WriteLine("Хост начал работу");
                Console.ReadKey();
            }
        }
    }
}
