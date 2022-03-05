using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Win32;

namespace Kernel_of_curriculum {
    /// <summary>
    /// Логика взаимодействия для Main_window.xaml
    /// </summary>
    public partial class Main_window : Window {

        [Serializable]
        class TileSer {

            public int TheoryRab { get; set; }
            public int PromAttest { get; set; }
            public int Kurs { get; set; }
            public string Total { get; set; }
            public string SokrNameD { get; set; }
            public string NameD { get; set; }
            public string CvetK { get; set; }

            public TileSer(int theoryRab,int promAttest,int kurs,
                string total,string sokrNameD,string nameD,string cvetK) {

                TheoryRab = theoryRab;
                PromAttest = promAttest;
                Kurs = kurs;
                Total = total;
                SokrNameD = sokrNameD;
                NameD = nameD;
                CvetK = cvetK;
            }
        }


        #region переменные сумм
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

        #region плитки для сериализации
        List<TileSer> tilesBank = new List<TileSer>();
        List<TileSer> tilesFrstSem = new List<TileSer>();
        List<TileSer> tilesScndSem = new List<TileSer>();
        List<TileSer> tilesThrdSem = new List<TileSer>();
        List<TileSer> tilesFrthSem = new List<TileSer>();
        List<TileSer> tilesFfthSem = new List<TileSer>();
        List<TileSer> tilesSxthSem = new List<TileSer>();
        List<TileSer> tilesSvnthSem = new List<TileSer>();
        List<TileSer> tilesEgthSem = new List<TileSer>();


        List<List<TileSer>> alltiles = new List<List<TileSer>>();
        List<List<TileSer>> alltiles_deser = new List<List<TileSer>>();

        #endregion

        public Main_window() {
            InitializeComponent();


            ((INotifyCollectionChanged)lbBank.Items).CollectionChanged += bank_CollectionChanged; ;
            ((INotifyCollectionChanged)lbFrstSem.Items).CollectionChanged += frstSem_CollectionChanged;
            ((INotifyCollectionChanged)lbScndSem.Items).CollectionChanged += scndSem_CollectionChanged;
            ((INotifyCollectionChanged)lbThrdSem.Items).CollectionChanged += thrdSem_CollectionChanged;
            ((INotifyCollectionChanged)lbFrthSem.Items).CollectionChanged += frthSem_CollectionChanged;
            ((INotifyCollectionChanged)lbFfthSem.Items).CollectionChanged += ffthSem_CollectionChanged;
            ((INotifyCollectionChanged)lbSxthSem.Items).CollectionChanged += sxthSem_CollectionChanged;
            ((INotifyCollectionChanged)lbSvnthSem.Items).CollectionChanged += svnthSem_CollectionChanged;
            ((INotifyCollectionChanged)lbEgthSem.Items).CollectionChanged += egthSem_CollectionChanged;


            alltiles.Add(tilesBank);
            alltiles.Add(tilesFrstSem);
            alltiles.Add(tilesScndSem);
            alltiles.Add(tilesThrdSem);
            alltiles.Add(tilesFrthSem);
            alltiles.Add(tilesFfthSem);
            alltiles.Add(tilesSxthSem);
            alltiles.Add(tilesSvnthSem);
            alltiles.Add(tilesEgthSem);

        }

        #region итоговые значения intupdown
        #region первый семестр
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


        #region второй семестр
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
        #endregion второй семестр


        #region третий семестр
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


        #region четвертый семестр
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
        #endregion четвертый семестр


        #region пятый семестр
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


        #region шестой семестр
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


        #region седьмой семестр
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


        #region восьмой семестр
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
        #endregion intupdown

        #region кнопки закрыть
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

        #region операции изменения коллекций семестров и банка
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

                for (int i = 0; i < tiles.Count; i++)
                    tilesBank.Add(new TileSer(
                        Convert.ToInt32(tiles[i].TheoryRab.Value),
                        Convert.ToInt32(tiles[i].PromAttest.Value),
                        Convert.ToInt32(tiles[i].Kurs.Value),
                        tiles[i].Total.Text,
                        tiles[i].SokrNameD.Text,
                        tiles[i].SokrNameD.ToolTip.ToString(),
                        flds[i].Background.ToString()));


