using ServerCore.Dal.Orm.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Entities
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public Guid ProductId { get; set; }

        [Indexed]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        [Indexed]
        public string Categories { get; set; }

        // Name of image file to use in the app listing
        public string Image { get; set; }

        // Base price of this item
        public double Price { get; set; }
        
        public DateTime DateAdded { get; set; }

        // How many items in stock
        public int InStock { get; set; }

        public Status Status { get; set; }

    }
}
