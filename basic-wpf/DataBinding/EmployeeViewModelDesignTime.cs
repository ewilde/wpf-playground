using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic.wpf.DataBinding
{
    using System.IO;
    using System.Windows;

    using basic.wpf.Data;
    using basic.wpf.Model;

    using EnvDTE;

    using basic.wpf.Statistics;

    public class EmployeeViewModelDesignTime : EmployeeListViewModel
    {
        public EmployeeViewModelDesignTime() : 
            base(new CsvRepository<Employee>(Path.Combine(ProjectPath.Path, @"..\Data\uk-500.csv")), false, new OperationTimer())
        {
        
        }
    }
}
