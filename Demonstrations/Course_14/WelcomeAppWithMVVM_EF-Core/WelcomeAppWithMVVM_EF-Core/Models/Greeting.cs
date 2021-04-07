using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeAppWithMVVM_EF_Core.Models
{
    class Greeting
    {
        public int GreetingId { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public static void StoreGreeting(Greeting greeting)
        {
            WelcomeAppDbContext welcomeAppDbContext = new WelcomeAppDbContext();
            welcomeAppDbContext.Greetings.Add(new Greeting() 
            { 
                UserName = greeting.UserName, 
                Message = greeting.Message, 
                JobId = greeting.JobId 
            });
            welcomeAppDbContext.SaveChanges();
        }
    }
}
