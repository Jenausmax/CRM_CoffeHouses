using CRM_Bunny.Controller;



namespace CRM_UI
{
    class FlagRole
    {
        public bool Role { get; set; }
        private ControllerUser Controller { get; set; } = new ControllerUser();

        public FlagRole()
        {
            
            Role = Controller.GetFlag();
        }
    }
}
