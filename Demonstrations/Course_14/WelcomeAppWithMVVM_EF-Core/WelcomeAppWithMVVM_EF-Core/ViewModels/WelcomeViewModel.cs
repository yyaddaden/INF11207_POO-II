using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WelcomeAppWithMVVM_EF_Core.ViewModels
{
    class WelcomeViewModel : INotifyPropertyChanged
    {
        public Models.Greeting _greeting;

        public string UserName
        {
            get { return _greeting.UserName; }
            set
            {
                if (_greeting.UserName != value)
                {
                    _greeting.UserName = value;
                    SetIsValid();
                    OnPropertyChanged();
                }
            }
        }

        public string Job
        {
            get
            {
                if (_greeting.Job != null)
                    return _greeting.Job.Title;
                else
                    return null;
            }
            set
            {
                _greeting.Job = Models.Job.GetJob(value);
                _greeting.JobId = _greeting.Job.JobId;
                SetIsValid();
            }
        }

        public string Message
        {
            get { return _greeting.Message; }
            set
            {
                if (_greeting.Message != value)
                {
                    _greeting.Message = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isValid;

        private void SetIsValid()
        {
            _isValid = !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Job);
        }

        public ObservableCollection<Models.Job> Jobs { get; set; }

        public WelcomeViewModel()
        {
            _greeting = new Models.Greeting();
            Jobs = new ObservableCollection<Models.Job>(Models.Job.GetJobs());

            GreetingCommand = new RelayCommand(
                o => _isValid,
                o => DisplayMessage()
            );
        }

        public ICommand GreetingCommand { get; private set; }

        private void DisplayMessage()
        {
            Message = $"Bienvenue {UserName} ({Job})";
            Models.Greeting.StoreGreeting(_greeting);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
