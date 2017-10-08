using MaxWebApp.Models;
using System;
using System.Collections.Generic;

namespace MaxWebApp.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }

        public DateTime DateTime => DateTime.Parse($"{Date} {Time}");

        public IEnumerable<Genre> Genres;
    }
}