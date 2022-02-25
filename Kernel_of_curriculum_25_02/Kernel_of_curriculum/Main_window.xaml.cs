﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GongSolutions.Wpf.DragDrop;
using System.Linq;
using System.Diagnostics;
using System.ComponentModel;

namespace Kernel_of_curriculum
{
    /// <summary>
    /// Логика взаимодействия для Main_window.xaml
    /// </summary>
    public partial class Main_window : Window
    {

        public int sumFrstSem { get; set; }
        public int sumScndSem { get; set; }
        public int sumThrdSem { get; set; }
        public int sumFrthSem { get; set; }
        public int sumFfthSem { get; set; }
        public int sumSxthSem { get; set; }
        public int sumSvnthSem { get; set; }
        public int sumEgthSem { get; set; }

        public Main_window()
        {
            InitializeComponent();

            
            // второй семестр
            var itemsScndSem = lbScndSem.Items;
            List<ListBoxItem> listBoxItemsScndSem = new List<ListBoxItem>();
            listBoxItemsScndSem.AddRange(itemsScndSem.OfType<ListBoxItem>());

            List<Tile> tilesScndSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsScndSem.Count; i++)
                tilesScndSem.Add((Tile)listBoxItemsScndSem[i].Content);


            for (int i = 0; i < tilesScndSem.Count; i++) {
                sumScndSem += (int)tilesScndSem[i].Total.Value;
                tilesScndSem[i].Total.ValueChanged += Total_ValueChanged_Scnd_Sem;
                tilesScndSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_ScndSem;
            }

            labelscndSem.Content = sumScndSem;

            // третий семестр
            var itemsThrdSem = lbThrdSem.Items;
            List<ListBoxItem> listBoxItemsThrdSem = new List<ListBoxItem>();
            listBoxItemsThrdSem.AddRange(itemsThrdSem.OfType<ListBoxItem>());

            List<Tile> tilesThrdSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsThrdSem.Count; i++)
                tilesThrdSem.Add((Tile)listBoxItemsThrdSem[i].Content);


            for (int i = 0; i < tilesThrdSem.Count; i++) {
                sumThrdSem += (int)tilesThrdSem[i].Total.Value;
                tilesThrdSem[i].Total.ValueChanged += Total_ValueChanged_Thrd_Sem;
                tilesThrdSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_ThrdSem;
            }

            labelthrdSem.Content = sumThrdSem;

            // четвертый семестр
            var itemsFrthSem = lbFrthSem.Items;
            List<ListBoxItem> listBoxItemsFrthSem = new List<ListBoxItem>();
            listBoxItemsFrthSem.AddRange(itemsFrthSem.OfType<ListBoxItem>());

