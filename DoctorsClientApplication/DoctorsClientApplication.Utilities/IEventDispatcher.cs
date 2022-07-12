namespace DoctorsClientApplication.Utilities
{
    using System;
    public interface IEventDispatcher
    {
        void Dispatch(Action eventAction);
    }
}