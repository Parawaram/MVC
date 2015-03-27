using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicTracker.Models
{
    public class TrackViewModel
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string TextOfTrack { get; set; }
    }
}