                alltiles[0] = tilesBank;


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


                var old_itms = lbBank.Items;

                List<ListBoxItem> old_flds = new List<ListBoxItem>();
                old_flds.AddRange(old_itms.OfType<ListBoxItem>());

                List<Tile> old_tiles = new List<Tile>();

                for (int i = 0; i < old_flds.Count; i++)
                    old_tiles.Add((Tile)old_flds[i].Content);

                tilesBank.Clear();

                for (int i = 0; i < old_tiles.Count; i++)
                    tilesBank.Add(new TileSer(
                        Convert.ToInt32(old_tiles[i].TheoryRab.Value),
                        Convert.ToInt32(old_tiles[i].PromAttest.Value),
                        Convert.ToInt32(old_tiles[i].Kurs.Value),
                        old_tiles[i].Total.Text,
                        old_tiles[i].SokrNameD.Text,
                        old_tiles[i].SokrNameD.ToolTip.ToString(),
                        old_flds[i].Background.ToString()));

                alltiles[0] = tilesBank;
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

                for (int i = 0; i < tiles.Count; i++)
                    tilesFrstSem.Add(new TileSer(
                        Convert.ToInt32(tiles[i].TheoryRab.Value),
                        Convert.ToInt32(tiles[i].PromAttest.Value),
                        Convert.ToInt32(tiles[i].Kurs.Value),
                        tiles[i].Total.Text,
                        tiles[i].SokrNameD.Text,
                        tiles[i].SokrNameD.ToolTip.ToString(),
                        flds[i].Background.ToString()));


                alltiles[1] = tilesFrstSem;

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

                var old_itms = lbFrstSem.Items;

                List<ListBoxItem> old_flds = new List<ListBoxItem>();
                old_flds.AddRange(old_itms.OfType<ListBoxItem>());

                List<Tile> old_tiles = new List<Tile>();

                for (int i = 0; i < old_flds.Count; i++)
                    old_tiles.Add((Tile)old_flds[i].Content);

                tilesFrstSem.Clear();

                for (int i = 0; i < old_tiles.Count; i++)
                    tilesFrstSem.Add(new TileSer(
                        Convert.ToInt32(old_tiles[i].TheoryRab.Value),
                        Convert.ToInt32(old_tiles[i].PromAttest.Value),
                        Convert.ToInt32(old_tiles[i].Kurs.Value),
                        old_tiles[i].Total.Text,
                        old_tiles[i].SokrNameD.Text,
                        old_tiles[i].SokrNameD.ToolTip.ToString(),
                        old_flds[i].Background.ToString()));

                alltiles[1] = tilesFrstSem;


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

                for (int i = 0; i < tiles.Count; i++)
                    tilesScndSem.Add(new TileSer(
                        Convert.ToInt32(tiles[i].TheoryRab.Value),
                        Convert.ToInt32(tiles[i].PromAttest.Value),
                        Convert.ToInt32(tiles[i].Kurs.Value),
                        tiles[i].Total.Text,
                        tiles[i].SokrNameD.Text,
                        tiles[i].SokrNameD.ToolTip.ToString(),
                        flds[i].Background.ToString()));

                alltiles[2] = tilesScndSem;

                labelscndSem.Content = $"2  :  {sumScndSem} ({sumScndSemTheoryRab} + " +
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

                var old_itms = lbScndSem.Items;

                List<ListBoxItem> old_flds = new List<ListBoxItem>();
                old_flds.AddRange(old_itms.OfType<ListBoxItem>());

                List<Tile> old_tiles = new List<Tile>();

                for (int i = 0; i < old_flds.Count; i++)
                    old_tiles.Add((Tile)old_flds[i].Content);

                tilesScndSem.Clear();

                for (int i = 0; i < old_tiles.Count; i++)
                    tilesScndSem.Add(new TileSer(
                        Convert.ToInt32(old_tiles[i].TheoryRab.Value),
                        Convert.ToInt32(old_tiles[i].PromAttest.Value),
                        Convert.ToInt32(old_tiles[i].Kurs.Value),
                        old_tiles[i].Total.Text,
                        old_tiles[i].SokrNameD.Text,
                        old_tiles[i].SokrNameD.ToolTip.ToString(),
                        old_flds[i].Background.ToString()));

