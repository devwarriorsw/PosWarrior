using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Entities
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // A guid that identifies this employee
        [Indexed]
        public Guid EmployeeId { get; set; }

        // Simple name for the employee
        public string Name { get; set; }
    }
}
