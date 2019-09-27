using Microsoft.AspNetCore.Mvc;
using MvcCoreApp.Data;
using MvcCoreApp.Models;
using System;
using System.Collections.Generic;

namespace MvcCoreApp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork uow) : base(uow)
        {
        }

        public IActionResult Index()
        {
            //============
            //Get examples
            //============
            List<Person> persons = _unitOfWork.PersonService.GetAll();

            Person person = _unitOfWork.PersonService.GetById(new Guid("DC8BC64A-A982-4E99-B303-D4EFE81A3249"));

            List<Job> jobs = _unitOfWork.JobService.GetAll();

            List<Activity> activities = _unitOfWork.ActivityService.GetAll();


            //===============
            //Insert examples
            //===============
            Job j1 = _unitOfWork.JobService.Create(new Job { Id = Guid.NewGuid(), Code = "CEO", Title = "Chief executive officer" });
            Activity a1 = _unitOfWork.ActivityService.Create(new Activity { Id = Guid.NewGuid(), Code = "BADM", Title = "Badminton" });


            //==============
            //Update example
            //==============
            Job jobToUpdate = _unitOfWork.JobService.GetById(new Guid("91CB90F1-3C9F-499B-8001-634DC062A40C"));
            jobToUpdate.Title = "Title new value";
            _unitOfWork.JobService.Update(jobToUpdate);


            //==============
            //Delete example
            //==============
            Activity activityToDelete = _unitOfWork.ActivityService.GetById(new Guid("A8B2CE47-B96D-4ACA-9265-43791E9E19EF"));
            _unitOfWork.ActivityService.Delete(activityToDelete);


            _unitOfWork.Save(); //For Insert, Update and Delete examples


            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}