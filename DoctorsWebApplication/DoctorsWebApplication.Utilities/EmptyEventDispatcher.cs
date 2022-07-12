namespace DoctorsWebApplication.Utilities
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  public class EmptyEventDispatcher : IEventDispatcher
  {
    #region IEventDispatcher

    public void Dispatch( Action eventAction )
    {
    }
    #endregion
  }
}
