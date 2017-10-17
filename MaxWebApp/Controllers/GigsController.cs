﻿using MaxWebApp.Models;
using MaxWebApp.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace MaxWebApp.Controllers
{
    public class GigsController : Controller


    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            viewModel.Genres = _context.Genres.ToList();
            if (!ModelState.IsValid) return View("Create", viewModel);
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                Datetime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();
            return RedirectToAction($"Index", $"Home");
        }
    }
}