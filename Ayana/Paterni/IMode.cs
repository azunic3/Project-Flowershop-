using Microsoft.AspNetCore.Identity;

namespace Ayana.Paterni
{
    public interface IMode
    {
        string GetStatus();
        bool CanPurchase();
        bool CanView();
    }
}