                alltiles[2] = tilesScndSem;

                labelscndSem.Content = $"2  :  {sumScndSem} ({sumScndSemTheoryRab} + " +
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

                for (int i = 0; i < tiles.Count; i++)
                    tilesThrdSem.Add(new TileSer(
                        Convert.ToInt32(tiles[i].TheoryRab.Value),
                        Convert.ToInt32(tiles[i].PromAttest.Value),
                        Convert.ToInt32(tiles[i].Kurs.Value),
                        tiles[i].Total.Text,
                        tiles[i].SokrNameD.Text,
                        tiles[i].SokrNameD.ToolTip.ToString(),
                        flds[i].Background.ToString()));

                alltiles[3] = tilesThrdSem;

                labelthrdSem.Content = $"3  :  {sumThrdSem} ({sumThrdSemTheoryRab} + " +
                    $"{sumThrdSemPromAttest} + {sumThrdSemKurs})";

                labelScndKurs.Content = $"2  :  {sumThrdSem + sumFrthSem}";

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

                var old_itms = lbThrdSem.Items;

                List<ListBoxItem> old_flds = new List<ListBoxItem>();
                old_flds.AddRange(old_itms.OfType<ListBoxItem>());

                List<Tile> old_tiles = new List<Tile>();

                for (int i = 0; i < old_flds.Count; i++)
                    old_tiles.Add((Tile)old_flds[i].Content);

                tilesThrdSem.Clear();

                for (int i = 0; i < old_tiles.Count; i++)
                    tilesThrdSem.Add(new TileSer(
                        Convert.ToInt32(old_tiles[i].TheoryRab.Value),
                        Convert.ToInt32(old_tiles[i].PromAttest.Value),
                        Convert.ToInt32(old_tiles[i].Kurs.Value),
                        old_tiles[i].Total.Text,
                        old_tiles[i].SokrNameD.Text,
                        old_tiles[i].SokrNameD.ToolTip.ToString(),
                        old_flds[i].Background.ToString()));

                alltiles[3] = tilesThrdSem;

                labelthrdSem.Content = $"3  :  {sumThrdSem} ({sumThrdSemTheoryRab} + " +
                    $"{sumThrdSemPromAttest} + {sumThrdSemKurs})";

                labelScndKurs.Content = $"2  :  {sumThrdSem + sumFrthSem}";

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

                for (int i = 0; i < tiles.Count; i++)
                    tilesFrthSem.Add(new TileSer(
                        Convert.ToInt32(tiles[i].TheoryRab.Value),
                        Convert.ToInt32(tiles[i].PromAttest.Value),
                        Convert.ToInt32(tiles[i].Kurs.Value),
                        tiles[i].Total.Text,
                        tiles[i].SokrNameD.Text,
                        tiles[i].SokrNameD.ToolTip.ToString(),
                        flds[i].Background.ToString()));

                alltiles[4] = tilesFrthSem;

                labelfrthSem.Content = $"4  :  {sumFrthSem} ({sumFrthSemTheoryRab} + " +
                    $"{sumFrthSemPromAttest} + {sumFrthSemKurs})";

                labelScndKurs.Content = $"2  :  {sumThrdSem + sumFrthSem}";

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

                var old_itms = lbFrthSem.Items;

                List<ListBoxItem> old_flds = new List<ListBoxItem>();
                old_flds.AddRange(old_itms.OfType<ListBoxItem>());

                List<Tile> old_tiles = new List<Tile>();

                for (int i = 0; i < old_flds.Count; i++)
                    old_tiles.Add((Tile)old_flds[i].Content);

                tilesFrthSem.Clear();

                for (int i = 0; i < old_tiles.Count; i++)
                    tilesFrthSem.Add(new TileSer(
                        Convert.ToInt32(old_tiles[i].TheoryRab.Value),
                        Convert.ToInt32(old_tiles[i].PromAttest.Value),
                        Convert.ToInt32(old_tiles[i].Kurs.Value),
                        old_tiles[i].Total.Text,
                        old_tiles[i].SokrNameD.Text,
                        old_tiles[i].SokrNameD.ToolTip.ToString(),
                        old_flds[i].Background.ToString()));

