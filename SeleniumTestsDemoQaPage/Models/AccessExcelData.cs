using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Models
{
    class AccessExcelData
    {
        public static string TestDataFileConnection()
        {
            var path = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var filename = "UserData.xlsx";
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties=Excel 12.0;", path + filename);
            return con;
        }

        public static SoftUniUser GetTestData(string keyName) // SoftUniUser - named after the source (xlsx) file
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key = '{0}'", keyName); // DataSet - name of the xlsx sheet where our data is
                var value = connection.Query<SoftUniUser>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }

        public static RegistrationUser GetTestUserData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSetRegistrationUser$] where key = '{0}'", keyName); // DataSetRegistrationUser - name of the xlsx sheet where our data is
                var value = connection.Query<RegistrationUser>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }

        public static InteractionPages GetInteractionTestsData(string keyName) // SoftUniUser - named after the source (xlsx) file
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key = '{0}'", keyName); // DataSetInteractionPages - name of the xlsx sheet where our data is
                var value = connection.Query<SoftUniUser>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
