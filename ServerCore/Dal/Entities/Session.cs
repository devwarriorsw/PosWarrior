using ServerCore.Dal.Orm.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Entities
{    
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // A guid that identifies this unique employee session
        [Indexed]
        public Guid SessionId { get; set; }

        // The employee that opened this session
        [Indexed]
        public Guid EmployeeId { get; set; }

        // The device used to start the session
        [Indexed]
        public Guid DeviceId { get; set; }

        public WorkShift Shift { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime DateEnded { get; set; }

        public string Notes { get; set; }
    }
}
