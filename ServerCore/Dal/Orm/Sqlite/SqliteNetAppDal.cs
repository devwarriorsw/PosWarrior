using ServerCore.Dal.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Dal.Orm.Sqlite
{
    public class SqliteNetAppDal : IApplicationDal
    {
        private string ConnectionString;

        public void Init(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("Invalid connection string", nameof(connectionString));

           // SQLite3.Config(SQLite3.ConfigOption.Serialized);

            ConnectionString = connectionString;
        }

        public bool OpenDatabase()
        {
            // Open the db
            using (var db = new SQLiteConnection(ConnectionString))
            {
                db.CreateTable<Device>();
                db.CreateTable<Employee>();
                db.CreateTable<EmployeeDetails>();
                db.CreateTable<Product>();
                db.CreateTable<Promo>();
                db.CreateTable<Role>();
                db.CreateTable<Session>();
            }

            return true;
        }

        private T ExecuteCommand<T>(Func<SQLiteConnection, T> action)
        {
            try
            {
                using (var db = new SQLiteConnection(ConnectionString))
                {
                    return action(db);
                }
            }
            catch(Exception ex)
            {
                return default(T);
            }
        }

        public Employee AddEmployee(Employee employee)
        {
            return ExecuteCommand<Employee>((db) =>
            {
                db.Insert(employee);
                return employee;
            });
        }

        public bool UpdateEmployee(Employee employee)
        {
            return ExecuteCommand<bool>((db) =>
            {
                var existing = db.Get<Employee>(e => e.EmployeeId == employee.EmployeeId);
                if(existing != null)
                {
                    existing.Name = employee.Name;
                   return db.Update(existing) > 0;
                }
                return false;
            });
        }

        public Employee GetEmployee(Guid employeeId)
        {
            return ExecuteCommand<Employee>((db) =>
            {
                return db.Get<Employee>(e => e.EmployeeId == employeeId);
            });
        }

        public bool DeleteEmployee(int dbId)
        {
            return ExecuteCommand<bool>((db) =>
            {
                return db.Delete<Employee>(dbId) > 0;
            });
        }

        public bool DeleteEmployee(Employee employee)
        {
            return DeleteEmployee(employee.Id);
        }
     
    }
}
