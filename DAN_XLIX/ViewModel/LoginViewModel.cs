using DAN_XLIX.Command;
using DAN_XLIX.Service;
using DAN_XLIX.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIX.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        Login login;

        private tblUser _currentUser;
        public tblUser currentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged("currentUser");
            }
        }

        public LoginViewModel(Login openLogin)
        {
            login = openLogin;
            currentUser = new tblUser();
        }

        #region Commands
        private ICommand _loginBtn;
        public ICommand loginBtn
        {
            get
            {
                if (_loginBtn == null)
                {
                    _loginBtn = new RelayCommand(LoginExecute, CanLoginExecute);
                }
                return _loginBtn;
            }
        }

        //check who has log in
        private void LoginExecute(object obj)
        {
            currentUser.password = (obj as System.Windows.Controls.PasswordBox).Password;
            if(currentUser.username == "ownerWPF" && currentUser.password == "ownerWPF")
            {
                Owner o = new Owner();
                login.Close();
                o.ShowDialog();
            }
            else
            {
                currentUser = Service.Service.IsValidUser(currentUser.username, currentUser.password);
                if (currentUser != null)
                {
                    if (currentUser.role == "staff")
                    {
                        Staff s = new Staff();
                        login.Close();
                        s.ShowDialog();
                    }
                    else
                    {
                        Manager m = new Manager();
                        login.Close();
                        m.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Try again.");
                }
            }
        }

        private bool CanLoginExecute(object obj)
        {
            return true;
        }
        #endregion


    }
}
