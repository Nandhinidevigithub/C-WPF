using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingWPF
{
    public class EmployeeModel1 : INotifyPropertyChanged
    {
        private string _id, _empName, _empNum, _dept;
        private List<Skill> _skills;
        private List<SubSkill> _SubSkills;
        public string ID 
        { 
            get { return _id; } 
            set {
                _id = value; 
            } 
        }
        public string EmpName
        {
            get { return _empName; }
            set
            {
                if (_id == "E002")
                {
                    _empNum = "X002";
                    OnPropertyChanged("EmpNum");
                }
                _empName = value;
            }
        }
        public string EmpNum
        {
            get { return _empNum; }
            set
            {
                _empNum = value;
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
        public List<Skill> Skills
        {
            get { return _skills; }
            set
            {
                _skills = value;
            }
        }
        public List<SubSkill> SubSkills
        {
            get { return _SubSkills; }
            set
            {
                _SubSkills = value;
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
