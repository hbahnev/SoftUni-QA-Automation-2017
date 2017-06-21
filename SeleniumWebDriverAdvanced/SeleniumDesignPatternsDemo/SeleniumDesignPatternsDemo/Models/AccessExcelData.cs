using Dapper;
using SeleniumDesignPatternsDemo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Models
{
    public class AccessExcelData
    {
        public static string TestDataFileConnection()
        {
            var path = ConfigurationManager.AppSettings["TestDataSheetPath"];

            var fileName = "UserData.xlsx";

            var connection = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
                                             Data Source = {0};
                                             Extended Properties=Excel 12.0;", path + fileName);


            return connection;
        }

        public static RegistrationUser GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();

                var query = string.Format("SELECT * FROM [DataSet$] WHERE KEY = '{0}'", keyName);

                var value = connection.Query<RegistrationUser>(query).FirstOrDefault();

                connection.Close();

                return value;
            }
        }
    }
}