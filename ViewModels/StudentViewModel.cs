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

namespace UsingWPF
{
    public class StudentViewModel : INotifyPropertyChanged
    {      
        public StudentViewModel(IWeatherForecast weatherForecast)
        {
            Students = new ObservableCollection<StudentModel>()
            {
                new StudentModel()
                {
                    Id = "E001",
                    Name = "Sindhu",
                    Roll = "E1",
                    Marks = "80"
                },
                new StudentModel()
                {
                    Id = "E002",
                    Name = "Rajesh",
                    Roll = "E2",
                    Marks = "90"
                },
                new StudentModel()
                {
                    Id = "E003",
                    Name = "John",
                    Roll = "E3",
                    Marks = "75"
                },
            };

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
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (_clickCommand == null)
                {
                    _clickCommand = new RelayCommand(
                        param => UpdateData()                        
                        );
                }
                return _clickCommand;
            }
        }
        private void UpdateData()
        {
            SelectedRowIndex = -1;
        }        
        public ObservableCollection<StudentModel> Students { get; set; }        
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
