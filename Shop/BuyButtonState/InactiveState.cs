public class InactiveState : IBuyButtonState
{
    public void InitializeState(BuyButton buyButton, Wallet wallet)
    {
        buyButton.ActivateStateObject(ButtonStates.Inactive);
    }

    public void OnButtonPressed()
    {
        throw new System.NotImplementedException("How did you manage to press the disabled button?");
    }
}
