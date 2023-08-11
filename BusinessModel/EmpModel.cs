using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingWPF
{
    public class EmpModel : INotifyPropertyChanged
    {        
        private string _id, _empName, _grade, _dept;
        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }
        public string EmpName
        {
            get { return _empName; }
            set
            {
                //if (_id == "E002")
                //{
                //    _grade = "X002";
                //    OnPropertyChanged("Grade");
                //}
                _empName = value;
            }
        }
        public string Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
            }
        }

        public string Department
        {
            get { return _dept; }
            set
            {
                _dept = value;
            }
        }

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
