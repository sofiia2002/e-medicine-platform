namespace DoctorsClientApplication.Model
{
    using DoctorsClientApplication.Utilities;

    public partial class Model : PropertyContainerBase, IModel
    {
        public Model(IEventDispatcher dispatch) : base(dispatch)
        {
        }
    }
}
