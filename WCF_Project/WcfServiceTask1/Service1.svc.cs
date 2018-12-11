using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceTask1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        
        public string SayHello(string Name)
        {
            return string.Format("SayHello:{0}" + Name);
        }
        public string TodayProgram(string Name)
        {
            return string.Format("TodayProgram:{0}" + Name);
        } 
       
    }
}
