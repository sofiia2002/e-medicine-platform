namespace DoctorsWebApplication.Utilities
{
  using System;

  using System.Windows.Input;

  public class ControllerCommand : ICommand
  {
    public event EventHandler CanExecuteChanged;

    private readonly Action execute;
    private readonly Func<bool> canExecute;

    public ControllerCommand( Action execute, Func<bool> canExecute )
    {
      if( execute == null )
        throw new ArgumentNullException( "execute" );

      this.execute = execute;
      this.canExecute = canExecute;
    }

    public ControllerCommand( Action execute ) : this( execute, null )
    {
    }

    public bool CanExecute( object parameter )
    {
      return ( this.canExecute == null ) ? true : this.canExecute( );
    }

    public void Execute( object parameter )
    {
      this.execute( );
    }

    public void RaiseCanExecuteChanged( )
    {
      var handler = this.CanExecuteChanged;

      if( handler != null )
      {
        handler( this, EventArgs.Empty );
      }
    }
  }
}