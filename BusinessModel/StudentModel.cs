using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingWPF
{
    public class StudentModel : INotifyPropertyChanged
    {
        private string _id, _name, _roll, _marks;
        public string Id 
        {
            get { return _id; }
            set
            {
                _id = value;
            } 
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_id == "A001")
                {
                    _roll = "X001";
                    OnPropertyChanged("Roll");
                }
                _name = value;
            }
        }
        public string Roll
        {
            get { return _roll; }
            set
            {
                _roll = value;
            }
        }
        public string Marks
        {
            get { return _marks; }
            set
            {
                _marks = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }            
        }
    }
}
