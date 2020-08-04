using DAN_XLIX.Command;
using DAN_XLIX.Service;
using DAN_XLIX.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIX.ViewModel
{
    class OwnerViewModel:ViewModelBase
    {
        #region Prop
        Owner owner;
        private tblUser _newEmployee;
        public tblUser newEmployee
        {
            get
            {
                return _newEmployee;
            }
            set
            {
                _newEmployee = value;
                OnPropertyChanged("newEmployee");
            }
        }

        private tblManager _newManager;
        public tblManager newManager
        {
            get
            {
                return _newManager;
            }
            set
            {
                _newManager = value;
                OnPropertyChanged("newManager");
            }
        }

        private tblStaff _newStaff;
        public tblStaff newStaff
        {
            get
            {
                return _newStaff;
            }
            set
            {
                _newStaff = value;
                OnPropertyChanged("newStaff");
            }
        }
        #endregion

        #region constructor
        public OwnerViewModel(Owner openOwner)
        {
            owner = openOwner;
            newEmployee = new tblUser();
            newManager = new tblManager();
            newStaff = new tblStaff();
        }
        #endregion

        #region Visibility
        private Visibility _viewStaff = Visibility.Collapsed;
        public Visibility viewStaff
        {
            get
            {
                return _viewStaff;
            }
            set
            {
                _viewStaff = value;
                OnPropertyChanged("viewStaff");
            }
        }
        private Visibility _viewManager = Visibility.Collapsed;
        public Visibility viewManager
        {
            get
            {
                return _viewManager;
            }
            set
            {
                _viewManager = value;
                OnPropertyChanged("viewManager");
            }
        }
        private ICommand _createStaff;
        public ICommand createStaff
        {
            get
            {
                if (_createStaff == null)
                {
                    _createStaff = new RelayCommand(param => CreateStuffExecute(), param => CanCreateStuffExecute());
                }
                return _createStaff;
            }
        }

        private void CreateStuffExecute()
        {

            try
            {
                
                if(viewManager == Visibility.Visible)
                {
                    viewManager = Visibility.Collapsed;
                }
                viewStaff = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCreateStuffExecute()
        {
            return true;
        }

        private ICommand _createManager;
        public ICommand createManager
        {
            get
            {
                if (_createManager == null)
                {
                    _createManager = new RelayCommand(param => CreateManagerExecute(), param => CanCreateManagerExecute());
                }
                return _createManager;
            }
        }

        private void CreateManagerExecute()
        {

            try
            {
                if(viewStaff == Visibility.Visible)
                {
                    viewStaff = Visibility.Hidden;
                }
                viewManager = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCreateManagerExecute()
        {
            return true;
        }
        #endregion

        #region Commands

        private ICommand _save1;
        public ICommand save1
        {
            get
            {
                if (_save1 == null)
                {
                    _save1 = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return _save1;
            }
        }

        private void SaveExecute()
        {
            try
            {
                tblUser e = Service.Service.AddUser(newEmployee);
                newManager.userId = e.userId;
                tblManager me = Service.Service.AddManager(newManager);

                if (e != null && me!=null)
                {
                    MessageBox.Show("Manager has been succesfully created!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (Service.Service.IsValidUser(newEmployee.username, newEmployee.password) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private ICommand _save2;
        public ICommand save2
        {
            get
            {
                if (_save2 == null)
                {
                    _save2 = new RelayCommand(param => Save2Execute(), param => CanSave2Execute());
                }
                return _save2;
            }
        }

        private void Save2Execute()
        {
            try
            {
                tblUser e = Service.Service.AddUser(newEmployee);
                newStaff.userId = e.userId;
                tblStaff me = Service.Service.AddStaff(newStaff);

                if (e != null && me!=null)
                {
                    MessageBox.Show("Staff has been succesfully created!");
                }
                else
                {
                    MessageBox.Show("Error. Try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSave2Execute()
        {
            if (Service.Service.IsValidUser(newEmployee.username, newEmployee.password) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private ICommand _logOut;
        public ICommand logOut
        {
            get
            {
                if (_logOut == null)
                {
                    _logOut = new RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
                }
                return _logOut;
            }
        }

        private void LogOutExecute()
        {
            try
            {
                Login login = new Login();
                owner.Close();
                login.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogOutExecute()
        {
            return true;
        }
        #endregion
    }
}
