using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicTracker.Models
{
    public class TrackLoadintViewModel
    {


        [Required]
        public HttpPostedFileBase File { get; set; }

        public string Name { get; set; }

        public string Lyric { get; set; }
    }
}