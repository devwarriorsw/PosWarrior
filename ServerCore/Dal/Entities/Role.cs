using ServerCore.Dal.Orm.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Entities
{
    public class Role
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public Guid RoleId { get; set; }

        [Indexed]
        public Guid EmployeeId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public WorkShift Shift { get; set; }

        // A flag value that lists which days this role is active (Monday|Tuesday|Friday...)
        public WorkDays WorkDays { get; set; }
    }
}