                alltiles[4] = tilesFrthSem;

                labelfrthSem.Content = $"4  :  {sumFrthSem} ({sumFrthSemTheoryRab} + " +
                    $"{sumFrthSemPromAttest} + {sumFrthSemKurs})";

                labelScndKurs.Content = $"2  :  {sumThrdSem + sumFrthSem}";

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

                for (int i = 0; i < tiles.Count; i++)
                    tilesFfthSem.Add(new TileSer(
                        Convert.ToInt32(tiles[i].TheoryRab.Value),
                        Convert.ToInt32(tiles[i].PromAttest.Value),
                        Convert.ToInt32(tiles[i].Kurs.Value),
                        tiles[i].Total.Text,
                        tiles[i].SokrNameD.Text,
                        tiles[i].SokrNameD.ToolTip.ToString(),
                        flds[i].Background.ToString()));

                alltiles[5] = tilesFfthSem;

                labelffthSem.Content = $"5  :  {sumFfthSem} ({sumFfthSemTheoryRab} + " +
                    $"{sumFfthSemPromAttest} + {sumFfthSemKurs})";

                labelThrdKurs.Content = $"3  :  {sumFfthSem + sumSxthSem}";

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

                var old_itms = lbFfthSem.Items;

                List<ListBoxItem> old_flds = new List<ListBoxItem>();
                old_flds.AddRange(old_itms.OfType<ListBoxItem>());

                List<Tile> old_tiles = new List<Tile>();

                for (int i = 0; i < old_flds.Count; i++)
                    old_tiles.Add((Tile)old_flds[i].Content);

                tilesFfthSem.Clear();

                for (int i = 0; i < old_tiles.Count; i++)
                    tilesFfthSem.Add(new TileSer(
                        Convert.ToInt32(old_tiles[i].TheoryRab.Value),
                        Convert.ToInt32(old_tiles[i].PromAttest.Value),
                        Convert.ToInt32(old_tiles[i].Kurs.Value),
                        old_tiles[i].Total.Text,
                        old_tiles[i].SokrNameD.Text,
                        old_tiles[i].SokrNameD.ToolTip.ToString(),
                        old_flds[i].Background.ToString()));

                alltiles[5] = tilesFfthSem;

                labelffthSem.Content = $"5  :  {sumFfthSem} ({sumFfthSemTheoryRab} + " +
                    $"{sumFfthSemPromAttest} + {sumFfthSemKurs})";

                labelThrdKurs.Content = $"3  :  {sumFfthSem + sumSxthSem}";

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

                for (int i = 0; i < tiles.Count; i++)
                    tilesSxthSem.Add(new TileSer(
                        Convert.ToInt32(tiles[i].TheoryRab.Value),
                        Convert.ToInt32(tiles[i].PromAttest.Value),
                        Convert.ToInt32(tiles[i].Kurs.Value),
                        tiles[i].Total.Text,
                        tiles[i].SokrNameD.Text,
                        tiles[i].SokrNameD.ToolTip.ToString(),
                        flds[i].Background.ToString()));

                alltiles[6] = tilesSxthSem;

                labelsxthSem.Content = $"6  :  {sumSxthSem} ({sumSxthSemTheoryRab} + " +
                    $"{sumSxthSemPromAttest} + {sumSxthSemKurs})";

                labelThrdKurs.Content = $"3  :  {sumFfthSem + sumSxthSem}";

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

                var old_itms = lbSxthSem.Items;

                List<ListBoxItem> old_flds = new List<ListBoxItem>();
                old_flds.AddRange(old_itms.OfType<ListBoxItem>());

                List<Tile> old_tiles = new List<Tile>();

                for (int i = 0; i < old_flds.Count; i++)
                    old_tiles.Add((Tile)old_flds[i].Content);

                tilesSxthSem.Clear();

