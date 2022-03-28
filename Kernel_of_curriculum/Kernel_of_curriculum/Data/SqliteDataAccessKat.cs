using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Linq;
using static Kernel_of_curriculum.Models.Kategory;

namespace Kernel_of_curriculum {
    public class SqliteDataAccessKat {
        public static List<Kategory_Conn_Date_Base> LoadKat() {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                var output = cnn.Query<Kategory_Conn_Date_Base>("select * from Kategory",new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddKat(Kategory_Conn_Date_Base kateg) {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("insert into Kategory (NameK, CvetK)" +
                    "values (@NameK, @CvetK)",kateg);
            }
        }

        public static void DelKat(int IdK) {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("delete from Kategory " +
                    $"where idK = {IdK}");
            }
        }

        public static void UpdateKatNameK(int IdK,string NameK) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Kategory " +
                    $"set NameK = '{NameK}' " +
                    $"where idK = {IdK}");
            }
        }

        public static void UpdateKatCvet(int IdK,string Cvet) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Kategory " +
                    $"set CvetK = '{Cvet}' " +
                    $"where idK = {IdK}");
            }
        }

        public static void UpdateKatNameCvet(int IdK,string NameK,string CvetK) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Kategory " +
                    $"set NameK = '{NameK}', " +
                    $"CvetK = '{CvetK}' " +
                    $"where idK = {IdK}");
            }
        }

        private static string LoadConnectionString(string id = "Default") {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
