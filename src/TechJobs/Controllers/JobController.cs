using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view
            Job model = jobData.Find(id);

            return View(model);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.
            if (ModelState.IsValid)
            {
                /*Job newJob = new Job()
                {
                    Name = newJobViewModel.Name.ToString(),
                    Employer = jobData.Employers.Find(newJobViewModel.EmployerID),
                    Location = jobData.Locations.Find(newJobViewModel.LocationID),
                    PositionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID),
                    CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID)
                };*/

                Job newJob = new Job();
                newJob.Name = newJobViewModel.Name.ToString();
                newJob.Employer = jobData.Employers.Find(newJobViewModel.EmployerID);
                newJob.Location = jobData.Locations.Find(newJobViewModel.LocationID);
                newJob.PositionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID);
                newJob.CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID);

                //jobData.Jobs.Add(newJob);

                return RedirectToAction("Index", newJob.ID);
            }

            return View(newJobViewModel);
        }
    }
}
