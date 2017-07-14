using ServerCore.Dal.Orm.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Entities
{
    public class Device
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public Guid DeviceId { get; set; }
        
        // A name for this device
        public string Name { get; set; }

        DeviceType DeviceType { get; set; }

        // The os version on the device running the app
        public string OsVersion { get; set; }
        
        // The pos warrior app version on this device
        public string AppVersion { get; set; }

        // Status of the device, disabled to prevent connecting to the server
        public Status Status { get; set; }
    }
}
