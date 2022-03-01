using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kernel_of_curriculum {
    /// <summary>
    /// Логика взаимодействия для Main_window.xaml
    /// </summary>
    public partial class Main_window : Window {

        // переменные сумм
        #region
        public int sumFrstSem { get; set; }
        public int sumFrstSemTheoryRab { get; set; }
        public int sumFrstSemPromAttest { get; set; }
        public int sumFrstSemKurs { get; set; }

        public int sumScndSem { get; set; }
        public int sumScndSemTheoryRab { get; set; }
        public int sumScndSemPromAttest { get; set; }
        public int sumScndSemKurs { get; set; }

        public int sumThrdSem { get; set; }
        public int sumThrdSemTheoryRab { get; set; }
        public int sumThrdSemPromAttest { get; set; }
        public int sumThrdSemKurs { get; set; }

        public int sumFrthSem { get; set; }
        public int sumFrthSemTheoryRab { get; set; }
        public int sumFrthSemPromAttest { get; set; }
        public int sumFrthSemKurs { get; set; }

        public int sumFfthSem { get; set; }
        public int sumFfthSemTheoryRab { get; set; }
        public int sumFfthSemPromAttest { get; set; }
        public int sumFfthSemKurs { get; set; }

        public int sumSxthSem { get; set; }
        public int sumSxthSemTheoryRab { get; set; }
        public int sumSxthSemPromAttest { get; set; }
        public int sumSxthSemKurs { get; set; }

        public int sumSvnthSem { get; set; }
        public int sumSvnthSemTheoryRab { get; set; }
        public int sumSvnthSemPromAttest { get; set; }
        public int sumSvnthSemKurs { get; set; }

        public int sumEgthSem { get; set; }
        public int sumEgthSemTheoryRab { get; set; }
        public int sumEgthSemPromAttest { get; set; }
        public int sumEgthSemKurs { get; set; }
        #endregion

        public Main_window() {
            InitializeComponent();

            #region
            // второй семестр
            var itemsScndSem = lbScndSem.Items;
            List<ListBoxItem> listBoxItemsScndSem = new List<ListBoxItem>();
            listBoxItemsScndSem.AddRange(itemsScndSem.OfType<ListBoxItem>());

            List<Tile> tilesScndSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsScndSem.Count; i++)
                tilesScndSem.Add((Tile)listBoxItemsScndSem[i].Content);


            for (int i = 0; i < tilesScndSem.Count; i++) {
                sumScndSem += Convert.ToInt32(tilesScndSem[i].Total.Text);
                //tilesScndSem[i].Total.ValueChanged += Total_ValueChanged_Scnd_Sem;
                tilesScndSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_ScndSem;
            }

            

            // третий семестр
            var itemsThrdSem = lbThrdSem.Items;
            List<ListBoxItem> listBoxItemsThrdSem = new List<ListBoxItem>();
            listBoxItemsThrdSem.AddRange(itemsThrdSem.OfType<ListBoxItem>());

            List<Tile> tilesThrdSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsThrdSem.Count; i++)
                tilesThrdSem.Add((Tile)listBoxItemsThrdSem[i].Content);


            for (int i = 0; i < tilesThrdSem.Count; i++) {
                sumThrdSem += Convert.ToInt32(tilesThrdSem[i].Total.Text);
                //tilesThrdSem[i].Total.ValueChanged += Total_ValueChanged_Thrd_Sem;
                tilesThrdSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_ThrdSem;
            }

            

            // четвертый семестр
            var itemsFrthSem = lbFrthSem.Items;
            List<ListBoxItem> listBoxItemsFrthSem = new List<ListBoxItem>();
            listBoxItemsFrthSem.AddRange(itemsFrthSem.OfType<ListBoxItem>());

            List<Tile> tilesFrthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsFrthSem.Count; i++)
                tilesFrthSem.Add((Tile)listBoxItemsFrthSem[i].Content);


            for (int i = 0; i < tilesFrthSem.Count; i++) {
                sumFrthSem += Convert.ToInt32(tilesFrthSem[i].Total.Text);
                //tilesFrthSem[i].Total.ValueChanged += Total_ValueChanged_Frth_Sem;
                tilesFrthSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FrthSem;
            }

            

            // пятый семестр
            var itemsFfthSem = lbFrthSem.Items;
            List<ListBoxItem> listBoxItemsFfthSem = new List<ListBoxItem>();
            listBoxItemsFfthSem.AddRange(itemsFfthSem.OfType<ListBoxItem>());

            List<Tile> tilesFfthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsFfthSem.Count; i++)
                tilesFfthSem.Add((Tile)listBoxItemsFfthSem[i].Content);


            for (int i = 0; i < tilesFfthSem.Count; i++) {
                sumFfthSem += Convert.ToInt32(tilesFfthSem[i].Total.Text);
                //tilesFfthSem[i].Total.ValueChanged += Total_ValueChanged_Ffth_Sem;
                tilesFfthSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FfthSem;
            }

            

            // шестой семестр
            var itemsSxthSem = lbSxthSem.Items;
            List<ListBoxItem> listBoxItemsSxthSem = new List<ListBoxItem>();
            listBoxItemsSxthSem.AddRange(itemsSxthSem.OfType<ListBoxItem>());

            List<Tile> tilesSxthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsSxthSem.Count; i++)
                tilesSxthSem.Add((Tile)listBoxItemsSxthSem[i].Content);


            for (int i = 0; i < tilesSxthSem.Count; i++) {
                sumSxthSem += Convert.ToInt32(tilesSxthSem[i].Total.Text);
                //tilesSxthSem[i].Total.ValueChanged += Total_ValueChanged_Sxth_Sem;
                tilesSxthSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_SxthSem;
            }

            

            // седьмой семестр
            var itemsSvnthSem = lbSvnthSem.Items;
            List<ListBoxItem> listBoxItemsSvnthSem = new List<ListBoxItem>();
            listBoxItemsSvnthSem.AddRange(itemsSvnthSem.OfType<ListBoxItem>());

            List<Tile> tilesSvnthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsSvnthSem.Count; i++)
                tilesSvnthSem.Add((Tile)listBoxItemsSvnthSem[i].Content);


            for (int i = 0; i < tilesSvnthSem.Count; i++) {
                sumSvnthSem += Convert.ToInt32(tilesSvnthSem[i].Total.Text);
                //tilesSvnthSem[i].Total.ValueChanged += Total_ValueChanged_Svnth_Sem;
                tilesSvnthSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_SvnthSem;
            }

            

            // восьмой семестр
            var itemsEgthSem = lbEgthSem.Items;
            List<ListBoxItem> listBoxItemsEgthSem = new List<ListBoxItem>();
            listBoxItemsEgthSem.AddRange(itemsEgthSem.OfType<ListBoxItem>());

            List<Tile> tilesEgthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsEgthSem.Count; i++)
                tilesEgthSem.Add((Tile)listBoxItemsEgthSem[i].Content);


            for (int i = 0; i < tilesEgthSem.Count; i++) {
                sumEgthSem += Convert.ToInt32(tilesEgthSem[i].Total.Text);
                //tilesEgthSem[i].Total.ValueChanged += Total_ValueChanged_Egth_Sem;
                tilesEgthSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_EgthSem;
            }

            
            #endregion

            ((INotifyCollectionChanged)lbBank.Items).CollectionChanged += bank_CollectionChanged; ;
            ((INotifyCollectionChanged)lbFrstSem.Items).CollectionChanged += frstSem_CollectionChanged;
            ((INotifyCollectionChanged)lbScndSem.Items).CollectionChanged += scndSem_CollectionChanged;
            ((INotifyCollectionChanged)lbThrdSem.Items).CollectionChanged += thrdSem_CollectionChanged;
            ((INotifyCollectionChanged)lbFrthSem.Items).CollectionChanged += frthSem_CollectionChanged;
            ((INotifyCollectionChanged)lbFfthSem.Items).CollectionChanged += ffthSem_CollectionChanged;
            ((INotifyCollectionChanged)lbSxthSem.Items).CollectionChanged += sxthSem_CollectionChanged;
            ((INotifyCollectionChanged)lbSvnthSem.Items).CollectionChanged += svnthSem_CollectionChanged;
            ((INotifyCollectionChanged)lbEgthSem.Items).CollectionChanged += egthSem_CollectionChanged;

        }

        // итоговые значения intupdown
        #region
        // первый семестр
        #region
        private void TheoryRab_ValueChanged_Frst_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {

                sumFrstSem++;
                sumFrstSemTheoryRab++;
                
                labelfrstSem.Content = $"1  :  {sumFrstSem} ({sumFrstSemTheoryRab} + " +
                    $"{sumFrstSemPromAttest} + {sumFrstSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem + 
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
            else {
                sumFrstSem--;
                sumFrstSemTheoryRab--;
                
                labelfrstSem.Content = $"1  :  {sumFrstSem} ({sumFrstSemTheoryRab} + " +
                    $"{sumFrstSemPromAttest} + {sumFrstSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
        }

        private void PromAttest_ValueChanged_Frst_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {

                sumFrstSem++;
                sumFrstSemPromAttest++;
                labelfrstSem.Content = $"1  :  {sumFrstSem} ({sumFrstSemTheoryRab} + " +
                    $"{sumFrstSemPromAttest} + {sumFrstSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
            else {
                sumFrstSem--;
                sumFrstSemPromAttest--;
                labelfrstSem.Content = $"1  :  {sumFrstSem} ({sumFrstSemTheoryRab} + " +
                    $"{sumFrstSemPromAttest} + {sumFrstSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
        }

        private void Kurs_ValueChanged_Frst_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {

                sumFrstSem++;
                sumFrstSemKurs++;
                
                labelfrstSem.Content = $"1  :  {sumFrstSem} ({sumFrstSemTheoryRab} + " +
                    $"{sumFrstSemPromAttest} + {sumFrstSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
            else {
                sumFrstSem--;
                sumFrstSemKurs--;

                labelfrstSem.Content = $"1  :  {sumFrstSem} ({sumFrstSemTheoryRab} + " +
                    $"{sumFrstSemPromAttest} + {sumFrstSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
        }
        #endregion

        // второй семестр
        #region
        private void TheoryRab_ValueChanged_Scnd_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumScndSem++;
                sumScndSemTheoryRab++;

                labelscndSem.Content = $"1  :  {sumScndSem} ({sumScndSemTheoryRab} + " +
                    $"{sumScndSemPromAttest} + {sumScndSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumScndSem--;
                sumScndSemTheoryRab--;

                labelscndSem.Content = $"1  :  {sumScndSem} ({sumScndSemTheoryRab} + " +
                    $"{sumScndSemPromAttest} + {sumScndSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void PromAttest_ValueChanged_Scnd_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumScndSem++;
                sumScndSemPromAttest++;

                labelscndSem.Content = $"1  :  {sumScndSem} ({sumScndSemTheoryRab} + " +
                    $"{sumScndSemPromAttest} + {sumScndSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumScndSem--;
                sumScndSemPromAttest--;

                labelscndSem.Content = $"1  :  {sumScndSem} ({sumScndSemTheoryRab} + " +
                    $"{sumScndSemPromAttest} + {sumScndSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void Kurs_ValueChanged_Scnd_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumScndSem++;
                sumScndSemKurs++;

                labelscndSem.Content = $"1  :  {sumScndSem} ({sumScndSemTheoryRab} + " +
                    $"{sumScndSemPromAttest} + {sumScndSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumScndSem--;
                sumScndSemKurs--;

                labelscndSem.Content = $"1  :  {sumScndSem} ({sumScndSemTheoryRab} + " +
                    $"{sumScndSemPromAttest} + {sumScndSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }
        #endregion

        // третий семестр
        #region
        private void TheoryRab_ValueChanged_Thrd_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumThrdSem++;
                sumThrdSemTheoryRab++;

                labelthrdSem.Content = $"1  :  {sumThrdSem} ({sumThrdSemTheoryRab} + " +
                    $"{sumThrdSemPromAttest} + {sumThrdSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumThrdSem--;
                sumThrdSemTheoryRab--;

                labelthrdSem.Content = $"1  :  {sumThrdSem} ({sumThrdSemTheoryRab} + " +
                    $"{sumThrdSemPromAttest} + {sumThrdSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void PromAttest_ValueChanged_Thrd_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumThrdSem++;
                sumThrdSemPromAttest++;

                labelthrdSem.Content = $"1  :  {sumThrdSem} ({sumThrdSemTheoryRab} + " +
                    $"{sumThrdSemPromAttest} + {sumThrdSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumThrdSem--;
                sumThrdSemPromAttest--;

                labelthrdSem.Content = $"1  :  {sumThrdSem} ({sumThrdSemTheoryRab} + " +
                    $"{sumThrdSemPromAttest} + {sumThrdSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void Kurs_ValueChanged_Thrd_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumThrdSem++;
                sumThrdSemKurs++;

                labelthrdSem.Content = $"1  :  {sumThrdSem} ({sumThrdSemTheoryRab} + " +
                    $"{sumThrdSemPromAttest} + {sumThrdSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumThrdSem--;
                sumThrdSemKurs--;

                labelthrdSem.Content = $"1  :  {sumThrdSem} ({sumThrdSemTheoryRab} + " +
                    $"{sumThrdSemPromAttest} + {sumThrdSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }
        #endregion

        // четвертый семестр
        #region
        private void TheoryRab_ValueChanged_Frth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumFrthSem++;
                sumFrthSemTheoryRab++;

                labelfrthSem.Content = $"1  :  {sumFrthSem} ({sumFrthSemTheoryRab} + " +
                    $"{sumFrthSemPromAttest} + {sumFrthSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumFrthSem--;
                sumFrthSemTheoryRab--;

                labelfrthSem.Content = $"1  :  {sumFrthSem} ({sumFrthSemTheoryRab} + " +
                    $"{sumFrthSemPromAttest} + {sumFrthSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void PromAttest_ValueChanged_Frth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumFrthSem++;
                sumFrthSemPromAttest++;

                labelfrthSem.Content = $"1  :  {sumFrthSem} ({sumFrthSemTheoryRab} + " +
                    $"{sumFrthSemPromAttest} + {sumFrthSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumFrthSem--;
                sumFrthSemPromAttest--;

                labelfrthSem.Content = $"1  :  {sumFrthSem} ({sumFrthSemTheoryRab} + " +
                    $"{sumFrthSemPromAttest} + {sumFrthSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void Kurs_ValueChanged_Frth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumFrthSem++;
                sumFrthSemKurs++;

                labelfrthSem.Content = $"1  :  {sumFrthSem} ({sumFrthSemTheoryRab} + " +
                    $"{sumFrthSemPromAttest} + {sumFrthSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumFrthSem--;
                sumFrthSemKurs--;

                labelfrthSem.Content = $"1  :  {sumFrthSem} ({sumFrthSemTheoryRab} + " +
                    $"{sumFrthSemPromAttest} + {sumFrthSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }
        #endregion

        // пятый семестр
        #region
        private void TheoryRab_ValueChanged_Ffth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumFfthSem++;
                sumFfthSemTheoryRab++;

                labelffthSem.Content = $"1  :  {sumFfthSem} ({sumFfthSemTheoryRab} + " +
                    $"{sumFfthSemPromAttest} + {sumFfthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumFfthSem--;
                sumFfthSemTheoryRab--;

                labelffthSem.Content = $"1  :  {sumFfthSem} ({sumFfthSemTheoryRab} + " +
                    $"{sumFfthSemPromAttest} + {sumFfthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void PromAttest_ValueChanged_Ffth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumFfthSem++;
                sumFfthSemPromAttest++;

                labelffthSem.Content = $"1  :  {sumFfthSem} ({sumFfthSemTheoryRab} + " +
                    $"{sumFfthSemPromAttest} + {sumFfthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumFfthSem--;
                sumFfthSemPromAttest--;

                labelffthSem.Content = $"1  :  {sumFfthSem} ({sumFfthSemTheoryRab} + " +
                    $"{sumFfthSemPromAttest} + {sumFfthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void Kurs_ValueChanged_Ffth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumFfthSem++;
                sumFfthSemKurs++;

                labelffthSem.Content = $"1  :  {sumFfthSem} ({sumFfthSemTheoryRab} + " +
                    $"{sumFfthSemPromAttest} + {sumFfthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumFfthSem--;
                sumFfthSemKurs--;

                labelffthSem.Content = $"1  :  {sumFfthSem} ({sumFfthSemTheoryRab} + " +
                    $"{sumFfthSemPromAttest} + {sumFfthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }
        #endregion

        // шестой семестр
        #region
        private void TheoryRab_ValueChanged_Sxth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumSxthSem++;
                sumSxthSemTheoryRab++;

                labelsxthSem.Content = $"1  :  {sumSxthSem} ({sumSxthSemTheoryRab} + " +
                    $"{sumSxthSemPromAttest} + {sumSxthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumSxthSem--;
                sumSxthSemTheoryRab--;

                labelsxthSem.Content = $"1  :  {sumSxthSem} ({sumSxthSemTheoryRab} + " +
                    $"{sumSxthSemPromAttest} + {sumSxthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void PromAttest_ValueChanged_Sxth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumSxthSem++;
                sumSxthSemPromAttest++;

                labelsxthSem.Content = $"1  :  {sumSxthSem} ({sumSxthSemTheoryRab} + " +
                    $"{sumSxthSemPromAttest} + {sumSxthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumSxthSem--;
                sumSxthSemPromAttest--;

                labelsxthSem.Content = $"1  :  {sumSxthSem} ({sumSxthSemTheoryRab} + " +
                    $"{sumSxthSemPromAttest} + {sumSxthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void Kurs_ValueChanged_Sxth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumSxthSem++;
                sumSxthSemKurs++;

                labelsxthSem.Content = $"1  :  {sumSxthSem} ({sumSxthSemTheoryRab} + " +
                    $"{sumSxthSemPromAttest} + {sumSxthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumSxthSem--;
                sumSxthSemKurs--;

                labelsxthSem.Content = $"1  :  {sumSxthSem} ({sumSxthSemTheoryRab} + " +
                    $"{sumSxthSemPromAttest} + {sumSxthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }
        #endregion

        // седьмой семестр
        #region
        private void TheoryRab_ValueChanged_Svnth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumSvnthSem++;
                sumSvnthSemTheoryRab++;

                labelsvnthSem.Content = $"1  :  {sumSvnthSem} ({sumSvnthSemTheoryRab} + " +
                    $"{sumSvnthSemPromAttest} + {sumSvnthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumSvnthSem--;
                sumSvnthSemTheoryRab--;

                labelsvnthSem.Content = $"1  :  {sumSvnthSem} ({sumSvnthSemTheoryRab} + " +
                    $"{sumSvnthSemPromAttest} + {sumSvnthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void PromAttest_ValueChanged_Svnth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumSvnthSem++;
                sumSvnthSemPromAttest++;

                labelsvnthSem.Content = $"1  :  {sumSvnthSem} ({sumSvnthSemTheoryRab} + " +
                    $"{sumSvnthSemPromAttest} + {sumSvnthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumSvnthSem--;
                sumSvnthSemPromAttest--;

                labelsvnthSem.Content = $"1  :  {sumSvnthSem} ({sumSvnthSemTheoryRab} + " +
                    $"{sumSvnthSemPromAttest} + {sumSvnthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void Kurs_ValueChanged_Svnth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumSvnthSem++;
                sumSvnthSemKurs++;

                labelsvnthSem.Content = $"1  :  {sumSvnthSem} ({sumSvnthSemTheoryRab} + " +
                    $"{sumSvnthSemPromAttest} + {sumSvnthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumSvnthSem--;
                sumSvnthSemKurs--;

                labelsvnthSem.Content = $"1  :  {sumSvnthSem} ({sumSvnthSemTheoryRab} + " +
                    $"{sumSvnthSemPromAttest} + {sumSvnthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }
        #endregion

        // восьмой семестр
        #region
        private void TheoryRab_ValueChanged_Egth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumEgthSem++;
                sumEgthSemTheoryRab++;

                labelegthSem.Content = $"1  :  {sumEgthSem} ({sumEgthSemTheoryRab} + " +
                    $"{sumEgthSemPromAttest} + {sumEgthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumEgthSem--;
                sumEgthSemTheoryRab--;

                labelegthSem.Content = $"1  :  {sumEgthSem} ({sumEgthSemTheoryRab} + " +
                    $"{sumEgthSemPromAttest} + {sumEgthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void PromAttest_ValueChanged_Egth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumEgthSem++;
                sumEgthSemPromAttest++;

                labelegthSem.Content = $"1  :  {sumEgthSem} ({sumEgthSemTheoryRab} + " +
                    $"{sumEgthSemPromAttest} + {sumEgthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumEgthSem--;
                sumEgthSemPromAttest--;

                labelegthSem.Content = $"1  :  {sumEgthSem} ({sumEgthSemTheoryRab} + " +
                    $"{sumEgthSemPromAttest} + {sumEgthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void Kurs_ValueChanged_Egth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumEgthSem++;
                sumEgthSemKurs++;

                labelegthSem.Content = $"1  :  {sumEgthSem} ({sumEgthSemTheoryRab} + " +
                    $"{sumEgthSemPromAttest} + {sumEgthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;
            }
            else {
                sumEgthSem--;
                sumEgthSemKurs--;

                labelegthSem.Content = $"1  :  {sumEgthSem} ({sumEgthSemTheoryRab} + " +
                    $"{sumEgthSemPromAttest} + {sumEgthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }
        #endregion
        #endregion

        // кнопки закрыть
        #region
        private void BtnThrowOfTile_Click_Bank(object sender,RoutedEventArgs e) {
            var itemsBank = lbBank.Items;
            List<ListBoxItem> listBoxBank = new List<ListBoxItem>();
            listBoxBank.AddRange(itemsBank.OfType<ListBoxItem>());

            List<Tile> tilesBank = new List<Tile>();

            for (int i = 0; i < listBoxBank.Count; i++)
                tilesBank.Add((Tile)listBoxBank[i].Content);

            for (int i = 0; i < tilesBank.Count; i++) {
                if (tilesBank[i].btnThrowOfTile.IsMouseOver) {
                    itemsBank.RemoveAt(i);
                    tilesBank.RemoveAt(i);
                    listBoxBank.RemoveAt(i);
                }
            }
        }

        private void BtnThrowOfTile_Click_FrstSem(object sender,RoutedEventArgs e) {

            var itemsFrstSem = lbFrstSem.Items;

            ListBoxItem delElem = null;

            List<ListBoxItem> listBoxItemsFrstSem = new List<ListBoxItem>();
            listBoxItemsFrstSem.AddRange(itemsFrstSem.OfType<ListBoxItem>());

            List<Tile> tilesFrstSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsFrstSem.Count; i++)
                tilesFrstSem.Add((Tile)listBoxItemsFrstSem[i].Content);


            for (int i = 0; i < tilesFrstSem.Count; i++) {
                if (tilesFrstSem[i].btnThrowOfTile.IsMouseOver) {
                    delElem = (ListBoxItem)itemsFrstSem[i];
                    itemsFrstSem.RemoveAt(i);
                    tilesFrstSem.RemoveAt(i);
                    listBoxItemsFrstSem.RemoveAt(i);
                }
            }

            if (delElem != null)
                lbBank.Items.Add(delElem);

        }

        private void BtnThrowOfTile_Click_ScndSem(object sender,RoutedEventArgs e) {

            var itemsScndSem = lbScndSem.Items;

            ListBoxItem delElem = null;

            List<ListBoxItem> listBoxItemsScndSem = new List<ListBoxItem>();
            listBoxItemsScndSem.AddRange(itemsScndSem.OfType<ListBoxItem>());

            List<Tile> tilesScndSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsScndSem.Count; i++)
                tilesScndSem.Add((Tile)listBoxItemsScndSem[i].Content);


            for (int i = 0; i < tilesScndSem.Count; i++) {
                if (tilesScndSem[i].btnThrowOfTile.IsMouseOver) {
                    delElem = (ListBoxItem)itemsScndSem[i];
                    itemsScndSem.RemoveAt(i);
                    tilesScndSem.RemoveAt(i);
                    listBoxItemsScndSem.RemoveAt(i);
                }
            }

            if (delElem != null)
                lbBank.Items.Add(delElem);

        }

        private void BtnThrowOfTile_Click_ThrdSem(object sender,RoutedEventArgs e) {

            var itemsThrdSem = lbThrdSem.Items;

            ListBoxItem delElem = null;

            List<ListBoxItem> listBoxItemsThrdSem = new List<ListBoxItem>();
            listBoxItemsThrdSem.AddRange(itemsThrdSem.OfType<ListBoxItem>());

            List<Tile> tilesThrdSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsThrdSem.Count; i++)
                tilesThrdSem.Add((Tile)listBoxItemsThrdSem[i].Content);


            for (int i = 0; i < tilesThrdSem.Count; i++) {
                if (tilesThrdSem[i].btnThrowOfTile.IsMouseOver) {
                    delElem = (ListBoxItem)itemsThrdSem[i];
                    itemsThrdSem.RemoveAt(i);
                    tilesThrdSem.RemoveAt(i);
                    listBoxItemsThrdSem.RemoveAt(i);
                }
            }

            if (delElem != null)
                lbBank.Items.Add(delElem);

        }

        private void BtnThrowOfTile_Click_FrthSem(object sender,RoutedEventArgs e) {

            var itemsFrthSem = lbFrthSem.Items;

            ListBoxItem delElem = null;

            List<ListBoxItem> listBoxItemsFrthSem = new List<ListBoxItem>();
            listBoxItemsFrthSem.AddRange(itemsFrthSem.OfType<ListBoxItem>());

            List<Tile> tilesFrthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsFrthSem.Count; i++)
                tilesFrthSem.Add((Tile)listBoxItemsFrthSem[i].Content);


            for (int i = 0; i < tilesFrthSem.Count; i++) {
                if (tilesFrthSem[i].btnThrowOfTile.IsMouseOver) {
                    delElem = (ListBoxItem)itemsFrthSem[i];
                    itemsFrthSem.RemoveAt(i);
                    tilesFrthSem.RemoveAt(i);
                    listBoxItemsFrthSem.RemoveAt(i);
                }
            }

            if (delElem != null)
                lbBank.Items.Add(delElem);

        }

        private void BtnThrowOfTile_Click_FfthSem(object sender,RoutedEventArgs e) {

            var itemsFfthSem = lbFfthSem.Items;

            ListBoxItem delElem = null;

            List<ListBoxItem> listBoxItemsFfthSem = new List<ListBoxItem>();
            listBoxItemsFfthSem.AddRange(itemsFfthSem.OfType<ListBoxItem>());

            List<Tile> tilesFfthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsFfthSem.Count; i++)
                tilesFfthSem.Add((Tile)listBoxItemsFfthSem[i].Content);


            for (int i = 0; i < tilesFfthSem.Count; i++) {
                if (tilesFfthSem[i].btnThrowOfTile.IsMouseOver) {
                    delElem = (ListBoxItem)itemsFfthSem[i];
                    itemsFfthSem.RemoveAt(i);
                    tilesFfthSem.RemoveAt(i);
                    listBoxItemsFfthSem.RemoveAt(i);
                }
            }

            if (delElem != null)
                lbBank.Items.Add(delElem);

        }

        private void BtnThrowOfTile_Click_SxthSem(object sender,RoutedEventArgs e) {

            var itemsSxthSem = lbSxthSem.Items;

            ListBoxItem delElem = null;

            List<ListBoxItem> listBoxItemsSxthSem = new List<ListBoxItem>();
            listBoxItemsSxthSem.AddRange(itemsSxthSem.OfType<ListBoxItem>());

            List<Tile> tilesSxthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsSxthSem.Count; i++)
                tilesSxthSem.Add((Tile)listBoxItemsSxthSem[i].Content);


            for (int i = 0; i < tilesSxthSem.Count; i++) {
                if (tilesSxthSem[i].btnThrowOfTile.IsMouseOver) {
                    delElem = (ListBoxItem)itemsSxthSem[i];
                    itemsSxthSem.RemoveAt(i);
                    tilesSxthSem.RemoveAt(i);
                    listBoxItemsSxthSem.RemoveAt(i);
                }
            }

            if (delElem != null)
                lbBank.Items.Add(delElem);

        }

        private void BtnThrowOfTile_Click_SvnthSem(object sender,RoutedEventArgs e) {

            var itemsSvnthSem = lbSvnthSem.Items;

            ListBoxItem delElem = null;

            List<ListBoxItem> listBoxItemsSvnthSem = new List<ListBoxItem>();
            listBoxItemsSvnthSem.AddRange(itemsSvnthSem.OfType<ListBoxItem>());

            List<Tile> tilesSvnthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsSvnthSem.Count; i++)
                tilesSvnthSem.Add((Tile)listBoxItemsSvnthSem[i].Content);


            for (int i = 0; i < tilesSvnthSem.Count; i++) {
                if (tilesSvnthSem[i].btnThrowOfTile.IsMouseOver) {
                    delElem = (ListBoxItem)itemsSvnthSem[i];
                    itemsSvnthSem.RemoveAt(i);
                    tilesSvnthSem.RemoveAt(i);
                    listBoxItemsSvnthSem.RemoveAt(i);
                }
            }

            if (delElem != null)
                lbBank.Items.Add(delElem);

        }

        private void BtnThrowOfTile_Click_EgthSem(object sender,RoutedEventArgs e) {

            var itemsEgthSem = lbEgthSem.Items;

            ListBoxItem delElem = null;

            List<ListBoxItem> listBoxItemsEgthSem = new List<ListBoxItem>();
            listBoxItemsEgthSem.AddRange(itemsEgthSem.OfType<ListBoxItem>());

            List<Tile> tilesEgthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsEgthSem.Count; i++)
                tilesEgthSem.Add((Tile)listBoxItemsEgthSem[i].Content);


            for (int i = 0; i < tilesEgthSem.Count; i++) {
                if (tilesEgthSem[i].btnThrowOfTile.IsMouseOver) {
                    delElem = (ListBoxItem)itemsEgthSem[i];
                    itemsEgthSem.RemoveAt(i);
                    tilesEgthSem.RemoveAt(i);
                    listBoxItemsEgthSem.RemoveAt(i);
                }
            }

            if (delElem != null)
                lbBank.Items.Add(delElem);

        }
        #endregion

        // операции изменения коллекций семестров и банка
        #region
        private void bank_CollectionChanged(object sender,NotifyCollectionChangedEventArgs e) {
            if (e.Action == NotifyCollectionChangedAction.Add) {

                var itms = e.NewItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++)
                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_Bank;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++)
                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_Bank;

            }
        }

        private void frstSem_CollectionChanged(object sender,NotifyCollectionChangedEventArgs e) {


            if (e.Action == NotifyCollectionChangedAction.Add) {

                var itms = e.NewItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged += TheoryRab_ValueChanged_Frst_Sem;
                    tiles[i].PromAttest.ValueChanged += PromAttest_ValueChanged_Frst_Sem;
                    tiles[i].Kurs.ValueChanged += Kurs_ValueChanged_Frst_Sem;

                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FrstSem;
                    sumFrstSem += Convert.ToInt32(tiles[i].Total.Text);
                    sumFrstSemTheoryRab += Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumFrstSemPromAttest += Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumFrstSemKurs += Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelfrstSem.Content = $"1  :  {sumFrstSem} ({sumFrstSemTheoryRab} + " +
                    $"{sumFrstSemPromAttest} + {sumFrstSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged -= TheoryRab_ValueChanged_Frst_Sem;
                    tiles[i].PromAttest.ValueChanged -= PromAttest_ValueChanged_Frst_Sem;
                    tiles[i].Kurs.ValueChanged -= Kurs_ValueChanged_Frst_Sem;

                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_FrstSem;
                    sumFrstSem -= Convert.ToInt32(tiles[i].Total.Text);
                    sumFrstSemTheoryRab -= Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumFrstSemPromAttest -= Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumFrstSemKurs -= Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelfrstSem.Content = $"1  :  {sumFrstSem} ({sumFrstSemTheoryRab} + " +
                    $"{sumFrstSemPromAttest} + {sumFrstSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void scndSem_CollectionChanged(object sender,NotifyCollectionChangedEventArgs e) {

            if (e.Action == NotifyCollectionChangedAction.Add) {

                var itms = e.NewItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged += TheoryRab_ValueChanged_Scnd_Sem;
                    tiles[i].PromAttest.ValueChanged += PromAttest_ValueChanged_Scnd_Sem;
                    tiles[i].Kurs.ValueChanged += Kurs_ValueChanged_Scnd_Sem;

                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_ScndSem;
                    sumScndSem += Convert.ToInt32(tiles[i].Total.Text);
                    sumScndSemTheoryRab += Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumScndSemPromAttest += Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumScndSemKurs += Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelscndSem.Content = $"1  :  {sumScndSem} ({sumScndSemTheoryRab} + " +
                    $"{sumScndSemPromAttest} + {sumScndSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged -= TheoryRab_ValueChanged_Scnd_Sem;
                    tiles[i].PromAttest.ValueChanged -= PromAttest_ValueChanged_Scnd_Sem;
                    tiles[i].Kurs.ValueChanged -= Kurs_ValueChanged_Scnd_Sem;

                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_ScndSem;
                    sumScndSem -= Convert.ToInt32(tiles[i].Total.Text);
                    sumScndSemTheoryRab -= Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumScndSemPromAttest -= Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumScndSemKurs -= Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelscndSem.Content = $"1  :  {sumScndSem} ({sumScndSemTheoryRab} + " +
                    $"{sumScndSemPromAttest} + {sumScndSemKurs})";

                labelFrstKurs.Content = $"1  :  {sumFrstSem + sumScndSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void thrdSem_CollectionChanged(object sender,NotifyCollectionChangedEventArgs e) {

            if (e.Action == NotifyCollectionChangedAction.Add) {

                var itms = e.NewItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged += TheoryRab_ValueChanged_Thrd_Sem;
                    tiles[i].PromAttest.ValueChanged += PromAttest_ValueChanged_Thrd_Sem;
                    tiles[i].Kurs.ValueChanged += Kurs_ValueChanged_Thrd_Sem;

                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_ThrdSem;
                    sumThrdSem += Convert.ToInt32(tiles[i].Total.Text);
                    sumThrdSemTheoryRab += Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumThrdSemPromAttest += Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumThrdSemKurs += Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelthrdSem.Content = $"1  :  {sumThrdSem} ({sumThrdSemTheoryRab} + " +
                    $"{sumThrdSemPromAttest} + {sumThrdSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged -= TheoryRab_ValueChanged_Thrd_Sem;
                    tiles[i].PromAttest.ValueChanged -= PromAttest_ValueChanged_Thrd_Sem;
                    tiles[i].Kurs.ValueChanged -= Kurs_ValueChanged_Thrd_Sem;

                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_ThrdSem;
                    sumThrdSem -= Convert.ToInt32(tiles[i].Total.Text);
                    sumThrdSemTheoryRab -= Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumThrdSemPromAttest -= Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumThrdSemKurs -= Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelthrdSem.Content = $"1  :  {sumThrdSem} ({sumThrdSemTheoryRab} + " +
                    $"{sumThrdSemPromAttest} + {sumThrdSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void frthSem_CollectionChanged(object sender,NotifyCollectionChangedEventArgs e) {

            if (e.Action == NotifyCollectionChangedAction.Add) {

                var itms = e.NewItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged += TheoryRab_ValueChanged_Frth_Sem;
                    tiles[i].PromAttest.ValueChanged += PromAttest_ValueChanged_Frth_Sem;
                    tiles[i].Kurs.ValueChanged += Kurs_ValueChanged_Frth_Sem;

                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FrthSem;
                    sumFrthSem += Convert.ToInt32(tiles[i].Total.Text);
                    sumFrthSemTheoryRab += Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumFrthSemPromAttest += Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumFrthSemKurs += Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelfrthSem.Content = $"1  :  {sumFrthSem} ({sumFrthSemTheoryRab} + " +
                    $"{sumFrthSemPromAttest} + {sumFrthSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged -= TheoryRab_ValueChanged_Frth_Sem;
                    tiles[i].PromAttest.ValueChanged -= PromAttest_ValueChanged_Frth_Sem;
                    tiles[i].Kurs.ValueChanged -= Kurs_ValueChanged_Frth_Sem;

                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_FrthSem;
                    sumFrthSem -= Convert.ToInt32(tiles[i].Total.Text);
                    sumFrthSemTheoryRab -= Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumFrthSemPromAttest -= Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumFrthSemKurs -= Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelfrthSem.Content = $"1  :  {sumFrthSem} ({sumFrthSemTheoryRab} + " +
                    $"{sumFrthSemPromAttest} + {sumFrthSemKurs})";

                labelScndKurs.Content = $"1  :  {sumThrdSem + sumFrthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void ffthSem_CollectionChanged(object sender,NotifyCollectionChangedEventArgs e) {

            if (e.Action == NotifyCollectionChangedAction.Add) {

                var itms = e.NewItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged += TheoryRab_ValueChanged_Ffth_Sem;
                    tiles[i].PromAttest.ValueChanged += PromAttest_ValueChanged_Ffth_Sem;
                    tiles[i].Kurs.ValueChanged += Kurs_ValueChanged_Ffth_Sem;

                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FfthSem;
                    sumFfthSem += Convert.ToInt32(tiles[i].Total.Text);
                    sumFfthSemTheoryRab += Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumFfthSemPromAttest += Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumFfthSemKurs += Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelffthSem.Content = $"1  :  {sumFfthSem} ({sumFfthSemTheoryRab} + " +
                    $"{sumFfthSemPromAttest} + {sumFfthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged -= TheoryRab_ValueChanged_Ffth_Sem;
                    tiles[i].PromAttest.ValueChanged -= PromAttest_ValueChanged_Ffth_Sem;
                    tiles[i].Kurs.ValueChanged -= Kurs_ValueChanged_Ffth_Sem;

                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_FfthSem;
                    sumFfthSem -= Convert.ToInt32(tiles[i].Total.Text);
                    sumFfthSemTheoryRab -= Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumFfthSemPromAttest -= Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumFfthSemKurs -= Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelffthSem.Content = $"1  :  {sumFfthSem} ({sumFfthSemTheoryRab} + " +
                    $"{sumFfthSemPromAttest} + {sumFfthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void sxthSem_CollectionChanged(object sender,NotifyCollectionChangedEventArgs e) {

            if (e.Action == NotifyCollectionChangedAction.Add) {

                var itms = e.NewItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged += TheoryRab_ValueChanged_Sxth_Sem;
                    tiles[i].PromAttest.ValueChanged += PromAttest_ValueChanged_Sxth_Sem;
                    tiles[i].Kurs.ValueChanged += Kurs_ValueChanged_Sxth_Sem;

                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_SxthSem;
                    sumSxthSem += Convert.ToInt32(tiles[i].Total.Text);
                    sumSxthSemTheoryRab += Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumSxthSemPromAttest += Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumSxthSemKurs += Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelsxthSem.Content = $"1  :  {sumSxthSem} ({sumSxthSemTheoryRab} + " +
                    $"{sumSxthSemPromAttest} + {sumSxthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged -= TheoryRab_ValueChanged_Sxth_Sem;
                    tiles[i].PromAttest.ValueChanged -= PromAttest_ValueChanged_Sxth_Sem;
                    tiles[i].Kurs.ValueChanged -= Kurs_ValueChanged_Sxth_Sem;

                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_SxthSem;
                    sumSxthSem -= Convert.ToInt32(tiles[i].Total.Text);
                    sumSxthSemTheoryRab -= Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumSxthSemPromAttest -= Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumSxthSemKurs -= Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelsxthSem.Content = $"1  :  {sumSxthSem} ({sumSxthSemTheoryRab} + " +
                    $"{sumSxthSemPromAttest} + {sumSxthSemKurs})";

                labelThrdKurs.Content = $"1  :  {sumFfthSem + sumSxthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void svnthSem_CollectionChanged(object sender,NotifyCollectionChangedEventArgs e) {

            if (e.Action == NotifyCollectionChangedAction.Add) {

                var itms = e.NewItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged += TheoryRab_ValueChanged_Svnth_Sem;
                    tiles[i].PromAttest.ValueChanged += PromAttest_ValueChanged_Svnth_Sem;
                    tiles[i].Kurs.ValueChanged += Kurs_ValueChanged_Svnth_Sem;

                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_SvnthSem;
                    sumSvnthSem += Convert.ToInt32(tiles[i].Total.Text);
                    sumSvnthSemTheoryRab += Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumSvnthSemPromAttest += Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumSvnthSemKurs += Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelsvnthSem.Content = $"1  :  {sumSvnthSem} ({sumSvnthSemTheoryRab} + " +
                    $"{sumSvnthSemPromAttest} + {sumSvnthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged -= TheoryRab_ValueChanged_Svnth_Sem;
                    tiles[i].PromAttest.ValueChanged -= PromAttest_ValueChanged_Svnth_Sem;
                    tiles[i].Kurs.ValueChanged -= Kurs_ValueChanged_Svnth_Sem;

                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_SvnthSem;
                    sumSvnthSem -= Convert.ToInt32(tiles[i].Total.Text);
                    sumSvnthSemTheoryRab -= Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumSvnthSemPromAttest -= Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumSvnthSemKurs -= Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelsvnthSem.Content = $"1  :  {sumSvnthSem} ({sumSvnthSemTheoryRab} + " +
                    $"{sumSvnthSemPromAttest} + {sumSvnthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }

        private void egthSem_CollectionChanged(object sender,NotifyCollectionChangedEventArgs e) {

            if (e.Action == NotifyCollectionChangedAction.Add) {

                var itms = e.NewItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged += TheoryRab_ValueChanged_Egth_Sem;
                    tiles[i].PromAttest.ValueChanged += PromAttest_ValueChanged_Egth_Sem;
                    tiles[i].Kurs.ValueChanged += Kurs_ValueChanged_Egth_Sem;

                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_EgthSem;
                    sumEgthSem += Convert.ToInt32(tiles[i].Total.Text);
                    sumEgthSemTheoryRab += Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumEgthSemPromAttest += Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumEgthSemKurs += Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelegthSem.Content = $"1  :  {sumEgthSem} ({sumEgthSemTheoryRab} + " +
                    $"{sumEgthSemPromAttest} + {sumEgthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].TheoryRab.ValueChanged -= TheoryRab_ValueChanged_Egth_Sem;
                    tiles[i].PromAttest.ValueChanged -= PromAttest_ValueChanged_Egth_Sem;
                    tiles[i].Kurs.ValueChanged -= Kurs_ValueChanged_Egth_Sem;

                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_EgthSem;
                    sumEgthSem -= Convert.ToInt32(tiles[i].Total.Text);
                    sumEgthSemTheoryRab -= Convert.ToInt32(tiles[i].TheoryRab.Value);
                    sumEgthSemPromAttest -= Convert.ToInt32(tiles[i].PromAttest.Value);
                    sumEgthSemKurs -= Convert.ToInt32(tiles[i].Kurs.Value);
                }

                labelegthSem.Content = $"1  :  {sumEgthSem} ({sumEgthSemTheoryRab} + " +
                    $"{sumEgthSemPromAttest} + {sumEgthSemKurs})";

                labelFrthKurs.Content = $"1  :  {sumSvnthSem + sumEgthSem}";

                CountAllSem.Content = sumFrstSem + sumScndSem + sumThrdSem + sumFrthSem +
                    sumFfthSem + sumSxthSem + sumSvnthSem + sumEgthSem;

            }
        }
        #endregion

        private void btnAddElem_Click(object sender,RoutedEventArgs e) {

            var win_discp = new Disciplines_editor();
            IList get_list_disciplines;
            List<Discipline_DataGrid> convert_discp;

            win_discp.ShowDialog();

            if (win_discp.DialogResult == true) {

                get_list_disciplines = win_discp.list_of_elements();
                convert_discp = new List<Discipline_DataGrid>();

                ListBoxItem lbi;
                Tile elem;

                for (int i = 0; i < get_list_disciplines.Count; i++)
                    convert_discp.Add((Discipline_DataGrid)get_list_disciplines[i]);

                for (int i = 0; i < convert_discp.Count; i++) {

                    lbi = new ListBoxItem();
                    elem = new Tile();

                    elem.TheoryRab.Value = convert_discp[i].TheoryRab;
                    elem.PromAttest.Value = convert_discp[i].PromAttest;
                    elem.Kurs.Value = convert_discp[i].Kurs;
                    elem.Total.Text = (elem.TheoryRab.Value + elem.PromAttest.Value + elem.Kurs.Value).ToString();
                    elem.SokrNameD.Text = convert_discp[i].SokrName;
                    elem.SokrNameD.ToolTip = convert_discp[i].Name;

                    lbi.Content = elem;
                    lbi.BorderBrush = Brushes.Black;
                    lbi.BorderThickness = new Thickness(1,1,1,1);
                    lbi.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(convert_discp[i].CvetK);
                    lbi.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    lbBank.Items.Add(lbi);
                }
            }
        }

        private void lbFrstSem_Initialized(object sender,EventArgs e) {

            // первый семестр
            var itemsFrstSem = lbFrstSem.Items;
            List<ListBoxItem> listBoxItemsFrstSem = new List<ListBoxItem>();
            listBoxItemsFrstSem.AddRange(itemsFrstSem.OfType<ListBoxItem>());

            List<Tile> tilesFrstSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsFrstSem.Count; i++)
                tilesFrstSem.Add((Tile)listBoxItemsFrstSem[i].Content);


            for (int i = 0; i < tilesFrstSem.Count; i++) {
                sumFrstSem += Convert.ToInt32(tilesFrstSem[i].Total.Text);
                //tilesFrstSem[i].Total.ValueChanged += Total_ValueChanged_First_Sem;
                tilesFrstSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FrstSem;
            }

        }

        private void lbBank_Initialized(object sender,EventArgs e) {

            var itemsBank = lbBank.Items;
            List<ListBoxItem> listBoxBank = new List<ListBoxItem>();
            listBoxBank.AddRange(itemsBank.OfType<ListBoxItem>());

            List<Tile> tilesBank = new List<Tile>();

            for (int i = 0; i < listBoxBank.Count; i++)
                tilesBank.Add((Tile)listBoxBank[i].Content);


            for (int i = 0; i < tilesBank.Count; i++)
                tilesBank[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_Bank;

        }

        
        
    }
}
