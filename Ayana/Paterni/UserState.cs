using Ayana.Paterni;
using Microsoft.AspNetCore.Identity;

public class UserState 
{
    private IMode _currentState;

    public UserState()
    {
        _currentState = new GuestState(); // Initialize with the Guest state
    }

    public void SetState(IMode state)
    {
        _currentState = state;
    }

    public bool CanPurchase()
    {
        return _currentState.CanPurchase();
    }

    public bool CanView()
    {
        return _currentState.CanView();
    }
}