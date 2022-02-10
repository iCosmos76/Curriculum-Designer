using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using Xceed.Wpf.Toolkit;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kernel_of_curriculum {
    /// <summary>
    /// Логика взаимодействия для ListKategoriy.xaml
    /// </summary>
    public partial class ListKategoriy : Window {

        public ObservableCollection<Kategory_with_Color> kategories = new ObservableCollection<Kategory_with_Color>(); 
        public List<Kategory> sqlkat = SqliteDataAccess.LoadKat();
       
        private Kategory_with_Color activeCellAtEdit_old { get; set; }
        private string nmk_old { get; set; }
        private string nmk_new { get; set; }
        private string cvt_old { get; set; }
        private string cvt_new { get; set; }

        // конвертация kategories_filt(List) в kategories_filt(ObservableCollection)
        //public ObservableCollection<T> Convert<T>(IEnumerable<T> original) {
        //    return new ObservableCollection<T>(original);
        //}


        public ListKategoriy() {
            InitializeComponent();

            // замена hex цвета типа string из БД на тип object.Color
            for (int i = 0; i < sqlkat.Count; i++) {
                kategories.Add(new Kategory_with_Color(sqlkat[i].IdK,sqlkat[i].NameK,
                    (Color)ColorConverter.ConvertFromString(sqlkat[i].Cvet)));
            }

            // привязка категорий к датагриду
            dtKategories.ItemsSource = kategories;
        }

        private void btnAddKat_Click(object sender,RoutedEventArgs e) {
            
            var kat_save = new Kategory("...", Colors.GreenYellow.ToString());

            SqliteDataAccess.AddKat(kat_save);
            sqlkat = SqliteDataAccess.LoadKat();

            kategories.Add(new Kategory_with_Color(sqlkat[sqlkat.Count - 1].IdK,sqlkat[sqlkat.Count - 1].NameK,
                (Color)ColorConverter.ConvertFromString(sqlkat[sqlkat.Count - 1].Cvet)));
            
        }

        private void btnDelKat_Click(object sender,RoutedEventArgs e) {

            var sel_cell = (Kategory_with_Color)dtKategories.SelectedItem;
            if (sel_cell != null) {
                SqliteDataAccess.DelKat(sel_cell.IdK);
                kategories.RemoveAt(dtKategories.SelectedIndex);
            }
        }

        private void dtKategories_BeginningEdit(object sender,DataGridBeginningEditEventArgs e) {

            activeCellAtEdit_old = (Kategory_with_Color)dtKategories.SelectedItem;

            if (e.Column.Header.ToString() == "Название категории")
                nmk_old = activeCellAtEdit_old.NameK;
            if (e.Column.Header.ToString() == "Цвет")
                cvt_old = activeCellAtEdit_old.Cvet.ToString();

        }

        private void dtKategories_RowEditEnding(object sender,DataGridRowEditEndingEventArgs e) {

            var get_elem = (Kategory_with_Color)e.Row.Item;

            if (get_elem.NameK != nmk_old && get_elem.Cvet.ToString() != cvt_old)
                SqliteDataAccess.UpdateKatNameCvet(get_elem.IdK,get_elem.NameK,get_elem.Cvet.ToString());
            if (get_elem.NameK != nmk_old)
                SqliteDataAccess.UpdateKatNameK(get_elem.IdK,get_elem.NameK);
            if (get_elem.Cvet.ToString() != cvt_old)
                SqliteDataAccess.UpdateKatCvet(get_elem.IdK,get_elem.Cvet.ToString());
        }

    }

    public class Kategory {

        public int IdK { get; set; }
        public string NameK { get; set; }
        public string Cvet { get; set; }

        public Kategory() { }

        public Kategory(string nameK,string cvet) {
            NameK = nameK;
            Cvet = cvet;
        }
    }

    public class Kategory_with_Color : INotifyPropertyChanged {

        private int idK { get; set; }
        private string nameK { get; set; }
        private Color cvet { get; set; }

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
        public Color Cvet {
            get { return cvet; }
            set {
                cvet = value;
                OnPropertyChanged("Cvet");
            }
        }

        public Kategory_with_Color() {
            Cvet = Colors.GreenYellow;
            NameK = "...";
        }

        public Kategory_with_Color(int idK, string nameK, Color cvet) {
            IdK = idK;
            Cvet = cvet;
            NameK = nameK;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") {

            if (PropertyChanged != null)
                PropertyChanged(this,new PropertyChangedEventArgs(prop));

        }
    }
}
