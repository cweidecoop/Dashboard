using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Models;
using Microsoft.AspNetCore.Identity;
using Dashboard.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Dashboard.ViewModels;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {

        private DashboardContext _context;

        private UserManager<DashboardUser> _userManager;

        public HomeController(UserManager<DashboardUser> userManager, DashboardContext dbContext)
        {
            _userManager = userManager;
            _context = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> TrainingLog()
        {
            var user = await _userManager.GetUserAsync(User);

            List<ParaLog> inserviceLogs = _context.ParaLogs.Where(p => p.UserID == user.UserID).ToList();

            TrainingLogViewModel newLog = new TrainingLogViewModel()
            {
               ParaLogs = inserviceLogs
            };

            return View(newLog);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> TrainingLog(TrainingLogViewModel trainingLogViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            var newParaLog = new ParaLog()
            {
                UserID = user.UserID,
                Date = trainingLogViewModel.Date,
                TimeIn = trainingLogViewModel.StartTime,
                TimeOut = trainingLogViewModel.EndTime,
                TimeAccrued = trainingLogViewModel.EndTime - trainingLogViewModel.StartTime,
                Description = trainingLogViewModel.Description

            };
            _context.ParaLogs.Add(newParaLog);
            _context.SaveChanges();
            return Redirect("/Home/TrainingLog");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
