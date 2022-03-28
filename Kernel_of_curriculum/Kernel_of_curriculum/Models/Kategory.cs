using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Kernel_of_curriculum.Models {
    public class Kategory {

        public class Kategory_Conn_Date_Base {

            public int IdK { get; set; }
            public string NameK { get; set; }
            public string CvetK { get; set; }

            public Kategory_Conn_Date_Base() { }

            public Kategory_Conn_Date_Base(string nameK,string cvetK) {
                NameK = nameK;
                CvetK = cvetK;
            }
        }

        public class Kategory_with_Color : INotifyPropertyChanged {

            private int idK { get; set; }
            private string nameK { get; set; }
            private Color cvetK { get; set; }

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
            public Color CvetK {
                get { return cvetK; }
                set {
                    cvetK = value;
                    OnPropertyChanged("Cvet");
                }
            }

            public Kategory_with_Color() {
                CvetK = Colors.GreenYellow;
                NameK = "...";
            }

            public Kategory_with_Color(int idK,string nameK,Color cvetK) {
                IdK = idK;
                CvetK = cvetK;
                NameK = nameK;
            }

            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName] string prop = "") {

                if (PropertyChanged != null)
                    PropertyChanged(this,new PropertyChangedEventArgs(prop));

            }
        }

    }
}
