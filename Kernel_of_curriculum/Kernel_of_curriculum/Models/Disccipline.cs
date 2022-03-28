using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kernel_of_curriculum.Models {
    public class Disccipline {

        public class Blok {
            public string NameB { get; set; }
            public Blok(string nameb) {
                NameB = nameb;
            }
        }

        public class Discipline_Conn_Data_Base {

            public int IdDisp { get; set; }
            public string NameD { get; set; }
            public string SokrNameD { get; set; }
            public int SelBlok { get; set; }
            public int IdK { get; set; }
            public string NameK { get; set; }
            public string CvetK { get; set; }
            public int TheoryRab { get; set; }
            public int FlagPromAttest { get; set; }
            public int PromAttest { get; set; }
            public int FlagKurs { get; set; }
            public int Kurs { get; set; }

            public Discipline_Conn_Data_Base() { }

            public Discipline_Conn_Data_Base(int idDisp,string nameD,string sokrNameD,
                int selBlok,int idK,string nameK,string cvetK,int theoryRab,int flagPromAttest,
                int promAttest,int flagKurs,int kurs) {

                IdDisp = idDisp;
                NameD = nameD;
                SokrNameD = sokrNameD;
                SelBlok = selBlok;
                IdK = idK;
                NameK = nameK;
                CvetK = cvetK;
                TheoryRab = theoryRab;
                FlagPromAttest = flagPromAttest;
                PromAttest = promAttest;
                FlagKurs = flagKurs;
                Kurs = kurs;
            }
        }

        public class Discipline_DataGrid : INotifyPropertyChanged {

            private int idDisp { get; set; }
            private string name { get; set; }
            private string sokrName { get; set; }
            private int idK { get; set; }
            private string nameK { get; set; }
            private string cvetK { get; set; }
            private ObservableCollection<Blok> blok { get; set; } = new ObservableCollection<Blok>(){
                new Blok("Дисциплины"),
                new Blok("ГИА"),
                new Blok("Практика")

        };
            private int selBlok { get; set; }
            private int theoryRab { get; set; }
            private bool flagPromAttest { get; set; }
            private int promAttest { get; set; }
            private bool flagKurs { get; set; }
            private int kurs { get; set; }

            public int IdDisp {
                get { return idDisp; }
                set {
                    idDisp = value;
                    OnPropertyChanged("IdDisp");
                }
            }
            public string Name {
                get { return name; }
                set {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
            public string SokrName {
                get { return sokrName; }
                set {
                    sokrName = value;
                    OnPropertyChanged("SokrName");
                }
            }
            public int IdK {
                get { return idK; }
                set {
                    idK = value;
                    OnPropertyChanged("IdK");
                }
            }
            public string NameK {
                get { return nameK; }
                set {
                    nameK = value;
                    OnPropertyChanged("NameK");
                }
            }
            public string CvetK {
                get { return cvetK; }
                set {
                    cvetK = value;
                    OnPropertyChanged("CvetK");
                }
            }

            public ObservableCollection<Blok> Blok {
                get { return blok; }
                set {
                    blok = value;
                    OnPropertyChanged("Blok");
                }
            }
            public int SelBlok {
                get { return selBlok; }
                set {
                    selBlok = value;
                    OnPropertyChanged("SelBlok");
                }
            }
            public int TheoryRab {
                get { return theoryRab; }
                set {
                    theoryRab = value;
                    OnPropertyChanged("TheoryRab");
                }
            }
            public bool FlagPromAttest {
                get { return flagPromAttest; }
                set {
                    flagPromAttest = value;
                    OnPropertyChanged("FlagPromAttest");
                }
            }
            public int PromAttest {
                get { return promAttest; }
                set {
                    promAttest = value;
                    OnPropertyChanged("PromAttest");
                }
            }
            public bool FlagKurs {
                get { return flagKurs; }
                set {
                    flagKurs = value;
                    OnPropertyChanged("FlagKurs");
                }
            }
            public int Kurs {
                get { return kurs; }
                set {
                    kurs = value;
                    OnPropertyChanged("Kurs");
                }
            }

            public Discipline_DataGrid(int idDisp,string name,string sokrName,
                int selBlok,int idK,string nameK,string cvetK,int theoryRab,bool flagPromAttest,
                int promAttest,bool flagKurs,int kurs) {

                IdDisp = idDisp;
                Name = name;
                SokrName = sokrName;
                SelBlok = selBlok;
                IdK = idK;
                NameK = nameK;
                CvetK = cvetK;
                TheoryRab = theoryRab;
                FlagPromAttest = flagPromAttest;
                PromAttest = promAttest;
                FlagPromAttest = flagKurs;
                Kurs = kurs;
            }

            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName] string prop = "") {

                if (PropertyChanged != null)
                    PropertyChanged(this,new PropertyChangedEventArgs(prop));

            }
        }


    }
}
