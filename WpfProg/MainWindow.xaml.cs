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
using System.Data.Entity;

namespace WpfProg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PosTutEntities db = new PosTutEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            System.Windows.Data.CollectionViewSource productViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // productViewSource.Source = [generic data source]

            //resultcombo_SelectionChanged(this.resultcombo, null);

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($" This Description is : {this.Desc.Text} ");
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            this.ch1.IsChecked = this.ch2.IsChecked = this.ch3.IsChecked = this.ch4.IsChecked = this.ch5.IsChecked =
            this.ch11.IsChecked = this.ch22.IsChecked = this.ch33.IsChecked = this.ch44.IsChecked = this.ch55.IsChecked = false;

        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            this.Desc.Text += ((CheckBox)sender).Content;
            this.Desc.Text = this.Desc.Text + "/";
        }
              

        private void resultcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.resltname == null)
                return;

            var combo = (ComboBox)sender;
            var valuee = (ComboBoxItem)combo.SelectedValue;

            this.resltname.Text = (string)valuee.Content;

        }
    }
}
