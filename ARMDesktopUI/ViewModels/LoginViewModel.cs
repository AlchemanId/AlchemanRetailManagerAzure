using ARMDesktopUI.Helpers;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        private IAPIHelper _apiHelper;
        
        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public string Username
        {
            get { return _username; }
            set 
            {
                _username = value;
                NotifyOfPropertyChange(() => _username);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value; 
                NotifyOfPropertyChange(() => _password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn
        {
            get
            {
                bool output = false;
                //if (Username != null && Password != null)
                //{
                //    output = true;
                //}
                if (Username?.Length>0 && Password?.Length>0) 
                {
                    output = true;
                }
                return output;
            }
        }

        public async Task LogIn()
        {
            var result = await _apiHelper.Authenticate(Username, Password);
        }

    }
}
