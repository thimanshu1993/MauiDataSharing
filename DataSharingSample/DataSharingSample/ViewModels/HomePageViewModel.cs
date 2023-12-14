using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataSharingSample.Abstract;
using DataSharingSample.Models;
using DataSharingSample.Views;

namespace DataSharingSample.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                NavigatedToEmployeeDetails(selectedEmployee);
                OnPropertyChanged("SelectedEmployee");
            }
        }

        ISharedService _SharedService;

        public HomePageViewModel(ISharedService sharedService)
        {
            try
            {
                _SharedService = sharedService;
                Employees = GetEmployee();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void NavigatedToEmployeeDetails(Employee employee)
        {
            try
            {
                if (employee is null)
                {
                    return;
                }
                _SharedService.Add<Employee>("SelectedEmployee", employee);
                MainThread.BeginInvokeOnMainThread(async () => { await App.Current.MainPage.Navigation.PushAsync(new DetailPage(), true); });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private ObservableCollection<Employee> GetEmployee()
        {
            return new ObservableCollection<Employee>()
            {
                new Employee(){ ID= 1, Name = "Employee1", Designation = "Jr. Eng" },
                new Employee(){ ID= 2, Name = "Employee2", Designation = "Sr. Eng" },
                new Employee(){ ID= 3, Name = "Employee3", Designation = "Eng" },
                new Employee(){ ID= 4, Name = "Employee4", Designation = "Mgr" },
                new Employee(){ ID= 5, Name = "Employee5", Designation = "Jr. Mgr" },
                new Employee(){ ID= 6, Name = "Employee6", Designation = "Sr. Eng" },
                new Employee(){ ID= 7, Name = "Employee7", Designation = "Jr. Lead" },
                new Employee(){ ID= 8, Name = "Employee8", Designation = "Eng" },
                new Employee(){ ID= 9, Name = "Employee9", Designation = "Eng" },
                new Employee(){ ID= 10, Name = "Employee10", Designation = "Lead" },
            };
        }
    }
}

