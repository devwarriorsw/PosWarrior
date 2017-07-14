using ServerCore.Dal.Orm.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Entities
{
    public class Promo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public Guid PromoId { get; set; }
        [Indexed]
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string Categories { get; set; }
        public string Image { get; set; }
        public string PromoType { get; set; }
        public DateTime ExpiresOn { get; set; }
        public Status Status { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateFinished { get; set; }
    }
}
