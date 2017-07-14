using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Factory
{
    public class DalFactory
    {
        private static DalFactory Instance;

        public static DalFactory Get()
        {
            if(Instance == null) Instance = new DalFactory();
            return Instance;
        }
    }
}
