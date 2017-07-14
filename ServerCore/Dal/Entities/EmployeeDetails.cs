using ServerCore.Dal.Orm.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Entities
{
    public class EmployeeDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public Guid EmployeeId { get; set; }

        [Indexed]
        public string Name { get; set; }        
        public string MiddleName { get; set; }        
        public string LastName { get; set; }
        public string Age { get; set; }        
        public string Address { get; set; }        
        public string PhoneNumber { get; set; }        
        public string Date { get; set; }
        public Status Status { get; set; }
    }
}
