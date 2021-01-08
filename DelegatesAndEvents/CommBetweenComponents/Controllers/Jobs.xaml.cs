using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommBetweenComponents.Model;

namespace CommBetweenComponents.Controllers
{
    /// <summary>
    /// Interaction logic for Jobs.xaml
    /// </summary>
    public partial class Jobs : UserControl
    {
        List<Job> _Jobs = new List<Job>
        {
            new Job {Id = 1, Title = "Associate", Exp = 6},
            new Job {Id = 2, Title = "SDE1", Exp = 5},
            new Job {Id = 3, Title = "Tester", Exp = 4},
            new Job {Id = 4, Title = "Developer", Exp = 3},
            new Job {Id = 5, Title = "SDE2", Exp = 2},
            new Job {Id = 6, Title = "Architect", Exp = 1}
        };


        public Jobs()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            JobsComboBox.ItemsSource = _Jobs;
        }

        private void JobsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mediator.GetInstance().OnJobChanged(this,(Job)JobsComboBox.SelectedItem);
        }
    }
}
