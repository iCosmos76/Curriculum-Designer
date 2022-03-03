using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Linq;

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

    public class SqliteDataAccessDisp {

        public static List<Discipline_Conn_Data_Base> LoadDisp() {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                var output = cnn.Query<Discipline_Conn_Data_Base>(
                    "select IdDisp, NameD, SokrNameD, SelBlok, Kategory.IdK, Kategory.NameK, Kategory.CvetK, " +
                    "TheoryRab, FlagPromAttest, PromAttest, FlagKurs, Kurs " +
                    "from Discipline, Kategory " +
                    "where Discipline.IdK = Kategory.IdK",new DynamicParameters());
                          
                return output.ToList();
            }
        }

        public static List<Discipline_Conn_Data_Base> LoadLastDisp() {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                var output = cnn.Query<Discipline_Conn_Data_Base>(
                    "select * " +
                    "from Discipline " +
                    "order by idDisp " +
                    "desc limit 1;",new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Discipline_Conn_Data_Base> LoadDispIdKNull() {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                var output = cnn.Query<Discipline_Conn_Data_Base>(
                    "select * " +
                    "from Discipline " +
                    "where IdK is null",new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddDisp(string nameD,string sokrNameD,
            int selBlok,string nameK,int theoryRab,int flagPromAttest,
            int promAttest,int flagKurs,int kurs) {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("insert into Discipline (NameD, SokrNameD, SelBlok, idK, " +
                    "TheoryRab, FlagPromAttest, PromAttest, FlagKurs, Kurs) " +
                    $"values ('{nameD}', '{sokrNameD}', {selBlok}, '{nameK}', " +
                    $"{theoryRab}, {flagPromAttest}, {promAttest}, {flagKurs}, {kurs});");
            }
        }

        public static void DelDisp(int IdDisp) {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("delete from Discipline " +
                    $"where idDisp = {IdDisp}");
            }
        }

        public static void UpdateNameD(int IdDisp,string NameD) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Discipline " +
                    $"set NameD = '{NameD}' " +
                    $"where idDisp = {IdDisp}");
            }
        }

        public static void UpdateSokrNameD(int IdDisp,string SokrNameD) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Discipline " +
                    $"set SokrNameD = '{SokrNameD}' " +
                    $"where idDisp = {IdDisp}");
            }
        }

        public static void UpdateSelBlok(int IdDisp, int SelBlok) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Discipline " +
                    $"set SelBlok = {SelBlok} " +
                    $"where idDisp = {IdDisp}");
            }
        }

        public static void UpdateIdK(int IdDisp, int IdK) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Discipline " +
                    $"set idK = {IdK} " +
                    $"where idDisp = {IdDisp}");
            }
        }

        public static void UpdateTheoryRab(int IdDisp, int TheoryRab) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Discipline " +
                    $"set TheoryRab = {TheoryRab} " +
                    $"where idDisp = {IdDisp}");
            }
        }

        public static void UpdateFlagPromAttest(int IdDisp,int FlagPromAttest) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Discipline " +
                    $"set FlagPromAttest = {FlagPromAttest} " +
                    $"where idDisp = {IdDisp}");
            }
        }

        public static void UpdatePromAttest(int IdDisp,int PromAttest) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Discipline " +
                    $"set PromAttest = {PromAttest} " +
                    $"where idDisp = {IdDisp}");
            }
        }

        public static void UpdateFlagKurs (int IdDisp,int FlagKurs) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Discipline " +
                    $"set FlagKurs = '{FlagKurs}' " +
                    $"where idDisp = {IdDisp}");
            }
        }

        public static void UpdateKurs(int IdDisp,int Kurs) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
                cnn.Execute("update Discipline " +
                    $"set Kurs = '{Kurs}' " +
                    $"where idDisp = {IdDisp}");
            }
        }

        private static string LoadConnectionString(string id = "Default") {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
