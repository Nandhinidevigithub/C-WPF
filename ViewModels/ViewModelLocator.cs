namespace UsingWPF
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel
        {
            get { return IocKernel.Get<MainViewModel>(); } // Loading UserControlViewModel will automatically load the binding for IStorage
        }
        public EmployeeViewModel EmployeeViewModel
        {
            get { return IocKernel.Get<EmployeeViewModel>(); } // Loading UserControlViewModel will automatically load the binding for IStorage
        }
        public StudentViewModel StudentViewModel
        {
            get { return IocKernel.Get<StudentViewModel>(); } // Loading UserControlViewModel will automatically load the binding for IStorage
        }
    }
}
