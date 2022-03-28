using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using static Kernel_of_curriculum.Models.Disccipline;

namespace Kernel_of_curriculum {
    /// <summary>
    /// Логика взаимодействия для Disciplines_editor.xaml
    /// </summary>
    /// 
    public partial class Disciplines_editor : Window {
        
        public ObservableCollection<Discipline_DataGrid> disciplines = new ObservableCollection<Discipline_DataGrid>();
        public List<Discipline_Conn_Data_Base> sqldisp;
        public List<Discipline_Conn_Data_Base> sqllastdisp;
        public List<Discipline_Conn_Data_Base> sqldispidknull;

        public bool flProm;
        public bool flKurs;
        public string NameKat;
        public string CvetKat;

        private Discipline_DataGrid activeCellAtEdit_old { get; set; }
        private string name_old { get; set; }
        private string sokrName_old { get; set; }
        private int selBlok_old { get; set; }
        private string kategory_old { get; set; }
        private int idK_kategory_old { get; set; }
        private string kategory_new { get; set; }
        private int idK_kategory_new { get; set; }
        private int theoryRab_old { get; set; }

        private bool flgPromAttest_old { get; set; }
        private int promAttest_old { get; set; }
        private bool flgKurs_old { get; set; }
        private int kurs_old { get; set; }


        public Disciplines_editor() {
            InitializeComponent();       
        }

