using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using UsingWPF.Commands;

namespace UsingWPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ICommand _showEmpCommand, _hideEmpCommand, _hideStudCommand, _showStudCommand;
        private IWeatherForecast _weatherObject;
        private EmployeeView _employeeView;
        private StudentView _studentView;
        public MainViewModel(IWeatherForecast weatherForecast)
        {            
            _weatherObject = weatherForecast;
            Heading = weatherForecast.GetWeather();
            OnPropertyChanged("Heading");
            Employees = new ObservableCollection<EmployeeModel1>()
            {
                new EmployeeModel1()
                {
                    ID = "E001",
                    EmpName = "Sindhu",
                    EmpNum = "E1",
                    Department = "Marketing",
                    Skills = new List<Skill>()
                    {
                        new Skill()
                        {
                            SkillName = ".Net",
                            SubSkills = new List<SubSkill>()
                            {
                                new SubSkill()
                                {
                                    SubSkillName = "VB"
                                }
                            }
                        },
                        new Skill() { SkillName = ".Net Core" }
                    }
                },

                new EmployeeModel1()
                {
                    ID = "E002",
                    EmpName = "Rajesh",
                    EmpNum = "E2",
                    Department = "Finance",
                    Skills = new List<Skill>()
                    {
                        new Skill()
                        {
                            SkillName = "Java",
                            SubSkills = new List<SubSkill>()
                            {
                                new SubSkill()
                                {
                                    SubSkillName = "Core Java"
                                },
                                new SubSkill()
                                {
                                    SubSkillName = "Advanced Java"
                                }
                            }
                        }
                    }
                },

                new EmployeeModel1()
                {
                    ID = "E003",
                    EmpName = "John",
                    EmpNum = "E3",
                    Department = "IT",
                    Skills = new List<Skill>(){new Skill() { SkillName = "Cloud"} }
                },

                new EmployeeModel1()
                {
                    ID = "E004",
                    EmpName = "Kumar",
                    EmpNum = "E4",
                    Department = "Administrative",
                    Skills = new List<Skill>()
                    {
                        new Skill()
                        {
                            SkillName = "Database",
                            SubSkills = new List<SubSkill>()
                            {
                                new SubSkill()
                                {
                                    SubSkillName = "SQL Server"
                                },
                                new SubSkill()
                                {
                                    SubSkillName = "Oracle"
                                }
                            }
                        }
                    }
                }
            };

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
        public ICommand ShowEmpCommand
        {
            get
            {
                if(_showEmpCommand == null)
                {
                    _showEmpCommand = new RelayCommand(
                        param => ShowEmployeeView(),
                        param => CanClick());
                }
                return _showEmpCommand;
            }
        }
        public ICommand HideEmpCommand 
        { 
            get 
            {
                if(_hideEmpCommand == null)
                {
                    _hideEmpCommand = new RelayCommand(
                        param => HideEmployeeView(),
                        param => CanClick());
                }
                return _hideEmpCommand; 
            } 
        }
        public ICommand HideStudCommand
        {
            get
            {
                if (_hideStudCommand == null)
                {
                    _hideStudCommand = new RelayCommand(                        
                        param => HideStudentView(),
                        param => CanClick());
                }
                return _hideStudCommand;
            }
        }
        public ICommand ShowStudCommand
        {
            get
            {
                if (_showStudCommand == null)
                {
                    _showStudCommand = new RelayCommand(                        
                        param => ShowStudentView(),
                        param => CanClick());
                }
                return _showStudCommand;
            }
        }
        private bool CanClick()
        {
            return true;
        }
        private void ShowEmployeeView()
        {                        
            if(null == _employeeView)
            {
                _employeeView = new EmployeeView();
            }
            _employeeView.Show();            
        }

        private void ShowStudentView()
        {           
            if (null == _studentView)
            {
                _studentView = new StudentView();
            }
            _studentView.Show();
        }
        private void HideEmployeeView()
        {
            _employeeView.Hide();
        }
        private void HideStudentView()
        {
            _studentView.Hide();
        }        
        public string Heading { get; set; } = "Learning WPF";
        public ObservableCollection<EmployeeModel1> Employees { get; set; }
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
