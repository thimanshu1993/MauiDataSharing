using System;
using DataSharingSample.Abstract;
using DataSharingSample.Models;

namespace DataSharingSample.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        ISharedService _SharedService;

        public DetailPageViewModel(ISharedService sharedService)
        {
            try
            {
                _SharedService = sharedService;
                GetSelectedEmployee();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void GetSelectedEmployee()
        {
            try
            {
                SelectedEmployee = _SharedService.GetValue<Employee>("SelectedEmployee");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

