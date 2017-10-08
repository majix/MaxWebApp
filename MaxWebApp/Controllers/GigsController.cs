﻿using MaxWebApp.Models;
using MaxWebApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
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
        public ActionResult Create(GigFormViewModel viewModel)
        {
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            //var artist = _context.Users.Single(u => u.Id == userId);
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                Datetime = DateTime.Parse($"{viewModel.Date} {viewModel.Time}"),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();
            return RedirectToAction($"Index", $"Home");
        }
    }
}