using System;
using Remail.BusinessLogic.DataModel;

namespace Remail.BusinessLogic.UnitOfWork
{    
    public interface IUnitOfWork : IDisposable
    {
		EntityContainer Context { get; }
        void Commit();        
    }
}
