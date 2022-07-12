namespace DoctorsWebApplication.Utilities
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  public interface IEventDispatcher
  {
    void Dispatch( Action action );
  }
}