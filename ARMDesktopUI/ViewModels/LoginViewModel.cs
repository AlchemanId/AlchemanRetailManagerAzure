using ARMDesktopUI.EventModels;
using ARMDesktopUI.Helpers;
using ARMDesktopUI.Library.API;
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
        private string _username = "test@gmail.com";
        private string _password = "Test123!";
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;
        
        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
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

        public bool IsErrorVisible
        {
            get 
            {
                bool output = false;
                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }
                return output; 
            }
        }
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            { 
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
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
            try
            {
                ErrorMessage = "";
                var result = await _apiHelper.Authenticate(Username, Password);

                // capture more informtion about the user
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);
                await _events.PublishOnUIThreadAsync(new LogOnEvent(), new System.Threading.CancellationToken());
            }
            catch ( Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
