using ServerCore.Dal.Orm;
using ServerCore.Dal.Orm.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Factory
{
    public enum DalTypes
    {
        None,
        OrmSqliteNet,
        OrmLiteMySql,
        OrmLiteSqlite,
        OrmMsSqlCompact,
        OrmMsSqlServer
    }

    public class DalFactory
    {
        public static IApplicationDal Get(DalTypes dType, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("Invalid connection string", nameof(connectionString));

            if (dType == DalTypes.None)
                throw new ArgumentException("Invalid dal type", nameof(dType));

           IApplicationDal dal = null;
           switch(dType)
            {
                case DalTypes.OrmSqliteNet:
                    dal = new SqliteNetAppDal();
                    break;
                default:
                    throw new NotSupportedException($"Dal type not supported:[{dType}]");
            }

            dal.Init(connectionString);
            return dal;
        }
    }
}
