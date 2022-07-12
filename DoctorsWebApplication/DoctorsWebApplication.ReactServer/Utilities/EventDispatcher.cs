using DoctorsWebApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsWebApplication.Utilities
{
    public class EventDispatcher : IEventDispatcher
    {
        #region IEventDispatcher

        public void Dispatch(Action eventAction)
        {
        }
        #endregion
    }
}
