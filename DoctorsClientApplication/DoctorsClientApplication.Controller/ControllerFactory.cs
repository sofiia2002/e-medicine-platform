namespace DoctorsClientApplication.Controller
{
    using DoctorsClientApplication.Model;
    using DoctorsClientApplication.Utilities;

    public static class ControllerFactory
    {
        private static IController controller;

        public static IController GetController(IEventDispatcher dispatcher)
        {
            if (controller == null)
            {
                IModel newModel = new Model(dispatcher) as IModel;

                IController newController = new Controller(dispatcher, newModel);

                controller = newController;
            }
            return controller;
        }
    }
}
