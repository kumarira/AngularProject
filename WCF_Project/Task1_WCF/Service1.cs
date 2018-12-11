using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Task1_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
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
