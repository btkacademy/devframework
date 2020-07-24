using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ServiceAdapters.Kps
{
    public class TestKpsService : IKpsService
    {
        public bool Validate(object Data)
        {
            return true;
        }
    }
}
