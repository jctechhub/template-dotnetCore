using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotnetCore.Data;
using DotnetCore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var connectionstring = @"Server=(local);Database=Northwind;Trusted_Connection=True;ConnectRetryCount=0";

            using (var db = new NorthwindContext(connectionstring))
            {
//                var test = db.Employees.ToList();

                db.Database.OpenConnection();
                var cmd = db.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "CustOrderHist";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CustomerID", "AROUT"));
                List<CustomerOrder> orders = new List<CustomerOrder>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = reader.GetString(0);
                        var total = reader.GetInt32(1);
                        orders.Add(new CustomerOrder(){ ProductName = product, Total = total});
                    }
                }

                Assert.IsTrue(orders.Count > 0, "order is greater than 0.");
            }

            
            

        }
    }
}
