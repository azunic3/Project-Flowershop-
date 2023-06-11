namespace Ayana.Paterni
{
    public class LoggedInState:IMode
    {
        public string GetStatus()
        {
            return "Logged In";
        }

        public bool CanPurchase()
        {
            return true;
        }

        public bool CanView()
        {
            return true;
        }
    }
}
