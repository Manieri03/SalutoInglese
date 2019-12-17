using System;
using System.Collections.Generic;
using System.IO;
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

namespace SalutoInglese
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string file = @"stato.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Greet_Click(object sender, RoutedEventArgs e)
        {
           
            string nome = (txtnome.Text);
            string cognome =(txtcognome.Text);
            var datadinascita =data.SelectedDate;
            var today = DateTime.Today;

            if (datadinascita > today)
            {
                MessageBox.Show("non puoi essere nato nel futuro", "avviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (nome == "" || cognome == "")
                {
                    MessageBox.Show("Inserire nome e cognome", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                {
                    lblsaluto.Content = $"Hello {nome} {cognome}, {datadinascita}";
                }

            }

            
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            string nome = (txtnome.Text);
            string cognome = (txtcognome.Text);
            var datadinascita = data.SelectedDate;
            using (StreamWriter w = new StreamWriter("Test.txt", true, Encoding.UTF8))
            {
                w.WriteLine($"{nome},{cognome},{datadinascita.Value.ToShortDateString()}");
                w.Flush();  
            }
            MessageBox.Show("ho stampato sul file di testo", "informazione", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void check_Checked(object sender, RoutedEventArgs e)
        {
            print.IsEnabled = true;
        }

        private void check_Unchecked(object sender, RoutedEventArgs e)
        {
            print.IsEnabled = false;
        }
    }
}
