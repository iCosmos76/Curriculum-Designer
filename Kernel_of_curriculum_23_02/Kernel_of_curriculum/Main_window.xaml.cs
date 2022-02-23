using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public int sumEghthSem { get; set; }

        public Main_window()
        {
            InitializeComponent();

            var itms = lbFrstSem.Items;
            List<ListBoxItem> flds = new List<ListBoxItem>();         
            flds.AddRange(itms.OfType<ListBoxItem>());

            List<Tile> tiles = new List<Tile>();
       
            for (int i = 0; i < flds.Count; i++) 
                tiles.Add((Tile)flds[i].Content);

         
            for (int i = 0; i < tiles.Count; i++) 
                sumFrstSem += (int)tiles[i].Total.Value;

            lablefrstSem.Content = sumFrstSem;
            ((INotifyCollectionChanged)lbFrstSem.Items).CollectionChanged += frstSem_CollectionChanged;
         
        }

        private void frstSem_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {

           
            if (e.Action == NotifyCollectionChangedAction.Add) {

                var itms = e.NewItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++)
                    sumFrstSem += (int)tiles[i].Total.Value;

                lablefrstSem.Content = sumFrstSem;

            }
            if (e.Action == NotifyCollectionChangedAction.Remove) {
                
                var itms = e.OldItems;
                List<ListBoxItem> flds = new List<ListBoxItem>();
                flds.AddRange(itms.OfType<ListBoxItem>());

                List<Tile> tiles = new List<Tile>();

                for (int i = 0; i < flds.Count; i++)
                    tiles.Add((Tile)flds[i].Content);


                for (int i = 0; i < tiles.Count; i++)
                    sumFrstSem -= (int)tiles[i].Total.Value;

                lablefrstSem.Content = sumFrstSem;
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

    }
}
