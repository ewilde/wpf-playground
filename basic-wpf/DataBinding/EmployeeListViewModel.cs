namespace basic.wpf.DataBinding
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Documents;

    using basic.wpf.Data;
    using basic.wpf.Model;

    using basic_wpf.Annotations;
    using basic_wpf.Data;

    public class EmployeeListViewModel : INotifyPropertyChanged
    {
        private readonly IRepository<Employee> repository;
        private ObservableCollection<Employee> employees;

        public EmployeeListViewModel()
            : this(new CsvRepository<Employee>(@"Data\uk-500.csv"), true)
        {
        }

        public EmployeeListViewModel(IRepository<Employee> repository, bool largeMode)
        {
            Statistics.Monitor.Split("employee view model begin");

            this.repository = repository;

            if (largeMode)
            {
                const int maxSize = 1000;
                var largeList = new List<Employee>(maxSize);
                var collection = this.repository.GetAll().ToArray();
                    
                for (int i = 0; i < maxSize/500; i++)
                {
                    largeList.AddRange(collection);
                }

                this.employees = new ObservableCollection<Employee>(largeList);
            }
            else
            {
                this.employees = new ObservableCollection<Employee>(this.repository.GetAll());
            }

            Statistics.Monitor.Split("employee view model begin");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Employee> Employees
        {
            get
            {
                return this.employees;
            }
            set
            {
                if (this.employees == value)
                {
                    return;
                }

                this.employees = value;
                this.OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
