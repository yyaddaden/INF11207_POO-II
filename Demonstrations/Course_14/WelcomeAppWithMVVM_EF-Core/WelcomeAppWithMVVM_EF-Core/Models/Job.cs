using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WelcomeAppWithMVVM_EF_Core.Models
{
    class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }

        public static List<Job> GetJobs()
        {
            List<Job> Jobs;
            WelcomeAppDbContext welcomeAppDbContext = new WelcomeAppDbContext();
            Jobs = welcomeAppDbContext.Jobs.ToList();
            return Jobs;
        }

        public static Job GetJob(string title)
        {
            WelcomeAppDbContext welcomeAppDbContext = new WelcomeAppDbContext();
            Job job = welcomeAppDbContext.Jobs.Where(j => j.Title == title).First();
            return job;
        }
    }
}
