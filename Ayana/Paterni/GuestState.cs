namespace Ayana.Paterni
{
    public class GuestState : IMode
    {

        public  string GetStatus()
        {
            return "Guest";
        }

        public  bool CanPurchase()
        {
            return false;
        }

        public  bool CanView()
        {
            return true;
        }

        
    }

}
