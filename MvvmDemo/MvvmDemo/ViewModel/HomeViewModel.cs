using MvvmDemo.ApiCall;
using MvvmDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemo.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        

        public HomeViewModel()
        {
            try
            {
                GetList();
            }
            catch(Exception ex)
            {

            }
            
        }

        private ObservableCollection<Emlpoyee> employeelist;
        public ObservableCollection<Emlpoyee>Employee
        {
            get { return employeelist; }
            set
            {
                employeelist = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Employee"));
            }
        }

        private string empname;
        public string EmpName
        {
            get { return empname; }
            set { empname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EmpName"));
            }
        }
        public async Task<ObservableCollection<Emlpoyee>> GetList()
        {
            var listdata = await ServiceApi.GetEmplyee();
            try
            {
                
                Employee = new ObservableCollection<Emlpoyee>();
                Emlpoyee emp = new Emlpoyee();
               
                    foreach (var co in listdata)
                    {
                        empname = co.employee_name;
                        Employee.Add(co);
                    };

                
            }
            catch(Exception ex)
            {
                
            }

            return listdata;
        }

       
    }
}
