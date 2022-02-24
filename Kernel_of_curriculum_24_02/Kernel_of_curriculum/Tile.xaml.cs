using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kernel_of_curriculum {
    /// <summary>
    /// Логика взаимодействия для Tile.xaml
    /// </summary>
    public partial class Tile : UserControl {
        public int thrbVl { get; set; }
        public int prmVl { get; set; }
        public int krsVl { get; set; }

        public int ttl { get; set; }

        public Tile() {
            InitializeComponent();
            Total.Value = 3;
        }



        //public event RoutedEventHandler TheoryRab;
        //public event RoutedEventHandler FlagPromAttest;
        //public event RoutedEventHandler PromAttest;
        //public event RoutedEventHandler FlagKurs;



        //public

        //public string NameD { get; set; }
        //public string SokrNameD { get; set; }
        //public string NameK { get; set; }
        //public int IdK { get; set; }
        //public int SelBlok { get; set; }
        //public int TheoryRab { get; set; }
        //public int FlagPromAttest { get; set; }
        //public int PromAttest { get; set; }
        //public int FlagKurs { get; set; }
        //public int Kurs { get; set; }


    }
}