                for (int i = 0; i < old_tiles.Count; i++)
                    tilesSxthSem.Add(new TileSer(
                        Convert.ToInt32(old_tiles[i].TheoryRab.Value),
                        Convert.ToInt32(old_tiles[i].PromAttest.Value),
                        Convert.ToInt32(old_tiles[i].Kurs.Value),
                        old_tiles[i].Total.Text,
                        old_tiles[i].SokrNameD.Text,
                        old_tiles[i].SokrNameD.ToolTip.ToString(),
                        old_flds[i].Background.ToString()));

                alltiles[6] = tilesSxthSem;

                labelsxthSem.Content = $"6  :  {sumSxthSem} ({sumSxthSemTheoryRab} + " +
                    $"{sumSxthSemPromAttest} + {sumSxthSemKurs})";

                labelThrdKurs.Content = $"3  :  {sumFfthSem + sumSxthSem}";

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

                for (int i = 0; i < tiles.Count; i++)
                    tilesSvnthSem.Add(new TileSer(
                        Convert.ToInt32(tiles[i].TheoryRab.Value),
                        Convert.ToInt32(tiles[i].PromAttest.Value),
                        Convert.ToInt32(tiles[i].Kurs.Value),
                        tiles[i].Total.Text,
                        tiles[i].SokrNameD.Text,
                        tiles[i].SokrNameD.ToolTip.ToString(),
                        flds[i].Background.ToString()));

                alltiles[7] = tilesSvnthSem;

                labelsvnthSem.Content = $"7  :  {sumSvnthSem} ({sumSvnthSemTheoryRab} + " +
                    $"{sumSvnthSemPromAttest} + {sumSvnthSemKurs})";

                labelFrthKurs.Content = $"4  :  {sumSvnthSem + sumEgthSem}";

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

                var old_itms = lbSvnthSem.Items;

                List<ListBoxItem> old_flds = new List<ListBoxItem>();
                old_flds.AddRange(old_itms.OfType<ListBoxItem>());

                List<Tile> old_tiles = new List<Tile>();

                for (int i = 0; i < old_flds.Count; i++)
                    old_tiles.Add((Tile)old_flds[i].Content);

                tilesSvnthSem.Clear();

                for (int i = 0; i < old_tiles.Count; i++)
                    tilesSvnthSem.Add(new TileSer(
                        Convert.ToInt32(old_tiles[i].TheoryRab.Value),
                        Convert.ToInt32(old_tiles[i].PromAttest.Value),
                        Convert.ToInt32(old_tiles[i].Kurs.Value),
                        old_tiles[i].Total.Text,
                        old_tiles[i].SokrNameD.Text,
                        old_tiles[i].SokrNameD.ToolTip.ToString(),
                        old_flds[i].Background.ToString()));

                alltiles[7] = tilesSvnthSem;

                labelsvnthSem.Content = $"7  :  {sumSvnthSem} ({sumSvnthSemTheoryRab} + " +
                    $"{sumSvnthSemPromAttest} + {sumSvnthSemKurs})";

                labelFrthKurs.Content = $"4  :  {sumSvnthSem + sumEgthSem}";

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

                for (int i = 0; i < tiles.Count; i++)
                    tilesEgthSem.Add(new TileSer(
                        Convert.ToInt32(tiles[i].TheoryRab.Value),
                        Convert.ToInt32(tiles[i].PromAttest.Value),
                        Convert.ToInt32(tiles[i].Kurs.Value),
                        tiles[i].Total.Text,
                        tiles[i].SokrNameD.Text,
                        tiles[i].SokrNameD.ToolTip.ToString(),
                        flds[i].Background.ToString()));

                alltiles[8] = tilesEgthSem;

                labelegthSem.Content = $"8  :  {sumEgthSem} ({sumEgthSemTheoryRab} + " +
                    $"{sumEgthSemPromAttest} + {sumEgthSemKurs})";

                labelFrthKurs.Content = $"4  :  {sumSvnthSem + sumEgthSem}";

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

                var old_itms = lbEgthSem.Items;

                List<ListBoxItem> old_flds = new List<ListBoxItem>();
                old_flds.AddRange(old_itms.OfType<ListBoxItem>());

                List<Tile> old_tiles = new List<Tile>();

                for (int i = 0; i < old_flds.Count; i++)
                    old_tiles.Add((Tile)old_flds[i].Content);

                tilesEgthSem.Clear();

