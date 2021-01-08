using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using CommBetweenComponents.Model;

namespace CommBetweenComponents.Controllers
{
    /// <summary>
    /// Interaction logic for EmployessOnJob.xaml
    /// </summary>
    public partial class EmployessOnJob : UserControl
    {
        private List<Employee> _Employees = new List<Employee>
        {
            new Employee
            {
                Id = 1, Name = "Abhiroop", Jobs = new List<Job>
                {
                    new Job{Id = 1,Title = "Associate"},
                    new Job{Id = 2,Title = "SDE1"}
                }
            },
            new Employee
            {
                Id = 2, Name = "Arthy", Jobs = new List<Job>
                {
                    new Job{Id = 3,Title = "Tester"},
                    new Job{Id = 2,Title = "SDE1"}
                }
            },
            new Employee
            {
                Id = 3, Name = "Manoj", Jobs = new List<Job>
                {
                    new Job{Id = 4,Title = "Developer"},
                    new Job{Id = 5,Title = "SDE2"}
                }
            },
            new Employee
            {
                Id = 4, Name = "Naga", Jobs = new List<Job>
                {
                    new Job{Id = 3,Title = "Tester"},
                    new Job{Id = 6,Title = "Architect"}
                }
            },
            new Employee
            {
                Id = 5, Name = "Raj", Jobs = new List<Job>
                {
                    new Job{Id = 5,Title = "SDE5"},
                    new Job{Id = 6,Title = "Architect"}
                }
            }
        };

        public EmployessOnJob()
        {
            InitializeComponent();
            Mediator.GetInstance().JobChanged += (s, e) =>
            {
                BindData(e.Job);
            };
        }

        private void BindData(Job job)
        {
            this.DataContext = job;
            var emps = _Employees.Where(e => e.Jobs.Any(j => j.Id == job.Id));
            EmployeeListView.ItemsSource = emps;
        }
    }
}
