using ServerCore.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Orm
{
    public interface IApplicationDal
    {
        void Init(string connectionString);
        bool OpenDatabase();

        Employee AddEmployee(Employee employee);        
        Employee GetEmployee(Guid employeeId);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool DeleteEmployee(int dbId);
    }
}
