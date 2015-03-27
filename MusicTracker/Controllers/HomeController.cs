using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MusicTracker.Models;
using Remail.BusinessLogic.DataModel;
using Remail.BusinessLogic.Services;
using Remail.BusinessLogic.Services.Interfaces;
using Remail.BusinessLogic.UnitOfWork;

namespace MusicTracker.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        private ITrackService _trackService;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tracks()
        {
            var tracks = _trackService.GetTracks();

            var tracksViewModel = Mapper.Map<IList<TrackViewModel>>(tracks);

            ViewBag.Tracks = tracksViewModel;

            return View();
        }

        public ActionResult LoadingFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetFile(TrackLoadintViewModel track)
        {
            if (track != null)
            {
                
            }

            return Index();
        }

        public ActionResult Clix()
        {
            return View();
        }

    }
}
