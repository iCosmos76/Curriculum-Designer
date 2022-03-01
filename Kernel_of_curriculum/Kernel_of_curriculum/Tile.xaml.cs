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
        }
    }
}