                for (int i = 0; i < old_tiles.Count; i++)
                    tilesEgthSem.Add(new TileSer(
                        Convert.ToInt32(old_tiles[i].TheoryRab.Value),
                        Convert.ToInt32(old_tiles[i].PromAttest.Value),
                        Convert.ToInt32(old_tiles[i].Kurs.Value),
                        old_tiles[i].Total.Text,
                        old_tiles[i].SokrNameD.Text,
                        old_tiles[i].SokrNameD.ToolTip.ToString(),
                        old_flds[i].Background.ToString()));

                alltiles[8] = tilesEgthSem;

                labelegthSem.Content = $"8  :  {sumEgthSem} ({sumEgthSemTheoryRab} + " +
                    $"{sumEgthSemPromAttest} + {sumEgthSemKurs})";

                labelFrthKurs.Content = $"4  :  {sumSvnthSem + sumEgthSem}";

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

        void SaveToFile(string fname) {

            BinaryFormatter bf = new BinaryFormatter();

            FileStream f = File.OpenWrite(fname);

            bf.Serialize(f,alltiles);
            f.Close();
        }

        void LoadFromFile(string fname) {

            BinaryFormatter bf = new BinaryFormatter();

            FileStream f = File.OpenRead(fname);

            alltiles_deser = (List<List<TileSer>>)bf.Deserialize(f);

            f.Close();

            lbBank.Items.Clear();
            lbFrstSem.Items.Clear();
            lbScndSem.Items.Clear();
            lbThrdSem.Items.Clear();
            lbFrthSem.Items.Clear();
            lbFfthSem.Items.Clear();
            lbSxthSem.Items.Clear();
            lbSvnthSem.Items.Clear();
            lbEgthSem.Items.Clear();

            ListBoxItem lbi;
            Tile elem;

            for (int i = 0; i < alltiles_deser.Count; i++) {

                for (int j = 0; j < alltiles_deser[i].Count; j++) {

                    lbi = new ListBoxItem();
                    elem = new Tile();

                    elem.TheoryRab.Value = alltiles_deser[i][j].TheoryRab;
                    elem.PromAttest.Value = alltiles_deser[i][j].PromAttest;
                    elem.Kurs.Value = alltiles_deser[i][j].Kurs;
                    elem.Total.Text = (alltiles_deser[i][j].TheoryRab + alltiles_deser[i][j].PromAttest
                        + alltiles_deser[i][j].Kurs).ToString();
                    elem.SokrNameD.Text = alltiles_deser[i][j].SokrNameD;
                    elem.SokrNameD.ToolTip = alltiles_deser[i][j].NameD;

                    lbi.Content = elem;
                    lbi.BorderBrush = Brushes.Black;
                    lbi.BorderThickness = new Thickness(1,1,1,1);
                    lbi.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(alltiles_deser[i][j].CvetK);
                    lbi.HorizontalContentAlignment = HorizontalAlignment.Stretch;


                    switch (i) {
                        case 0:
                            lbBank.Items.Add(lbi);
                            break;
                        case 1:
                            lbFrstSem.Items.Add(lbi);
                            break;
                        case 2:
                            lbScndSem.Items.Add(lbi);
                            break;
                        case 3:
                            lbThrdSem.Items.Add(lbi);
                            break;
                        case 4:
                            lbFrthSem.Items.Add(lbi);
                            break;
                        case 5:
                            lbFfthSem.Items.Add(lbi);
                            break;
                        case 6:
                            lbSxthSem.Items.Add(lbi);
                            break;
                        case 7:
                            lbSvnthSem.Items.Add(lbi);
                            break;
                        case 8:
                            lbEgthSem.Items.Add(lbi);
                            break;
                    }

                }
            }
        }

        private void btnSaveProject_Click(object sender,RoutedEventArgs e) {

            SaveFileDialog fl = new SaveFileDialog();

            bool? result = fl.ShowDialog();

            if (result == true)
                SaveToFile(fl.FileName);

        }

        private void btnOpenProject_Click(object sender,RoutedEventArgs e) {

            OpenFileDialog fl = new OpenFileDialog();

            bool? result = fl.ShowDialog();

            if (result == true)
                LoadFromFile(fl.FileName);

        }

