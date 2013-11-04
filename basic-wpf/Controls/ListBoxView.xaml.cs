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

namespace basic.wpf.Controls
{
    using System.Diagnostics;

    using StructureMap;

    using basic.wpf.Statistics;

    /// <summary>
    /// Interaction logic for ListBoxView.xaml
    /// </summary>
    public partial class ListBoxView : Window
    {
        private IOperationTimer timer;

        private IOperationResult timerResult;

        public ListBoxView()
        {
            timer = ObjectFactory.GetInstance<IOperationTimer>();
            timerResult = timer.Begin("Employee view");
            InitializeComponent();
        }

        private void View_OnLoaded(object sender, RoutedEventArgs e)
        {
            timer.End(timerResult);
            Debug.WriteLine(timerResult);
        }

        private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Open");
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
