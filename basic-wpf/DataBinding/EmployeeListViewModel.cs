namespace basic.wpf.DataBinding
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Documents;

    using StructureMap;

    using basic.wpf.Data;
    using basic.wpf.Model;
    using basic.wpf.Statistics;

    using basic_wpf.Annotations;
    using basic_wpf.Data;

    public class EmployeeListViewModel : INotifyPropertyChanged
    {
        private readonly IRepository<Employee> repository;

        private readonly IOperationTimer operationTimer;

        private ObservableCollection<Employee> employees;

        private IOperationResult timer;

        public EmployeeListViewModel()
            : this(new CsvRepository<Employee>(@"Data\uk-500.csv"), true, ObjectFactory.GetInstance<IOperationTimer>())
        {
        }

        public EmployeeListViewModel(IRepository<Employee> repository, bool largeMode, IOperationTimer operationTimer)
        {
            timer = operationTimer.Begin("Employee view model");

            this.repository = repository;
            this.operationTimer = operationTimer;

            if (largeMode)
            {
                const int maxSize = 10000;
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

            timer.End(timer);
            Debug.WriteLine(timer);
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
                this.OnPropertyChanged("ItemCount");
            }
        }

        public int ItemCount
        {
            get
            {
                return this.Employees.Count;
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
