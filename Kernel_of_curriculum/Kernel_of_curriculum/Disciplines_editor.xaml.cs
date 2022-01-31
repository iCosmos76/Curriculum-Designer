using System;
using System.Collections.Generic;
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

namespace Kernel_of_curriculum
{
    /// <summary>
    /// Логика взаимодействия для Disciplines_editor.xaml
    /// </summary>
    public partial class Disciplines_editor : Window {
        
        public List<Discipline> LstDiscipline = new List<Discipline> {
            new Discipline { Name = "...",
            SokrName = "...",
            Blok = new string[]{"Блок 1 «Дисциплины","Блок 2 «Практика»","Блок 3 «ГИА" },
            TheoryRab = 3,
            Kateg = new Kategoriya("","#FF008910"),
            FlagPromAttest = false,
            PromAttest = 1,
            FlagKurs = false,
            Kurs = 1}
};
            
        public Disciplines_editor()
        {
            InitializeComponent();
            dtGridElement.ItemsSource = LstDiscipline;
        }
    }

    

    public class Kategoriya {
        public string Name { get; set; }
        public string Cvet { get; set; }

        public Kategoriya(string name, string cvet) {
            Name = name;
            Cvet = cvet;
        }
    }

    public class Discipline {

        public string Name { get; set; }
        public string SokrName { get; set; }
        public string[] Blok = new string[3];
        public Kategoriya Kateg;
        public int TheoryRab { get; set; }
        public bool FlagPromAttest { get; set; }
        public int PromAttest { get; set; }
        public bool FlagKurs { get; set; }
        public int Kurs { get; set; }
    
        public Discipline() {
            Name = "...";
            SokrName = "...";
            Blok[0] = "Блок 1 «Дисциплины»";
            Blok[1] = "Блок 2 «Практика»";
            Blok[2] = "Блок 3 «ГИА»";
            TheoryRab = 3;
            Kateg = new Kategoriya("","#FF008910");
            FlagPromAttest = false;
            PromAttest = 1;
            FlagKurs = false;
            Kurs = 1;
        }
 
    }
}
