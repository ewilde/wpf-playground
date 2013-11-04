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
using System.Windows.Shapes;

namespace basic.wpf.databinding
{
    /// <summary>
    /// Interaction logic for view.xaml
    /// </summary>
    public partial class view : Window
    {
        public view()
        {
            InitializeComponent();
        }

        private void View_OnLoaded(object sender, RoutedEventArgs e)
        {
            Statistics.Monitor.Split("view loaded");
        }
    }
}
