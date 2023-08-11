using CsvHelper;
using Services;
using DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using UsingWPF.Commands;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace UsingWPF
{    
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private ICommand _insCommand, _updCommand, _delCommand, _getCommand;        
        string file = "C:\\MyFiles\\EmployeeData.csv";       
        EmpDataModel data = new EmpDataModel();
        public EmployeeViewModel(IWeatherForecast weatherForecast)
        {
            Employees = new ObservableCollection<EmployeeModel>();            
        }
        public bool CanEnable
        {
            get
            {
                return (_selectedIndex >= 0);
            }
        }
        private int _selectedIndex = -1;
        public int SelectedRowIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;                
                OnPropertyChanged("SelectedRowIndex");                
            }
        }
        private EmployeeModel _selectedRow;
        public EmployeeModel SelectedRow
        {
            get
            {
                return _selectedRow;
            }
            set
            {
                _selectedRow = value;                
                OnPropertyChanged("SelectedRow");
            }
        }        
        public ICommand GetCommand
        {
            get
            {
                if (_getCommand == null)
                {
                    _getCommand = new RelayCommand(                        
                        param => GetEmployeeList(),
                        param => CanClick());
                }                
                return _getCommand;
            }
        }
        public ICommand InsertCommand
        {
            get
            {
                if (_insCommand == null)
                {
                    _insCommand = new RelayCommand(                        
                        param => AddNewEmployee(),
                        param => CanClick());
                }                
                return _insCommand;
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                if (_updCommand == null)
                {
                    _updCommand = new RelayCommand(                        
                        param => UpdateEmployee(),
                        param => CanClick());
                }                
                return _updCommand;
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                if (_delCommand == null)
                {
                    _delCommand = new RelayCommand(
                        param => DeleteEmployee()                        
                        );
                }
                return _delCommand;
            }
        }
        private bool CanClick()
        {
            return true;
            
        }
        private async void GetEmployeeList()
        {            
            var data = await GetAsync();            
            var employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(data);
            if (employees.Count == 0)
                MessageBox.Show("There are no records to display");
            Employees.Clear();
            foreach (var e in employees)
            {
                Employees.Add(e);
            }
        }
        private async void AddNewEmployee()
        {
            if(SelectedRow != null)
            {
                EmployeeModel employee = new EmployeeModel()
                {
                    ID = SelectedRow.ID,
                    EmpName = SelectedRow.EmpName,
                    Grade = SelectedRow.Grade
                };
                var data = await PostAsync(employee);
                SelectedRowIndex = -1;
            }
        }
        private async void UpdateEmployee()
        {            
            EmployeeModel employee = new EmployeeModel()
            {
                ID = SelectedRow.ID,
                EmpName = SelectedRow.EmpName,
                Grade = SelectedRow.Grade
            };
            var data = await PutAsync(employee);
            SelectedRowIndex = -1;
        }
        private async void DeleteEmployee()
        {
            
            if(SelectedRow != null)
            {
                var data = await DeleteAsync(SelectedRow.ID);
                var employee = JsonConvert.DeserializeObject<List<EmployeeModel>>(data);
                Employees.Clear();
                foreach (var e in employee)
                {
                    Employees.Add(e);
                }
            }
            else
            {
                MessageBox.Show("There are no rows to delete");
            }
            
            SelectedRowIndex = -1;
        }        
        public async Task<string> GetAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5059");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            var response = await client.GetAsync("Employees/GetEmployee");
            if (response.IsSuccessStatusCode)
            {
                Heading = "Get call Success";
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Heading = response.StatusCode.ToString();
                return string.Empty;
            }
        }
        public async Task<string> PostAsync(EmployeeModel employee)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5059");

            var myContent = JsonConvert.SerializeObject(employee);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("Employees/AddEmployee", byteContent);

            return response.Content.ReadAsStringAsync().Result;
        }
        public async Task<string> PutAsync(EmployeeModel employee)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5059");

            var myContent = JsonConvert.SerializeObject(employee);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync("Employees/UpdateEmployee", byteContent);

            return response.Content.ReadAsStringAsync().Result;
        }
        public async Task<string> DeleteAsync(int id)       
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5059");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.DeleteAsync("Employees/DeleteEmployee?id=" + id);            
            if (response.IsSuccessStatusCode)
            {
                Heading = "Delete call Success";
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Heading = response.StatusCode.ToString();
                return string.Empty;
            }
        }
        public string Heading { get; set; }
        public ObservableCollection<EmployeeModel> Employees { get; set; }
        public ObservableCollection<EmpModel> EmpData { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
