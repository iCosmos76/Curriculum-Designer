using System.Collections.Generic;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static Kernel_of_curriculum.Models.Kategory;

namespace Kernel_of_curriculum {
    /// <summary>
    /// Логика взаимодействия для ListKategoriy.xaml
    /// </summary>
    public partial class ListKategoriy : Window {
        
        ObservableCollection<Kategory_with_Color> kategories = new ObservableCollection<Kategory_with_Color>(); 
        List<Kategory_Conn_Date_Base> sqlkat = SqliteDataAccessKat.LoadKat();
       
        private Kategory_with_Color activeCellAtEdit_old { get; set; }
        private string nmk_old { get; set; }
        private string cvt_old { get; set; }

        // конвертация kategories_filt(List) в kategories_filt(ObservableCollection)
        //public ObservableCollection<T> Convert<T>(IEnumerable<T> original) {
        //    return new ObservableCollection<T>(original);
        //}

        public ListKategoriy() {
            InitializeComponent();

            // замена hex цвета типа string из БД на тип object.Color
            for (int i = 0; i < sqlkat.Count; i++) {
                kategories.Add(new Kategory_with_Color(sqlkat[i].IdK,sqlkat[i].NameK,
                    (Color)ColorConverter.ConvertFromString(sqlkat[i].CvetK)));
            }

            // привязка категорий к датагриду
            dtKategories.ItemsSource = kategories;
        }

        private void dtKategories_BeginningEdit(object sender,DataGridBeginningEditEventArgs e) {

            activeCellAtEdit_old = (Kategory_with_Color)dtKategories.SelectedItem;

            if (e.Column.Header.ToString() == "Название категории")
                nmk_old = activeCellAtEdit_old.NameK;
            if (e.Column.Header.ToString() == "Цвет")
                cvt_old = activeCellAtEdit_old.CvetK.ToString();

        }

        private void dtKategories_RowEditEnding(object sender,DataGridRowEditEndingEventArgs e) {

            var get_elem = (Kategory_with_Color)e.Row.Item;

            if (get_elem.NameK != nmk_old && get_elem.CvetK.ToString() != cvt_old)
                SqliteDataAccessKat.UpdateKatNameCvet(get_elem.IdK,get_elem.NameK,get_elem.CvetK.ToString());
            if (get_elem.NameK != nmk_old)
                SqliteDataAccessKat.UpdateKatNameK(get_elem.IdK,get_elem.NameK);
            if (get_elem.CvetK.ToString() != cvt_old)
                SqliteDataAccessKat.UpdateKatCvet(get_elem.IdK,get_elem.CvetK.ToString());
        }

        private void btnAddKat_Click(object sender,RoutedEventArgs e) {

            var kat_save = new Kategory_Conn_Date_Base("...",Colors.GreenYellow.ToString());

            SqliteDataAccessKat.AddKat(kat_save);
            sqlkat = SqliteDataAccessKat.LoadLastKat();

            kategories.Add(new Kategory_with_Color(sqlkat[0].IdK,sqlkat[0].NameK,
                (Color)ColorConverter.ConvertFromString(sqlkat[0].CvetK)));

        }

        private void btnDelKat_Click(object sender,RoutedEventArgs e) {

            var single_cell = (Kategory_with_Color)dtKategories.SelectedItem;
            var multi_dell = dtKategories.SelectedItems;

            Kategory_with_Color elem;

            if (multi_dell.Count > 0) {
                if(multi_dell.Count == 1) {

                    var dialogResult = MessageBox.Show($"Вы уверены что хотите удалить категорию {single_cell.NameK}?",
                    "Внимание!",MessageBoxButton.YesNo,MessageBoxImage.Question);

                    if (dialogResult == MessageBoxResult.Yes) {
                        SqliteDataAccessKat.DelKat(single_cell.IdK);
                        kategories.RemoveAt(dtKategories.SelectedIndex);
                    }
                }
                else if (multi_dell.Count > 1) {
                    var dialogResult = MessageBox.Show($"Вы уверены что хотите удалить " +
                        $"выбранные категории?",
                    "Внимание!",MessageBoxButton.YesNo,MessageBoxImage.Question);

                    if (dialogResult == MessageBoxResult.Yes) {
                        for (int i = multi_dell.Count - 1; i >= 0; i--) {
                            elem = (Kategory_with_Color)multi_dell[i];
                            SqliteDataAccessKat.DelKat(elem.IdK);
                            kategories.Remove((Kategory_with_Color)multi_dell[i]);
                        }                       
                    }                   
                }                 
            }
            else
                MessageBox.Show("Выберите строку для удаления!","Ошибка",
                    MessageBoxButton.OK,MessageBoxImage.Error,MessageBoxResult.OK);
            
        }

        private void btnSelectKat_Click(object sender,RoutedEventArgs e) {

            var cnt_sel_cat = dtKategories.SelectedItems;

            if (dtKategories.SelectedItem != null) {
                if (cnt_sel_cat.Count == 1)
                    DialogResult = true;
                else
                    MessageBox.Show("Выбрать можно только одну категорию!","Ошибка",
                        MessageBoxButton.OK,MessageBoxImage.Error,MessageBoxResult.OK);
            }
            else
                MessageBox.Show("Выберите категорию!","Ошибка",
                    MessageBoxButton.OK,MessageBoxImage.Error,MessageBoxResult.OK);
        }

        public string SelKat() {
            var sel_kat = (Kategory_with_Color)dtKategories.SelectedItem;
            return sel_kat.NameK;
        }
        public int SelIdK() {
            var sel_kat = (Kategory_with_Color)dtKategories.SelectedItem;
            return sel_kat.IdK;
        }

        public string SelCvetK() {
            var sel_kat = (Kategory_with_Color)dtKategories.SelectedItem;
            return sel_kat.CvetK.ToString();
        }

        private void dtKategories_CellEditEnding(object sender,DataGridCellEditEndingEventArgs e) {
            if (Keyboard.IsKeyDown(Key.Escape) && e.Column.Header.ToString() == "Название категории") {
                var nmk = e.EditingElement as TextBox;
                nmk.Text = nmk_old;
            }
        }
    }

    
}
