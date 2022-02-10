using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        
        public ObservableCollection<Discipline> Disciplines = new ObservableCollection<Discipline>();
        //public List<Kategory> ktg = new List<Kategory>();


        public Disciplines_editor() {
            InitializeComponent();
            dtGridElement.ItemsSource = Disciplines;
//            LoadKatList();
        }

        private void btnAddElement_Click(object sender,RoutedEventArgs e) {

            Discipline nv = new Discipline();
            //nv.Bloks.Add(new Blok(4,"Netdsdf")); 

            Disciplines.Add(nv);
            //TBock.Text = combobx.Text;
        }

        /// <summary>
        /// SQLite
        /// </summary>
//        private void LoadKatList() {
//           ktg = SqliteDataAccess.LoadKat();
//       }

        private void btnDelElement_Click(object sender,RoutedEventArgs e) {

 //           Kategory kt = new Kategory();
//            kt.NameK = "ККТ";
 //           kt.Cvet = "#CF0003";

//            SqliteDataAccess.SaveKat(kt);
        }

        private void btnApplyChanges_Click(object sender,RoutedEventArgs e) {
//            LoadKatList();
        }

        private void btnAddCategory_Click(object sender,RoutedEventArgs e) {
            ListKategoriy kt = new ListKategoriy();
            kt.ShowDialog();
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
        public int IdB { get; set; }
        public string NameB { get; set; }
        public Blok(int idb,string nameb) {
            IdB = idb;
            NameB = nameb;
        }
    }

    //public class Kategory {

    //    public int idK { get; set; }
    //    public string NameK { get; set; }
    //    public string Cvet { get; set; }

    //}

    public class Discipline {

        public int idKat { get; set; }
        public string Name { get; set; }
        public string SokrName { get; set; }
        
        //public enum Blok { one,two,three }
        //public string[] Blok = new string[3];
        //public Kategory Kateg;

        public ObservableCollection<Blok> Bloks { get; set; } = new ObservableCollection<Blok>(){
                new Blok(0,"Дисциплины"),
                new Blok(1,"Практика"),
                new Blok(2,"ГИА")
        };

        public int TheoryRab { get; set; }
        public bool FlagPromAttest { get; set; }
        public int PromAttest { get; set; }
        public bool FlagKurs { get; set; }
        public int Kurs { get; set; }

        public Discipline() {
            Name = "...";
            SokrName = "...";
           
            TheoryRab = 3;
            //Kateg = new Kategory("Категория","#FF008910");
            FlagPromAttest = false;
            PromAttest = 1;
            FlagKurs = false;
            Kurs = 1;
        }

    }

}
