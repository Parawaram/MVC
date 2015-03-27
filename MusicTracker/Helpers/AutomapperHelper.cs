using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using AutoMapper;
using MusicTracker.Models;
using Remail.BusinessLogic.DataModel;

namespace MusicTracker.Helpers
{
    public class AutomapperHelper
    {
        public static void Initialize()
        {
            InitializeTrack();
        }

        private static void InitializeTrack()
        {
            Mapper.CreateMap<Track, TrackViewModel>();

            Mapper.CreateMap<IList<Track>, IList<TrackViewModel>>();
        }
    }
}