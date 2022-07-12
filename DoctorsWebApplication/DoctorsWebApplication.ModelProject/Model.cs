namespace  DoctorsWebApplication.ModelProject
{
    using DoctorsWebApplication.Utilities;

  public partial class Model : PropertyContainerBase, IModel
  {
    public Model( IEventDispatcher dispatcher ) : base( dispatcher )
    {
    }
  }
}
