using NUnit.Framework;
using ServerCore.Dal.Entities;
using ServerCore.Dal.Factory;
using ServerCore.Dal.Orm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServerTests.Database
{
    [TestFixture]
    public class EmployeeTests
    {
        private string ConnectionString;
        private IApplicationDal Dal;

        [SetUp]
        public void Setup()
        {
            var path = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            ConnectionString = Path.Combine(path, "ServerTestsDb.db");

            Assert.True(File.Exists(ConnectionString), $"Db file not found at:[{ConnectionString}]");

            Dal = DalFactory.Get(DalTypes.OrmSqliteNet, ConnectionString);
            var open = Dal.OpenDatabase();
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        public void OpenDatabase()
        {
            var watch = new Stopwatch();
            watch.Start();

            var dal = DalFactory.Get(DalTypes.OrmSqliteNet, ConnectionString);
            var open = dal.OpenDatabase();
            watch.Stop();
            Console.WriteLine($"OpenDatabase took:[{watch.ElapsedMilliseconds}] ms");

            Assert.True(open, "Failed to open db");
        }

        [Test]
        public void AddEmployee()
        {
            var employee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                Name = "Test"
            };
            var watch = new Stopwatch();

            watch.Start();
            var savedEmployee = Dal.AddEmployee(employee);
            watch.Stop();
            Console.WriteLine($"Add employee took:[{watch.ElapsedMilliseconds}] ms");
            Assert.True(savedEmployee.Id > 0, "Did not return database id");

            watch.Restart();
            var dbRecord = Dal.GetEmployee(employee.EmployeeId);
            watch.Stop();
            Console.WriteLine($"Get employee took:[{watch.ElapsedMilliseconds}] ms");

            Assert.NotNull(dbRecord, "Did not return record");
            Assert.True(dbRecord.EmployeeId == employee.EmployeeId, "Incorrect employee id");
            Assert.True(dbRecord.Name == employee.Name, "Incorrect employee name");
        }

        [Test]
        public void UpdateEmployee()
        {
            var employee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                Name = "Test"
            };
            var watch = new Stopwatch();

            watch.Start();
            var savedEmployee = Dal.AddEmployee(employee);
            watch.Stop();
            Console.WriteLine($"Add employee took:[{watch.ElapsedMilliseconds}] ms");
            Assert.True(savedEmployee.Id > 0, "Did not return database id");

            watch.Restart();
            var dbRecord = Dal.GetEmployee(employee.EmployeeId);
            watch.Stop();
            Console.WriteLine($"Get employee took:[{watch.ElapsedMilliseconds}] ms");

            Assert.NotNull(dbRecord, "Did not return record");
            Assert.True(dbRecord.EmployeeId == employee.EmployeeId, "Incorrect employee id");
            Assert.True(dbRecord.Name == employee.Name, "Incorrect employee name");

            dbRecord.Name = "New Name";
            watch.Restart();
            var updated = Dal.UpdateEmployee(dbRecord);
            watch.Stop();
            Console.WriteLine($"Update employee took:[{watch.ElapsedMilliseconds}] ms");
            Assert.True(updated, "Failed to update record");

            watch.Restart();
            dbRecord = Dal.GetEmployee(employee.EmployeeId);
            watch.Stop();
            Console.WriteLine($"Get employee took:[{watch.ElapsedMilliseconds}] ms");
            Assert.True(dbRecord.Name == "New Name", "Incorrect employee name");
        }

        [Test]
        public void AddHundreedEmployees()
        {
            var watchTotal = new Stopwatch();
            var watch = new Stopwatch();
            watchTotal.Start();
            for (int x = 0; x < 100; x++)
            {
                var employee = new Employee()
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = "Test-" + x
                };
                
                watch.Restart();
                var savedEmployee = Dal.AddEmployee(employee);
                watch.Stop();
                Console.WriteLine($"Add employee [{employee.Name}] took:[{watch.ElapsedMilliseconds}] ms");                
            }

            watchTotal.Stop();
            Console.WriteLine($"Add Hundreed employees took:Seconds:[{watchTotal.Elapsed}], Milliseconds[{watchTotal.ElapsedMilliseconds}]");
        }

        [Test]
        public void DeleteEmployee()
        {
            var watch = new Stopwatch();

            var employee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                Name = "Test"
            };

            watch.Start();
            var savedEmployee = Dal.AddEmployee(employee);            
            watch.Stop();
            Console.WriteLine($"Add employee took:[{watch.ElapsedMilliseconds}] ms");
            Assert.True(savedEmployee.Id > 0, "Did not return database id");

            watch.Restart();
            var deleted = Dal.DeleteEmployee(employee.Id);            
            watch.Stop();
            Console.WriteLine($"Delete employee took:[{watch.ElapsedMilliseconds}] ms");
            Assert.True(deleted, "Did not delete record");

            watch.Restart();
            var dbRecord = Dal.GetEmployee(employee.EmployeeId);
            watch.Stop();
            Console.WriteLine($"Get employee took:[{watch.ElapsedMilliseconds}] ms");
            Assert.Null(dbRecord, "Return deleted record");
            
        }
    }
}
