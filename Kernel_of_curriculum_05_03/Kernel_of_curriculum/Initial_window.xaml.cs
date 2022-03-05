using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kernel_of_curriculum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Create_project_Click(object sender, RoutedEventArgs e)
        {
            var crt = new Main_window();
            crt.Show();
            Close();
        }

        private void btn_Open_exist_project_Click(object sender, RoutedEventArgs e)
        {
            var opn = new Disciplines_editor();
            opn.Show();
            Close();
        }
    }
}