        private void btnAddElement_Click(object sender,RoutedEventArgs e) {

            try {
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
                CvetKat = "#FFFFFF";

                disciplines.Add(new Discipline_DataGrid(sqllastdisp[0].IdDisp,
                    sqllastdisp[0].NameD,sqllastdisp[0].SokrNameD,
                        sqllastdisp[0].SelBlok,sqllastdisp[0].IdK,NameKat,CvetKat,
                        sqllastdisp[0].TheoryRab,flProm,sqllastdisp[0].PromAttest,
                        flKurs,sqllastdisp[0].Kurs));

                Dispatcher.BeginInvoke(DispatcherPriority.Input,new Action(() =>
                {
                    SelectRowByIndex(dtGridElement,dtGridElement.Items.Count - 1);
                }));
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
            

        }

        // фокус на последнюю строку при добавлении элемента
        private void SelectRowByIndex(DataGrid dtGridElement,int rowIndex) {
            if (!dtGridElement.SelectionUnit.Equals(DataGridSelectionUnit.FullRow))
                throw new ArgumentException("The SelectionUnit of the DataGrid must be set to FullRow.");

            if (rowIndex < 0 || rowIndex > (dtGridElement.Items.Count - 1))
                throw new ArgumentException(string.Format("{0} is an invalid row index.",rowIndex));

            dtGridElement.SelectedItems.Clear();
            /* set the SelectedItem property */
            object item = dtGridElement.Items[rowIndex]; // = Product X
            dtGridElement.SelectedItem = item;

            DataGridRow row = dtGridElement.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            if (row == null) {
                /* bring the data item (Product object) into view
                 * in case it has been virtualized away */
                dtGridElement.ScrollIntoView(item);
                row = dtGridElement.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            }
            //TODO: Retrieve and focus a DataGridCell object
        }

        private void btnDelElement_Click(object sender,RoutedEventArgs e) {
            
            var single_cell = (Discipline_DataGrid)dtGridElement.SelectedItem;

            var multi_dell = dtGridElement.SelectedItems;

            Discipline_DataGrid elem;

            if (multi_dell.Count > 0) {
                if (multi_dell.Count == 1) {

                    var dialogResult = System.Windows.MessageBox.Show($"Вы уверены что хотите удалить {single_cell.Name}?",
                    "Внимание!",MessageBoxButton.YesNo,MessageBoxImage.Question);

                    if (dialogResult == MessageBoxResult.Yes) {
                        SqliteDataAccessDisp.DelDisp(single_cell.IdDisp);
                        disciplines.RemoveAt(dtGridElement.SelectedIndex);
                    }
                }
                else if (multi_dell.Count > 1) {
                    var dialogResult = System.Windows.MessageBox.Show($"Вы уверены что хотите удалить " +
                        $"выбранные элементы?",
                    "Внимание!",MessageBoxButton.YesNo,MessageBoxImage.Question);

                    if (dialogResult == MessageBoxResult.Yes) {
                        for (int i = multi_dell.Count - 1; i >= 0; i--) {
                            elem = (Discipline_DataGrid)multi_dell[i];
                            SqliteDataAccessDisp.DelDisp(elem.IdDisp);
                            disciplines.Remove((Discipline_DataGrid)multi_dell[i]);
                        }
                    }
                }
            }
            else
                System.Windows.MessageBox.Show("Выберите строку для удаления!","Ошибка",
                    MessageBoxButton.OK,MessageBoxImage.Error,MessageBoxResult.OK);

        }

        private void btnApplyChanges_Click(object sender,RoutedEventArgs e) {
            var selected_items = dtGridElement.SelectedItems;

            if (selected_items.Count > 0) {
                DialogResult = true;
            }
            else
                System.Windows.MessageBox.Show("Выберите элемент или элементы из списка!","Ошибка",
                    MessageBoxButton.OK,MessageBoxImage.Error,MessageBoxResult.OK);

        }

        public IList list_of_elements() {
            var selected_items = dtGridElement.SelectedItems;
            return selected_items;
        }

        private void btnAddCategory_Click(object sender,RoutedEventArgs e) {

            var UpdKat = (Discipline_DataGrid)dtGridElement.SelectedItem;

            ListKategoriy kt = new ListKategoriy();
            kt.ShowDialog();

            if(kt.DialogResult == true) {
                idK_kategory_new = kt.SelIdK();
                kategory_new = UpdKat.NameK = kt.SelKat();
                UpdKat.CvetK = kt.SelCvetK();

                if (idK_kategory_new != idK_kategory_old || idK_kategory_old == 0)
                    SqliteDataAccessDisp.UpdateIdK(UpdKat.IdDisp,idK_kategory_new);

            }
       
        }

        private void btnAddCategory_PreviewMouseDown(object sender,MouseButtonEventArgs e) {
            var getKatContent = (Discipline_DataGrid)dtGridElement.SelectedItem;
            if (getKatContent != null) {
                kategory_old = getKatContent.NameK;
                idK_kategory_old = getKatContent.IdK;
            }
            else
                idK_kategory_old = 0;
        }

        private void dtGridElement_BeginningEdit(object sender,DataGridBeginningEditEventArgs e) {
            activeCellAtEdit_old = (Discipline_DataGrid)dtGridElement.SelectedItem;
            
            if (e.Column.Header.ToString() == "Название элемента   ")
                name_old = activeCellAtEdit_old.Name;
            if (e.Column.Header.ToString() == "Сокр. назв. элемента   ")
                sokrName_old = activeCellAtEdit_old.SokrName;
            if (e.Column.Header.ToString() == "Теор. обучение (з.е.)   ")
                theoryRab_old = activeCellAtEdit_old.TheoryRab;
            if (e.Column.Header.ToString() == "Промеж. аттестация (з.е.)   ") {
                flgPromAttest_old = activeCellAtEdit_old.FlagPromAttest;
                promAttest_old = activeCellAtEdit_old.PromAttest;
            }
            if (e.Column.Header.ToString() == "Курс. работа/проект (з.е.)   ") {
                flgKurs_old = activeCellAtEdit_old.FlagKurs;
                kurs_old = activeCellAtEdit_old.Kurs;
            }

            //Debug.WriteLine($"{name_old} + {sokrName_old} + {selBlok_old} + {kategory_old} + {idK_kategory_old} + " +
            //    $"{theoryRab_old} + {flgPromAttest_old} + {promAttest_old} + {flgKurs_old} + {kurs_old}");

            //Debug.WriteLine($"{activeCellAtEdit_old.Name} + {activeCellAtEdit_old.SokrName} " +
            //    $"+ {activeCellAtEdit_old.SelBlok} + {activeCellAtEdit_old.NameK} + {activeCellAtEdit_old.IdK} + " +
            //    $"{activeCellAtEdit_old.TheoryRab} + {activeCellAtEdit_old.FlagPromAttest} + " +
            //    $"{activeCellAtEdit_old.PromAttest} + {activeCellAtEdit_old.FlagKurs} + {activeCellAtEdit_old.Kurs}");

        }

        private void dtGridElement_RowEditEnding(object sender,DataGridRowEditEndingEventArgs e) {
            var get_elem = (Discipline_DataGrid)e.Row.Item;
            
            if (get_elem.Name != name_old)
                SqliteDataAccessDisp.UpdateNameD(get_elem.IdDisp,get_elem.Name);
            if (get_elem.SokrName != sokrName_old)
                SqliteDataAccessDisp.UpdateSokrNameD(get_elem.IdDisp,get_elem.SokrName);
            if (get_elem.TheoryRab != theoryRab_old)
                SqliteDataAccessDisp.UpdateTheoryRab(get_elem.IdDisp,get_elem.TheoryRab);
            if (get_elem.FlagPromAttest != flgPromAttest_old)
                SqliteDataAccessDisp.UpdateFlagPromAttest(get_elem.IdDisp,get_elem.FlagPromAttest ? 1 : 0);
            if (get_elem.PromAttest != promAttest_old)
                SqliteDataAccessDisp.UpdatePromAttest(get_elem.IdDisp,get_elem.PromAttest);
            if (get_elem.FlagKurs != flgKurs_old)
                SqliteDataAccessDisp.UpdateFlagKurs(get_elem.IdDisp,get_elem.FlagKurs ? 1 : 0);
            if (get_elem.Kurs != kurs_old)
                SqliteDataAccessDisp.UpdateKurs(get_elem.IdDisp,get_elem.Kurs);
                           
        }

        private void ComboBox_DropDownClosed(object sender,EventArgs e) {
            var get_elem = (Discipline_DataGrid)dtGridElement.SelectedItem;

            if (get_elem.SelBlok != selBlok_old)
                SqliteDataAccessDisp.UpdateSelBlok(get_elem.IdDisp,get_elem.SelBlok);

        }

        private void ComboBox_DropDownOpened(object sender,EventArgs e) {
            var get_elem = sender as ComboBox;
            selBlok_old = get_elem.SelectedIndex;
        }

        private void dtGridElement_CellEditEnding(object sender,DataGridCellEditEndingEventArgs e) {
            if (Keyboard.IsKeyDown(Key.Escape) && e.Column.Header.ToString() == "Название элемента   ") {
                var nmdisp = e.EditingElement as TextBox;
                nmdisp.Text = name_old;
            }
            if (Keyboard.IsKeyDown(Key.Escape) && e.Column.Header.ToString() == "Сокр. назв. элемента   ") {
                var nmdisp = e.EditingElement as TextBox;
                nmdisp.Text = sokrName_old;
            }
        }

        private void wndEditorElements_Loaded(object sender,RoutedEventArgs e) {
            sqldisp = SqliteDataAccessDisp.LoadDisp();

            try {
                for (int i = 0; i < sqldisp.Count; i++) {

                    if (sqldisp[i].FlagPromAttest == 1)
                        flProm = true;
                    else
                        flProm = false;

                    if (sqldisp[i].FlagKurs == 1)
                        flKurs = true;
                    else
                        flKurs = false;

                    disciplines.Add(new Discipline_DataGrid(sqldisp[i].IdDisp,sqldisp[i].NameD,sqldisp[i].SokrNameD,
                        sqldisp[i].SelBlok,sqldisp[i].IdK,sqldisp[i].NameK,sqldisp[i].CvetK,sqldisp[i].TheoryRab,flProm,
                        sqldisp[i].PromAttest,flKurs,sqldisp[i].Kurs));

                }

                if (SqliteDataAccessDisp.LoadDispIdKNull() != null) {

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
                        CvetKat = "#FFFFFF";

                        disciplines.Add(new Discipline_DataGrid(sqldispidknull[i].IdDisp,
                            sqldispidknull[i].NameD,sqldispidknull[i].SokrNameD,
                                sqldispidknull[i].SelBlok,sqldispidknull[i].IdK,NameKat,CvetKat,
                                sqldispidknull[i].TheoryRab,flProm,sqldispidknull[i].PromAttest,
                                flKurs,sqldispidknull[i].Kurs));
                    }
                }

                dtGridElement.ItemsSource = disciplines;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
    }

    

    // измененная кнопка с добавленным свойством цвета категории
    public class CustomButton : Button {
        public string ColorKategory {
            get { return (string)GetValue(ColorKategoryProperty); }
            set { SetValue(ColorKategoryProperty,value); }
        }
        public static readonly DependencyProperty
        ColorKategoryProperty = DependencyProperty.Register("ColorKategory",
            typeof(string),typeof(CustomButton),new PropertyMetadata(""));
    }

}
