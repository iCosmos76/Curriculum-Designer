using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kernel_of_curriculum
{
    /// <summary>
    /// Логика взаимодействия для Disciplines_editor.xaml
    /// </summary>
    public partial class Disciplines_editor : Window {
        
        public ObservableCollection<Discipline_DataGrid> disciplines = new ObservableCollection<Discipline_DataGrid>();
        public List<Discipline_Conn_Data_Base> sqldisp = SqliteDataAccessDisp.LoadDisp();
        public List<Discipline_Conn_Data_Base> sqllastdisp;
        public List<Discipline_Conn_Data_Base> sqldispidknull;

        public bool flProm;
        public bool flKurs;
        public string NameKat;

        private Discipline_DataGrid activeCellAtEdit_old { get; set; }
        private string name_old { get; set; }
        private string sokrName_old { get; set; }
        private int selBlok_old { get; set; }
        private string kategory_old { get; set; }
        private int idK_kategory_old { get; set; }
        private string kategory_new { get; set; }
        private int idK_kategory_new { get; set; }
        private int theoryRab_old { get; set; }
        private bool flagPromAttest_old { get; set; }
        private int promAttest_old { get; set; }
        private bool flagKurs_old { get; set; }
        private int kurs_old { get; set; }


        public Disciplines_editor() {
            InitializeComponent();

            for (int i = 0; i < sqldisp.Count; i++) {

                if (sqldisp[i].FlagPromAttest == 1)
                    flProm = true;
                else
                    flProm = false;

                if (sqldisp[i].FlagKurs == 1)
                    flKurs = true;
                else
                    flKurs = false;

                disciplines.Add(new Discipline_DataGrid(sqldisp[i].IdDisp, sqldisp[i].NameD, sqldisp[i].SokrNameD,
                    sqldisp[i].SelBlok,sqldisp[i].NameK,sqldisp[i].TheoryRab,flProm,
                    sqldisp[i].PromAttest,flKurs,sqldisp[i].Kurs));

            }

            if(SqliteDataAccessDisp.LoadDispIdKNull() != null) {

                sqldispidknull = SqliteDataAccessDisp.LoadDispIdKNull();

                for (int i = 0; i < sqldispidknull.Count; i++) {

                    if (sqldispidknull[i].FlagPromAttest == 1)
                        flProm = true;
                    else
                        flProm = false;

                    if (sqldispidknull[i].FlagKurs == 1)
                        flKurs = true;
                    else
                        flKurs = false;

                    NameKat = "...";

                    disciplines.Add(new Discipline_DataGrid(sqldispidknull[i].IdDisp,
                        sqldispidknull[i].NameD,sqldispidknull[i].SokrNameD,
                            sqldispidknull[i].SelBlok,NameKat,sqldispidknull[i].TheoryRab,flProm,
                            sqldispidknull[i].PromAttest,flKurs,sqldispidknull[i].Kurs));
                }
            }       

            dtGridElement.ItemsSource = disciplines;
        }

        private void btnAddElement_Click(object sender,RoutedEventArgs e) {

            SqliteDataAccessDisp.AddDisp("...","...",0,"...",3,0,0,0,0);
            sqllastdisp = SqliteDataAccessDisp.LoadLastDisp();

            //Debug.WriteLine(sqllastdisp[0].NameK.GetType());

            if (sqllastdisp[0].FlagPromAttest == 1)
                flProm = true;
            else
                flProm = false;

            if (sqllastdisp[0].FlagKurs == 1)
                flKurs = true;
            else
                flKurs = false;

            NameKat = "...";

            disciplines.Add(new Discipline_DataGrid(sqllastdisp[0].IdDisp,
                sqllastdisp[0].NameD,sqllastdisp[0].SokrNameD,
                    sqllastdisp[0].SelBlok,NameKat,sqllastdisp[0].TheoryRab,flProm,
                    sqllastdisp[0].PromAttest,flKurs,sqllastdisp[0].Kurs));

        }

        private void btnDelElement_Click(object sender,RoutedEventArgs e) {
            var sel_cell = (Discipline_DataGrid)dtGridElement.SelectedItem;
            if (sel_cell != null) {
                SqliteDataAccessDisp.DelDisp(sel_cell.IdDisp);
                disciplines.RemoveAt(dtGridElement.SelectedIndex);
            }
            else
                MessageBox.Show("Выберите строку для удаления!","Ошибка",
                    MessageBoxButton.OK,MessageBoxImage.Error,MessageBoxResult.OK);

        }

        private void btnApplyChanges_Click(object sender,RoutedEventArgs e) {
//            LoadKatList();
        }

        private void btnAddCategory_Click(object sender,RoutedEventArgs e) {

            var UpdKat = (Discipline_DataGrid)dtGridElement.SelectedItem;

            ListKategoriy kt = new ListKategoriy();
            kt.ShowDialog();

            if(kt.DialogResult == true) {
                idK_kategory_new = kt.SelIdK();
                kategory_new = UpdKat.Kategory = kt.SelKat();
            }              
        }

        private void btnAddCategory_PreviewMouseDown(object sender,MouseButtonEventArgs e) {
            var getKatContent = (Discipline_DataGrid)dtGridElement.SelectedItem;
            kategory_old = getKatContent.Kategory;
        }

        private void dtGridElement_BeginningEdit(object sender,DataGridBeginningEditEventArgs e) {
            activeCellAtEdit_old = (Discipline_DataGrid)dtGridElement.SelectedItem;

            if (e.Column.Header.ToString() == "Название дисциплины")
                name_old = activeCellAtEdit_old.Name;
            if (e.Column.Header.ToString() == "Сокр. назв. дисциплины")
                sokrName_old = activeCellAtEdit_old.SokrName;
            if (e.Column.Header.ToString() == "Блок")
                selBlok_old = activeCellAtEdit_old.SelBlok;
            if (e.Column.Header.ToString() == "Теор. обучение")
                theoryRab_old = activeCellAtEdit_old.TheoryRab;
            if (e.Column.Header.ToString() == "Промеж. аттестация") {
                flagPromAttest_old = activeCellAtEdit_old.FlagPromAttest;
                promAttest_old = activeCellAtEdit_old.PromAttest;
            }
            if (e.Column.Header.ToString() == "Курс. работа/проект") {
                flagKurs_old = activeCellAtEdit_old.FlagKurs;
                kurs_old = activeCellAtEdit_old.Kurs;
            }

            Debug.WriteLine($"{name_old} + {sokrName_old} + {selBlok_old} + {kategory_old} + " +
                $"{theoryRab_old} + {flagPromAttest_old} + {promAttest_old} + {flagKurs_old} + {kurs_old}");
                
        }

        private void dtGridElement_RowEditEnding(object sender,DataGridRowEditEndingEventArgs e) {
            var get_elem = (Discipline_DataGrid)e.Row.Item;

            //if (get_elem.NameK != nmk_old && get_elem.Cvet.ToString() != cvt_old)
            //    SqliteDataAccessKat.UpdateKatNameCvet(get_elem.IdK,get_elem.NameK,get_elem.Cvet.ToString());
            //if (get_elem.NameK != nmk_old)
            //    SqliteDataAccessKat.UpdateKatNameK(get_elem.IdK,get_elem.NameK);
            //if (get_elem.Cvet.ToString() != cvt_old)
            //    SqliteDataAccessKat.UpdateKatCvet(get_elem.IdK,get_elem.Cvet.ToString());
        }
    }

    //public class Blok : INotifyPropertyChanged {

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    public int idB { get; set; }
    //    public string NameB {
    //        get { return nameB; }
    //        set {
    //            nameB = value;
    //            if (PropertyChanged != null) {
    //                PropertyChanged(this,new PropertyChangedEventArgs("NameB"));
    //            }
    //        } 
    //    }

    //    private string nameB;

    //    public Blok (int idb ,string nameb) {
    //        idB = idb;
    //        NameB = nameb;

    //    }
    //}

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
        public string NameK { get; set; }
        public int SelBlok { get; set; } 
        public int TheoryRab { get; set; }
        public int FlagPromAttest { get; set; }
        public int PromAttest { get; set; }
        public int FlagKurs { get; set; }
        public int Kurs { get; set; }

        public Discipline_Conn_Data_Base() { }

        public Discipline_Conn_Data_Base(string nameD, string sokrNameD,
            int selBlok, string nameK, int theoryRab, int flagPromAttest, 
            int promAttest, int flagKurs, int kurs) {

            NameD = nameD;
            SokrNameD = sokrNameD;
            SelBlok = selBlok;
            NameK = nameK;
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
        private string kategory { get; set; }
        private ObservableCollection<Blok> blok { get; set; } = new ObservableCollection<Blok>(){
                new Blok("Дисциплины"),
                new Blok("Практика"),
                new Blok("ГИА")
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
        public string Kategory {
            get { return kategory; }
            set {
                kategory = value;
                OnPropertyChanged("kategory");
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

        public Discipline_DataGrid(int idDisp, string name,string sokrName,
            int selBlok,string kategory, int theoryRab,bool flagPromAttest,
            int promAttest,bool flagKurs,int kurs) {

            IdDisp = idDisp;
            Name = name;
            SokrName = sokrName;
            SelBlok = selBlok;
            Kategory = kategory;       
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
