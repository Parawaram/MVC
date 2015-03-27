using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remail.BusinessLogic.DataModel;
using Remail.BusinessLogic.Repository;
using Remail.BusinessLogic.Services.Interfaces;

namespace Remail.BusinessLogic.Services
{
    public class TrackService : ITrackService
    {
        private IRepository<Track> _trackRepository;

        public TrackService(IRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public IList<Track> GetTracks()
        {
            return _trackRepository.GetAll();
        }
    }
}
