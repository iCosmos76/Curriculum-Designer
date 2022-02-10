using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Linq;

namespace Kernel_of_curriculum {
    public class SqliteDataAccess {
        public static List<Kategory> LoadKat() {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                var output = cnn.Query<Kategory>("select * from Kategory",new DynamicParameters());
                return output.ToList();
            }

        }

        public static void AddKat(Kategory kateg) {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("insert into Kategory (NameK, Cvet)" +
                    "values (@NameK, @Cvet)",kateg);
            }
        }

        public static void DelKat(int IdK) {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("delete from Kategory " +
                    $"where idK = {IdK}");
            }
        }

        public static void UpdateKatNameK(int IdK, string NameK) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Kategory " +
                    $"set NameK = '{NameK}' " +
                    $"where idK = {IdK}");
            }
        }

        public static void UpdateKatCvet(int IdK,string Cvet) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Kategory " +
                    $"set Cvet = '{Cvet}' " +
                    $"where idK = {IdK}");
            }
        }

        public static void UpdateKatNameCvet(int IdK,string NameK, string Cvet) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Kategory " +
                    $"set NameK = '{NameK}', " +
                    $"Cvet = '{Cvet}' " +
                    $"where idK = {IdK}");
            }
        }

        private static string LoadConnectionString(string id = "Default") {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
