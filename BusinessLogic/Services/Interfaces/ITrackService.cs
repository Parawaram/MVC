using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remail.BusinessLogic.DataModel;

namespace Remail.BusinessLogic.Services.Interfaces
{
    public interface ITrackService
    {
        IList<Track> GetTracks();
    }
}