        private void Window_Closing(object sender,System.ComponentModel.CancelEventArgs e) {

        }

        //public class FileAssociation {
        //    private const string FILE_EXTENSION = ".pkt";
        //    private const long SHCNE_ASSOCCHANGED = 0x8000000L;
        //    private const uint SHCNF_IDLIST = 0x0U;

        //    public static void Associate(string description,string icon) {
        //        Registry.ClassesRoot.CreateSubKey(FILE_EXTENSION).SetValue("",Application.ProductName);

        //        if (Application.ProductName != null && Application.ProductName.Length > 0) {
        //            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(Application.ProductName)) {
        //                if (description != null)
        //                    key.SetValue("",description);

        //                if (icon != null)
        //                    key.CreateSubKey("DefaultIcon").SetValue("",ToShortPathName(icon));

        //                key.CreateSubKey(@"Shell\Open\Command").SetValue("",ToShortPathName(Application.ExecutablePath) + " \"%1\"");
        //            }
        //        }

        //        SHChangeNotify(SHCNE_ASSOCCHANGED,SHCNF_IDLIST,IntPtr.Zero,IntPtr.Zero);
        //    }

        //    public static bool IsAssociated {
        //        get { return (Registry.ClassesRoot.OpenSubKey(FILE_EXTENSION,false) != null); }
        //    }

        //    public static void Remove() {
        //        Registry.ClassesRoot.DeleteSubKeyTree(FILE_EXTENSION);
        //        Registry.ClassesRoot.DeleteSubKeyTree(Application.ProductName);
        //    }

        //    [DllImport("shell32.dll",SetLastError = true)]
        //    private static extern void SHChangeNotify(long wEventId,uint uFlags,IntPtr dwItem1,IntPtr dwItem2);

        //    [DllImport("Kernel32.dll")]
        //    private static extern uint GetShortPathName(string lpszLongPath,[Out] StringBuilder lpszShortPath,uint cchBuffer);

        //    private static string ToShortPathName(string longName) {
        //        StringBuilder s = new StringBuilder(1000);
        //        uint iSize = (uint)s.Capacity;
        //        uint iRet = GetShortPathName(longName,s,iSize);
        //        return s.ToString();
        //    }
        //}


        public static void AssociateExtension() {

            //string appName = "Kurnel of curriculum";
            //string exePath = $"\"{System.Reflection.Assembly.GetExecutingAssembly().Location}\"";
            //string exeName = System.AppDomain.CurrentDomain.FriendlyName;

            //Registry.ClassesRoot.CreateSubKey(".koc").SetValue("",appName);
            //Registry.ClassesRoot.CreateSubKey(appName + @"DefaultIcon").SetValue("",exePath);
            //Registry.ClassesRoot.CreateSubKey(appName + @"\shell\open\command").SetValue("",exePath + "\"%1\"");
            //Registry.ClassesRoot.CreateSubKey(appName + @"\shell\edit\command").SetValue("",exePath + "\"%1\"");
            //Registry.ClassesRoot.CreateSubKey(string.Format(@"Applications\{0}\shell\open\command", exeName)).SetValue("",exePath + "\"%1\"");
            //Registry.ClassesRoot.CreateSubKey(string.Format(@"Applications\{0}\shell\edit\command",exeName)).SetValue("",exePath + "\"%1\"");



            //RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Classes",true);
            //key.CreateSubKey("." + "koc").SetValue(string.Empty,"koc" + "_auto_file");
            //key = key.CreateSubKey("koc" + "_auto_file");
            //key = key.CreateSubKey("Shell");
            //key = key.CreateSubKey("Open");

            //key.CreateSubKey("Command").SetValue(string.Empty,"\"" + "Kurnel of curriculum" + "\" \"%1\"");

        }

        private void Window_Loaded(object sender,RoutedEventArgs e) {
            string[] arg = Environment.GetCommandLineArgs();

            if (arg.Length > 0)
                try {
                    LoadFromFile(arg[1]);
                }
                catch { }
        }

        private void btnExit_Click(object sender,RoutedEventArgs e) {
            Close();
        }
    }
}
