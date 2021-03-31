using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeAppWithMVVM.Models
{
    class Greeting : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    SetIsValid();
                }
            }
        }

        private string _job;

        public string Job
        {
            get { return _job; }
            set
            {
                if (_job != value)
                {
                    _job = value;
                    SetIsValid();
                }
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isValid;

        public bool IsValid
        {
            get { return _isValid; }
        }

        private void SetIsValid()
        {
            _isValid = !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Job);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
