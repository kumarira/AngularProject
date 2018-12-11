using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Task1_WCF;

namespace HostApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Service1));
            host.Open();
            Console.WriteLine("Host started @" + DateTime.Now.ToString());
            Console.ReadKey();
            ////using (ServiceHost host = new ServiceHost(typeof(Service1)))
            ////{
            ////    //read the WCF service  
            ////    host.Open();
            ////    Console.WriteLine("Service Started............");                
            ////    host.Close();
            ////    Console.ReadLine();
            ////}

            //ServiceHost host = new ServiceHost(typeof(Service1));
            //host.Open();
            //Console.Write("Service is up and running");
            //Console.WriteLine("To stop service press any key !!! ");
            //Console.ReadKey();
            //host.Close();
        }
    }
}