            List<Tile> tilesFrthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsFrthSem.Count; i++)
                tilesFrthSem.Add((Tile)listBoxItemsFrthSem[i].Content);


            for (int i = 0; i < tilesFrthSem.Count; i++) {
                sumFrthSem += (int)tilesFrthSem[i].Total.Value;
                tilesFrthSem[i].Total.ValueChanged += Total_ValueChanged_Frth_Sem;
                tilesFrthSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FrthSem;
            }

            labelfrthSem.Content = sumFrthSem;

            // пятый семестр
            var itemsFfthSem = lbFrthSem.Items;
            List<ListBoxItem> listBoxItemsFfthSem = new List<ListBoxItem>();
            listBoxItemsFfthSem.AddRange(itemsFfthSem.OfType<ListBoxItem>());

            List<Tile> tilesFfthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsFfthSem.Count; i++)
                tilesFfthSem.Add((Tile)listBoxItemsFfthSem[i].Content);


            for (int i = 0; i < tilesFfthSem.Count; i++) {
                sumFfthSem += (int)tilesFfthSem[i].Total.Value;
                tilesFfthSem[i].Total.ValueChanged += Total_ValueChanged_Ffth_Sem;
                tilesFfthSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FfthSem;
            }

            labelffthSem.Content = sumFfthSem;

            // шестой семестр
            var itemsSxthSem = lbSxthSem.Items;
            List<ListBoxItem> listBoxItemsSxthSem = new List<ListBoxItem>();
            listBoxItemsSxthSem.AddRange(itemsSxthSem.OfType<ListBoxItem>());

            List<Tile> tilesSxthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsSxthSem.Count; i++)
                tilesSxthSem.Add((Tile)listBoxItemsSxthSem[i].Content);


            for (int i = 0; i < tilesSxthSem.Count; i++) {
                sumSxthSem += (int)tilesSxthSem[i].Total.Value;
                tilesSxthSem[i].Total.ValueChanged += Total_ValueChanged_Sxth_Sem;
                tilesSxthSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_SxthSem;
            }

            labelsxthSem.Content = sumSxthSem;

            // седьмой семестр
            var itemsSvnthSem = lbSvnthSem.Items;
            List<ListBoxItem> listBoxItemsSvnthSem = new List<ListBoxItem>();
            listBoxItemsSvnthSem.AddRange(itemsSvnthSem.OfType<ListBoxItem>());

            List<Tile> tilesSvnthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsSvnthSem.Count; i++)
                tilesSvnthSem.Add((Tile)listBoxItemsSvnthSem[i].Content);


            for (int i = 0; i < tilesSvnthSem.Count; i++) {
                sumSvnthSem += (int)tilesSvnthSem[i].Total.Value;
                tilesSvnthSem[i].Total.ValueChanged += Total_ValueChanged_Svnth_Sem;
                tilesSvnthSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_SvnthSem;
            }

            labelsvnthSem.Content = sumSvnthSem;

            // восьмой семестр
            var itemsEgthSem = lbEgthSem.Items;
            List<ListBoxItem> listBoxItemsEgthSem = new List<ListBoxItem>();
            listBoxItemsEgthSem.AddRange(itemsEgthSem.OfType<ListBoxItem>());

            List<Tile> tilesEgthSem = new List<Tile>();

            for (int i = 0; i < listBoxItemsEgthSem.Count; i++)
                tilesEgthSem.Add((Tile)listBoxItemsEgthSem[i].Content);


            for (int i = 0; i < tilesEgthSem.Count; i++) {
                sumEgthSem += (int)tilesEgthSem[i].Total.Value;
                tilesEgthSem[i].Total.ValueChanged += Total_ValueChanged_Egth_Sem;
                tilesEgthSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_EgthSem;
            }

            labelegthSem.Content = sumEgthSem;


            CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;


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
        private void Total_ValueChanged_First_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                              
                sumFrstSem++;
                labelfrstSem.Content = sumFrstSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
            else {
                sumFrstSem--;
                labelfrstSem.Content = sumFrstSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;
            }              
        }

        private void Total_ValueChanged_Scnd_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumScndSem++;
                labelscndSem.Content = sumScndSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;
            }
            else {
                sumScndSem--;
                labelscndSem.Content = sumScndSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
        }

        private void Total_ValueChanged_Thrd_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumThrdSem++;
                labelthrdSem.Content = sumThrdSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;
            }
            else {
                sumThrdSem--;
                labelthrdSem.Content = sumThrdSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
        }

        private void Total_ValueChanged_Frth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumFrthSem++;
                labelfrthSem.Content = sumFrthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;
            }
            else {
                sumFrthSem--;
                labelfrthSem.Content = sumFrthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
        }

        private void Total_ValueChanged_Ffth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumFfthSem++;
                labelffthSem.Content = sumFfthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;
            }
            else {
                sumFfthSem--;
                labelffthSem.Content = sumFfthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
        }

        private void Total_ValueChanged_Sxth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumSxthSem++;
                labelsxthSem.Content = sumSxthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;
            }
            else {
                sumSxthSem--;
                labelsxthSem.Content = sumSxthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
        }

        private void Total_ValueChanged_Svnth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumSvnthSem++;
                labelsvnthSem.Content = sumSvnthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;
            }
            else {
                sumSvnthSem--;
                labelsvnthSem.Content = sumSvnthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
        }

        private void Total_ValueChanged_Egth_Sem(object sender,RoutedPropertyChangedEventArgs<object> e) {
            if ((int)e.NewValue > (int)e.OldValue) {
                sumEgthSem++;
                labelegthSem.Content = sumEgthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;
            }
            else {
                sumEgthSem--;
                labelegthSem.Content = sumEgthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
        }

        // кнопки закрыть
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

        // операции изменения коллекций семестров
        private void frstSem_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {

           
            if (e.Action == NotifyCollectionChangedAction.Add) {

                var itms = e.NewItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].Total.ValueChanged += Total_ValueChanged_First_Sem;
                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FrstSem;
                    sumFrstSem += (int)tiles[i].Total.Value;                  
                }

                labelfrstSem.Content = sumFrstSem;

                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {
                
                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].Total.ValueChanged -= Total_ValueChanged_First_Sem;
                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_FrstSem;
                    sumFrstSem -= (int)tiles[i].Total.Value;                                
                }

                labelfrstSem.Content = sumFrstSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

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
                    tiles[i].Total.ValueChanged += Total_ValueChanged_Scnd_Sem;
                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_ScndSem;
                    sumScndSem += (int)tiles[i].Total.Value;
                                  
                }

                labelscndSem.Content = sumScndSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].Total.ValueChanged -= Total_ValueChanged_Scnd_Sem;
                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_ScndSem;
                    sumScndSem -= (int)tiles[i].Total.Value;                  
                }

                labelscndSem.Content = sumScndSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

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
                    tiles[i].Total.ValueChanged += Total_ValueChanged_Thrd_Sem;
                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_ThrdSem;
                    sumThrdSem += (int)tiles[i].Total.Value;

                }

                labelthrdSem.Content = sumThrdSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].Total.ValueChanged -= Total_ValueChanged_Thrd_Sem;
                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_ThrdSem;
                    sumThrdSem -= (int)tiles[i].Total.Value;
                }

                labelthrdSem.Content = sumThrdSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

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
                    tiles[i].Total.ValueChanged += Total_ValueChanged_Frth_Sem;
                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FrthSem;
                    sumFrthSem += (int)tiles[i].Total.Value;

                }

                labelfrthSem.Content = sumFrthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].Total.ValueChanged -= Total_ValueChanged_Frth_Sem;
                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_FrthSem;
                    sumFrthSem -= (int)tiles[i].Total.Value;
                }

                labelfrthSem.Content = sumFrthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

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
                    tiles[i].Total.ValueChanged += Total_ValueChanged_Ffth_Sem;
                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FfthSem;
                    sumFfthSem += (int)tiles[i].Total.Value;

                }

                labelffthSem.Content = sumFfthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].Total.ValueChanged -= Total_ValueChanged_Ffth_Sem;
                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_FfthSem;
                    sumFfthSem -= (int)tiles[i].Total.Value;
                }

                labelffthSem.Content = sumFfthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

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
                    tiles[i].Total.ValueChanged += Total_ValueChanged_Sxth_Sem;
                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_SxthSem;
                    sumSxthSem += (int)tiles[i].Total.Value;

                }

                labelsxthSem.Content = sumSxthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].Total.ValueChanged -= Total_ValueChanged_Sxth_Sem;
                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_SxthSem;
                    sumSxthSem -= (int)tiles[i].Total.Value;
                }

                labelsxthSem.Content = sumSxthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

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
                    tiles[i].Total.ValueChanged += Total_ValueChanged_Svnth_Sem;
                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_SvnthSem;
                    sumSvnthSem += (int)tiles[i].Total.Value;

                }

                labelsvnthSem.Content = sumSvnthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].Total.ValueChanged -= Total_ValueChanged_Svnth_Sem;
                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_SvnthSem;
                    sumSvnthSem -= (int)tiles[i].Total.Value;
                }

                labelsvnthSem.Content = sumSvnthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

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
                    tiles[i].Total.ValueChanged += Total_ValueChanged_Egth_Sem;
                    tiles[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_EgthSem;
                    sumEgthSem += (int)tiles[i].Total.Value;

                }

                labelegthSem.Content = sumEgthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {

                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++) {
                    tiles[i].Total.ValueChanged -= Total_ValueChanged_Egth_Sem;
                    tiles[i].btnThrowOfTile.Click -= BtnThrowOfTile_Click_EgthSem;
                    sumEgthSem -= (int)tiles[i].Total.Value;
                }

                labelegthSem.Content = sumEgthSem;
                CountAllSem.Content = (int)labelfrstSem.Content + (int)labelscndSem.Content +
                (int)labelthrdSem.Content + (int)labelfrthSem.Content +
                (int)labelffthSem.Content + (int)labelsxthSem.Content +
                (int)labelsvnthSem.Content + (int)labelegthSem.Content;

            }
        }

        private void btnAddElem_Click(object sender,RoutedEventArgs e) {

            var lbi = new ListBoxItem();

            var elem = new Tile();

            elem.TheoryRab.Value = 3;
            elem.PromAttest.Value = 1;
            elem.Kurs.Value = 1;
            elem.Total.Value = elem.TheoryRab.Value + elem.PromAttest.Value + elem.Kurs.Value;
            elem.SokrNameD.Content = "ПИС";
            elem.SokrNameD.ToolTip = "Проектирование информационных систем";

            lbi.Content = elem;
            lbi.BorderBrush = Brushes.Black;
            lbi.BorderThickness = new Thickness(1,1,1,1);
            lbi.Background = Brushes.YellowGreen;
            lbi.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            lbBank.Items.Add(lbi);
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
                sumFrstSem += (int)tilesFrstSem[i].Total.Value;
                tilesFrstSem[i].Total.ValueChanged += Total_ValueChanged_First_Sem;
                tilesFrstSem[i].btnThrowOfTile.Click += BtnThrowOfTile_Click_FrstSem;
            }

            labelfrstSem.Content = sumFrstSem;
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
    }
}