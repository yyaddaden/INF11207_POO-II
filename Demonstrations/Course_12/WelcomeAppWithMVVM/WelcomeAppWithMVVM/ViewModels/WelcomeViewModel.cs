using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WelcomeAppWithMVVM.ViewModels
{
    class WelcomeViewModel
    {
        public Models.Greeting Greeting { get; set; }
        public ObservableCollection<string> Jobs { get; set; }

        public ICommand GreetingCommand { get; private set; }

        public WelcomeViewModel()
        {
            Greeting = new Models.Greeting();
            Jobs = new ObservableCollection<string>()
            {
                "Étudiant",
                "Ingénieur",
                "Professeur",
                "Directeur"
            };

            GreetingCommand = new RelayCommand(
                o => Greeting.IsValid,
                o => DisplayMessage()
            );
        }

        private void DisplayMessage()
        {
            Greeting.Message = $"Bienvenue {Greeting.Name} ({Greeting.Job})";
        }
    }
}
