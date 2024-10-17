using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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

namespace Bevolkingsgroei
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

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            landTextBox.Clear();
            huidigeBevolkingTextBox.Clear();
            groeipercentageTextBox.Clear();
            resultTextBox.Clear();
            landTextBox.Focus();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {

            bool isValidAantalBevolking = double.TryParse(huidigeBevolkingTextBox.Text, out double bevolking);
            bool isValidPercentage = double.TryParse(groeipercentageTextBox.Text, out double percentage);
            string land = landTextBox.Text;
            double dubbeleBevolking = bevolking * 2;
            int jaren = 0;

            if (percentage == 0)
            {
                resultTextBox.Text = "groeipercentage nooit een verdubbeling van de bevolking";
            } 
            else
            {
                for (int i = 0; bevolking < dubbeleBevolking; i++)
                {
                    // berekenen van bevolking na loop
                    
                    bevolking *= (1 + percentage / 100);
                    jaren++;
                    Console.WriteLine(jaren);
                }

                resultTextBox.Text = $"Verdubbeling bevolking in {land} na {jaren}\n" +
                    $"\n" +
                    $"Nieuwe bevolkingsaantal op dat moment: {bevolking}";
            }
        }
    }
}
