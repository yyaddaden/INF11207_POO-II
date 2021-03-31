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

namespace WelcomeApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void WelcomeAction(object sender, RoutedEventArgs e)
        {
            string personNameValue = personName.Text;
            ComboBoxItem comboBoxItem = (ComboBoxItem)personJob.SelectedValue;

            if (!string.IsNullOrEmpty(personNameValue) && comboBoxItem != null)
            {
                string personJobValue = comboBoxItem.Content.ToString();
                string generatedSentence = $"Bienvenue {personNameValue} ({personJobValue})";
                welcomeWords.Content = generatedSentence;
            }
            else
                MessageBox.Show("Veuillez remplir tous les champs !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
